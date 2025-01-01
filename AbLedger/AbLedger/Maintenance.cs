using AbLedger.Entities;
using AbLedger.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbLedger
{
    public partial class Maintenance : Telerik.WinControls.UI.RadForm
    {
        private AppDataService DataService { get; set; }

        private List<Accounts> AccountList { get; set; }
        private List<Payees> PayeesList { get; set; }

        public bool DoRestore { get; set; }
        public Maintenance(AppDataService dataService)
        {
            InitializeComponent();
            Width = 580;
            Height = 481;
            DataService = dataService;
        }

        private void MaintenanceFileMenuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void Maintenance_Load(object sender, EventArgs e)
        {
            if (DoRestore)
            {
                MaintenancePageViewer.SelectedPage = DatabaseRestorePage;
            }
            else
            {
               
                await LoadAccounts();
            }
           
        }

        private async Task LoadAccounts()
        {
            try
            {
                AccountList = await DataService.GetAllAccounts();
                if (AccountList != null)
                {
                    AccountsGrid.DataSource = AccountList.OrderBy(o => o.Account);
                }

            }
            catch (Exception ex)
            {
                await DataService.LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = ex.Message
                });
                MessageBox.Show(ex.Message, @"Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async Task LoadPayees()
        {
            try
            {
                PayeesList = await DataService.GetAllPayees();
                if (PayeesList != null)
                {
                    PayeesGrid.DataSource = PayeesList.OrderBy(o => o.PayeeName);
                }

            }
            catch (Exception ex)
            {
                await DataService.LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = ex.Message
                });
                MessageBox.Show(ex.Message, @"Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void AccountsGrid_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (e.CurrentRow != null)
            {
                var data = (Accounts)e.CurrentRow.DataBoundItem;

                AccountNameText.Text = data.Account;
                AccountActiveCheckBox.Checked = data.Active ?? true;
            }
            else
            {
                AccountNameText.Clear();
                AccountActiveCheckBox.Checked = false;
            }
        }

        private void PayeesGrid_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (e.CurrentRow != null)
            {
                var data = (Payees)e.CurrentRow.DataBoundItem;

                PayeeNameText.Text = data.PayeeName;
                PayeeAddressText.Text = data.Address;
                PayeeCheckBox.Checked = data.Active ?? true;
            }
            else
            {
                PayeeNameText.Clear();
                PayeeAddressText.Clear();
                PayeeCheckBox.Checked = false;
            }
        }

        private void AddAccountButton_Click(object sender, EventArgs e)
        {
            AccountsGrid.ClearSelection();
            AccountsGrid.CurrentRow = null;
            AccountActiveCheckBox.Checked = true;
            AccountNameText.Clear();
            AccountNameText.SelectAll();
            AccountNameText.Focus();
        }

        private async void SaveAccountButton_Click(object sender, EventArgs e)
        {
            try
            {

                MaintenanceErrorProvider.Clear();
                if (AccountNameText.Text.Trim().Length == 0)
                {
                    MaintenanceErrorProvider.SetError(AccountNameText, "Account Name required");
                }

                if (AccountsGrid.CurrentRow == null)
                {
                    var newAccount = new Accounts
                    {
                        Account = AccountNameText.Text.Trim(),
                        Active = AccountActiveCheckBox.Checked
                    };

                    var account = await DataService.AddUpdateAccount(newAccount);

                    await LoadAccounts();

                    foreach (var rw in AccountsGrid.Rows)
                    {
                        var item = (Accounts)rw.DataBoundItem;
                        if (item.Id.Equals(account.Id))
                        {
                            AccountsGrid.CurrentRow = rw;
                        }
                    }
                }
                else
                {
                    var currentAccount = (Accounts)AccountsGrid.CurrentRow.DataBoundItem;

                    currentAccount.Account = AccountNameText.Text;
                    currentAccount.Active = AccountActiveCheckBox.Checked;

                    var account = await DataService.AddUpdateAccount(currentAccount);

                    await LoadAccounts();

                    foreach (var rw in AccountsGrid.Rows)
                    {
                        var item = (Accounts)rw.DataBoundItem;
                        if (item.Id.Equals(account.Id))
                        {
                            AccountsGrid.CurrentRow = rw;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                await DataService.LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = ex.Message
                });
                MessageBox.Show(ex.Message, @"Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void AddPayeeButton_Click(object sender, EventArgs e)
        {
            PayeesGrid.ClearSelection();
            PayeesGrid.CurrentRow = null;
            PayeeCheckBox.Checked = true;
            PayeeAddressText.Clear();
            PayeeNameText.Clear();
            PayeeNameText.SelectAll();
            PayeeNameText.Focus();
        }

        private async void SavePayee_Click(object sender, EventArgs e)
        {
            try
            {


                MaintenanceErrorProvider.Clear();
                if (PayeeNameText.Text.Trim().Length == 0)
                {
                    MaintenanceErrorProvider.SetError(PayeeNameText, "Payee Name required");
                }

                if (PayeesGrid.CurrentRow == null)
                {
                    var newPayee = new Payees
                    {
                        PayeeName = PayeeNameText.Text.Trim(),
                        Address = PayeeAddressText.Text.Trim(),
                        Active = AccountActiveCheckBox.Checked
                    };

                    var payee = await DataService.AddUpdatePayee(newPayee);

                    await LoadPayees();

                    foreach (var rw in PayeesGrid.Rows)
                    {
                        var item = (Payees)rw.DataBoundItem;
                        if (item.Id.Equals(payee.Id))
                        {
                            PayeesGrid.CurrentRow = rw;
                        }
                    }
                }
                else
                {
                    var currentPayee = (Payees)PayeesGrid.CurrentRow.DataBoundItem;

                    currentPayee.PayeeName = PayeeNameText.Text;
                    currentPayee.Address = PayeeAddressText.Text;
                    currentPayee.Active = PayeeCheckBox.Checked;

                    var payee = await DataService.AddUpdatePayee(currentPayee);

                    await LoadPayees();

                    foreach (var rw in PayeesGrid.Rows)
                    {
                        var item = (Payees)rw.DataBoundItem;
                        if (item.Id.Equals(payee.Id))
                        {
                            PayeesGrid.CurrentRow = rw;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                await DataService.LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = ex.Message
                });
                MessageBox.Show(ex.Message, @"Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private async void MaintenancePageViewer_SelectedPageChanged(object sender, EventArgs e)
        {
            switch (MaintenancePageViewer.SelectedPage.Name)
            {
                case "AccountsPage":
                    await LoadAccounts();
                    break;
                case "PayeesPage":
                    await LoadPayees();
                    break;
                case "DatabaseBackupPage":
                    await SetDatabaseBackupInfo();
                    break;
                case "DatabaseRestorePage":
                    break;
            }
        }

        private async Task SetDatabaseBackupInfo()
        {
            try
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.BackupFolder))
                {
                    BackupMessageLabel.Text = @"A Backup folder has not been set.\r\nClick the Change Backup Location button to set a location.";
                    LastBackupLabel.Text = @"Last Backup:";
                    BackupDatabaseButton.Enabled = false;
                }
                else
                {
                    BackupMessageLabel.Text = Properties.Settings.Default.BackupFolder;
                    if (!File.Exists(Path.Combine(Properties.Settings.Default.BackupFolder, "AbLedgerData.db")))
                    {
                        LastBackupLabel.Text = @"Database has not been backed up.";
                    }
                    else
                    {
                        var dbFileInfo = new FileInfo(Path.Combine(Properties.Settings.Default.BackupFolder, "AbLedgerData.db"));
                        LastBackupLabel.Text = @$"Last Backup: {dbFileInfo.LastAccessTime:MM/dd/yyyy hh:mm:ss tt} File: ABLedgerData.db";
                    }
                }
            }
            catch (Exception ex)
            {
                await DataService.LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = ex.Message
                });
                MessageBox.Show(ex.Message, @"Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ChangeBackupButton_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog()
            {
                ShowNewFolderButton = true,
                RootFolder = Environment.SpecialFolder.MyComputer,
                Description = @"Select the folder where the database backup file will be created."
            };

            if (folderBrowserDialog.ShowDialog() != DialogResult.OK ||
                !Directory.Exists(folderBrowserDialog.SelectedPath)) return;
            BackupMessageLabel.Text = folderBrowserDialog.SelectedPath;
            Properties.Settings.Default.BackupFolder = folderBrowserDialog.SelectedPath;
            Properties.Settings.Default.Save();
            BackupDatabaseButton.Enabled = true;
        }

        private async void BackupDatabaseButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (await DataService.BackupDatabase())
                {
                    var dbFileInfo = new FileInfo(Path.Combine(Properties.Settings.Default.BackupFolder, "AbLedgerData.db"));
                    LastBackupLabel.Text = @$"Last Backup: {dbFileInfo.LastAccessTime:MM/dd/yyyy hh:mm:ss tt} File: ABLedgerData.db";
                    Cursor = Cursors.Default;

                    MessageBox.Show(@"Successful backup.", @"Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show(@"Backup Failure.", @"Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                await DataService.LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = ex.Message
                });
                MessageBox.Show(ex.Message, @"Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async void DatabaseRestoreBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog()
                {
                    Filter = @"AB Backup File |AbLedgerData.db",
                    InitialDirectory = "c:\\",
                    Multiselect = false,
                    Title = @"Select the AbLedgerData.db file",
                    CheckPathExists = true
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DatabaseBackupRestoreText.Text = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                await DataService.LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = ex.Message
                });
                MessageBox.Show(ex.Message, @"Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void RestoreDatabaseButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!await DataService.RestoreDatabase(DatabaseBackupRestoreText.Text)) return;
                DoRestore = false;
                MessageBox.Show(@"Abundance Ministries restore successful.", @"Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                await DataService.LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = ex.Message
                });

                MessageBox.Show(ex.Message, @"Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
