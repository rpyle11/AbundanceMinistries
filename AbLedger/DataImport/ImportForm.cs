using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataImport.Services;
using Telerik.WinControls;

namespace DataImport
{
    public partial class ImportForm : Telerik.WinControls.UI.RadForm
    {
        public ImportForm()
        {
            InitializeComponent();
        }

        private async void ImportDataButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var dataSvc = new AppDataService();
            if (await dataSvc.ImportOldData())
            {
                Cursor = Cursors.Default;
                MessageBox.Show(@"success");
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show(@"failed");
            }
            
        }
    }
}
