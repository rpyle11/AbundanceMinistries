using AbLedger.Entities;
using AbLedger.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbLedger
{
    public partial class Transaction : Telerik.WinControls.UI.RadForm
    {
        private AppDataService DataService { get; }

        private List<Payees> PayeesList { get; set; }

        public Transaction(AppDataService dataService)
        {
            InitializeComponent();
            try
            {
                DataService = dataService;
                Size = MinimumSize;
            }
            catch (ArgumentOutOfRangeException e)
            {
                DataService.LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                }).RunSynchronously();
            }

        }

        public sealed override Size MinimumSize
        {
            get => base.MinimumSize;
            set => base.MinimumSize = value;
        }

        private async void Transaction_Load(object sender, EventArgs e)
        {
            await LoadAccounts();
            await LoadPayees();

            OptionPayment.IsChecked = true;

            TransDatePicker.Value = DateTime.Today;


        }

        private async Task LoadAccounts()
        {
            try
            {
                AccountDropDownList.DisplayMember = "Account";
                AccountDropDownList.ValueMember = "Id";
                AccountDropDownList.DataSource = await DataService.GetActiveAccounts();
                AccountDropDownList.SelectedIndex = -1;
            }
            catch (Exception e)
            {
                await DataService.LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });

            }
        }

        private async Task LoadPayees()
        {
            try
            {
                PayeesList = await DataService.GetActivePayees();
                PayeeDropDownList.DisplayMember = "PayeeName";
                PayeeDropDownList.ValueMember = "Id";
                PayeeDropDownList.DataSource = PayeesList;
                PayeeDropDownList.SelectedIndex = -1;
            }
            catch (Exception e)
            {
                await DataService.LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });

            }
        }

        private void Transaction_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataService.Dispose();
        }

        private void PayeeDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (PayeeDropDownList.SelectedIndex == -1)
            {
                PayeeAddressText.Clear();
            }
            else
            {
                var payee = (Payees)PayeeDropDownList.SelectedItem.DataBoundItem;

                if (string.IsNullOrEmpty(payee.Address))
                {
                    PayeeAddressText.Clear();
                }
                else
                {
                    PayeeAddressText.Text = payee.Address;
                }
            }


        }

        private void CancelTransactionButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async Task<bool> ValidateForm()
        {

            try
            {
                TransErrorProvider.Clear();
                if (PayeeDropDownList.SelectedItem == null)
                {
                    TransErrorProvider.SetError(PayeeDropDownList, "Payee Required");
                    PayeeDropDownList.ShowDropDown();

                    return false;

                }

                if (AccountDropDownList.SelectedItem == null)
                {
                    TransErrorProvider.SetError(AccountDropDownList, "Account Required");
                    AccountDropDownList.ShowDropDown();

                    return false;
                }

                if (AmountText.Value is not "0.00") return true;
                TransErrorProvider.SetError(AmountText, "Amount must be greater than 0");


                return false;
            }
            catch (Exception e)
            {
                await DataService.LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });

            }

            return false;
        }

        private async void ApplyTransactionButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!await ValidateForm()) return;
                var futureTrans = await DataService.FutureTransactions(TransDatePicker.Value);
                if (futureTrans != null && futureTrans.Any())
                {
                    Cursor = Cursors.Default;

                    if (MessageBox.Show(
                            @"The date entered for this trans action is not in sequence. Are you sure you wish to continue with this transaction?",
                            @"Out of Sequence Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                        DialogResult.No)
                    {
                        return;
                    }

                }

                decimal endBalance = 0;
                var dtNow = DateTime.Now;
                var dtDateString = TransDatePicker.Value.ToShortDateString();
                var dtTimeString = $"{dtNow.Hour}:{dtNow.Minute}:{dtNow.Second}";
                var tranDateCurrentTime = DateTime.Parse(dtDateString + " " + dtTimeString);
                                                         
                var lastBalanceTransaction = await DataService.GetLastBalanceByDate(tranDateCurrentTime);

                if (lastBalanceTransaction == null)
                {
                    MessageBox.Show(@"Error adding transaction");
                    return;
                }
                if (lastBalanceTransaction.EndBalance != null)
                {
                    endBalance = lastBalanceTransaction.EndBalance.Value;
                }

                if (OptionDeposit.IsChecked)
                {
                    endBalance += decimal.Parse(AmountText.Value.ToString() ?? string.Empty);
                }
                else
                {
                    endBalance -= decimal.Parse(AmountText.Value.ToString() ?? string.Empty);
                }

                var tran = new Transactions
                {
                    TransDate = TransDatePicker.Value,
                    CheckNum = string.IsNullOrEmpty(CheckNumText.Text) ? null : CheckNumText.Text,
                    AccountId = (int)AccountDropDownList.SelectedValue,
                    PayeeId = (int)PayeeDropDownList.SelectedValue,
                    Memo = MemoText.Text,
                    TransAmount = decimal.Parse(AmountText.Value.ToString() ?? string.Empty),
                    Deposit = OptionDeposit.IsChecked,
                    Payment = OptionPayment.IsChecked
                };
                if (lastBalanceTransaction.EndBalance != null)
                    tran.BeginBalance = lastBalanceTransaction.EndBalance.Value;
                tran.EndBalance = endBalance;

                var completeTransaction = await DataService.AddTransaction(tran);

                if (completeTransaction != null)
                {
                    if (await DataService.CheckForTransactionWithGreaterDate(endBalance, futureTrans))
                    {
                        Cursor = Cursors.Default;
                        Hide();
                        Dispose();
                    }
                    else
                    {
                        MessageBox.Show(@"Problem running transaction reconciliation");
                    }
                }
                else
                {
                    MessageBox.Show(@"Error adding transaction");
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                await DataService.LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = ex.Message
                });

            }

        }

        private void CheckNumText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.')
            {
                e.Handled = true;
            }

        }
    }
}
