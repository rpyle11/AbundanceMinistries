using AbLedger.Services;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbLedger.Data;
using Telerik.WinControls;


namespace AbLedger
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        private AppDataService DataService { get; }

        private AbLedgerDataContext AppContext { get;  }
        public MainForm()
        {
            InitializeComponent();
            AppContext = new AbLedgerDataContext();

            DataService = new AppDataService(AppContext);
            FileMaintenanceMenuItem.Shortcuts.Add(new RadShortcut(Keys.Alt, Keys.M));
            FileReportsMenuItem.Shortcuts.Add(new RadShortcut(Keys.Alt, Keys.R));
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            var dbUnc = ConfigurationManager.ConnectionStrings["DbCnn"].ConnectionString.Replace("DataSource=", "");
            var dbFileInfo = new FileInfo(dbUnc);
            
            if (!File.Exists(dbUnc) || dbFileInfo.Length==0)
            {
                MessageBox.Show(@"No valid database file was found for the application! Please restore the database.", @"Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var maintenance = new Maintenance(DataService) {DoRestore = true};
                maintenance.ShowDialog();

              
                var dbRestoreFileInfo = new FileInfo(dbUnc);
                if (dbRestoreFileInfo.Length > 0)
                {
                    SetOpeningDates();
                }
               
            }
            else
            {
                SetOpeningDates();
            }
           

        }

        private void SetOpeningDates()
        {
            var beginDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            BeginDatePicker.Value = beginDate;
            EndDatePicker.Value = beginDate.AddMonths(1).AddDays(-1);
        }

       

        private async void BeginDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (BeginDatePicker.Value != DateTime.MinValue && EndDatePicker.Value != DateTime.MinValue)
            {
                await LoadTransactions();
            }
        }

        private async void EndDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (BeginDatePicker.Value != DateTime.MinValue && EndDatePicker.Value != DateTime.MinValue)
            {
                await LoadTransactions();
            }
        }

        private async Task LoadTransactions()
        {
           

            var dtBegin = DateTime.Parse(BeginDatePicker.Value.Date.ToShortDateString() + " 00:00:00");
            var dtEnd = DateTime.Parse(EndDatePicker.Value.Date.ToShortDateString() + " 12:59:59");

            if (dtBegin < dtEnd)
            {
                Cursor = Cursors.WaitCursor;
                var data = await DataService.GetTransactionsByDate(dtBegin, dtEnd);

                Cursor = Cursors.Default;
                if (data == null)
                {
                    MessageBox.Show($@"No transactions found dates between {dtBegin.Date.ToShortDateString()} and {dtEnd.Date.ToShortDateString()}");
                    
                }
                else
                {
                    TransactionsGrid.DataSource = data.OrderByDescending(o => o.TransDate);
                }
                
            }
            else
            {
                MessageBox.Show(@"Beginning date must be less than ending date");
            }

        }

        private void FileExitMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Application.Exit();
        }

        private async void FileMaintenanceMenuItem_Click(object sender, EventArgs e)
        {
            var vm = new Maintenance(DataService);
            vm.ShowDialog();

            await LoadTransactions();
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
          ShowReportsWindow();
        }

        private static void ShowReportsWindow()
        {
            var reports = new Reports();
            reports.ShowDialog();
        }

        private void FileReportsMenuItem_Click(object sender, EventArgs e)
        {
            ShowReportsWindow();
        }

        private async void TransactionEntryButton_Click(object sender, EventArgs e)
        {
            var transWindow = new Transaction(DataService);
            transWindow.ShowDialog();

            TransactionsGrid.DataSource = null;

            await LoadTransactions();


        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataService.Dispose();
        }
    }
}
