using System.Drawing;

namespace AbLedger
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new Telerik.WinControls.UI.RadMenu();
            this.FileMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.FileMaintenanceMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.FileReportsMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.FileExitMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.TransactionsGrid = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.EndDatePicker = new Telerik.WinControls.UI.RadDateTimePicker();
            this.BeginDatePicker = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ReportsButton = new Telerik.WinControls.UI.RadButton();
            this.TransactionEntryButton = new Telerik.WinControls.UI.RadButton();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            ((System.ComponentModel.ISupportInitialize)(this.MainMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionsGrid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndDatePicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeginDatePicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionEntryButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.FileMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.MainMenu.Size = new System.Drawing.Size(1656, 29);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.ThemeName = "TelerikMetroBlue";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.FileMaintenanceMenuItem,
            this.FileReportsMenuItem,
            this.radMenuSeparatorItem1,
            this.FileExitMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Text = "File";
            // 
            // FileMaintenanceMenuItem
            // 
            this.FileMaintenanceMenuItem.KeyTip = "ALT + M";
            this.FileMaintenanceMenuItem.Name = "FileMaintenanceMenuItem";
            this.FileMaintenanceMenuItem.Text = "Maintenance";
            this.FileMaintenanceMenuItem.Click += new System.EventHandler(this.FileMaintenanceMenuItem_Click);
            // 
            // FileReportsMenuItem
            // 
            this.FileReportsMenuItem.Name = "FileReportsMenuItem";
            this.FileReportsMenuItem.Text = "Reports";
            this.FileReportsMenuItem.Click += new System.EventHandler(this.FileReportsMenuItem_Click);
            // 
            // radMenuSeparatorItem1
            // 
            this.radMenuSeparatorItem1.Name = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Text = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FileExitMenuItem
            // 
            this.FileExitMenuItem.Name = "FileExitMenuItem";
            this.FileExitMenuItem.Text = "Exit";
            this.FileExitMenuItem.Click += new System.EventHandler(this.FileExitMenuItem_Click);
            // 
            // TransactionsGrid
            // 
            this.TransactionsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionsGrid.BackColor = System.Drawing.SystemColors.Control;
            this.TransactionsGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.TransactionsGrid.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TransactionsGrid.ForeColor = System.Drawing.Color.Black;
            this.TransactionsGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TransactionsGrid.Location = new System.Drawing.Point(12, 78);
            // 
            // 
            // 
            this.TransactionsGrid.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.DataType = typeof(System.DateTime);
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "TransDate";
            gridViewTextBoxColumn1.FormatString = "{0:MM/dd/yyyy hh:mm:ss tt}";
            gridViewTextBoxColumn1.HeaderText = "Date";
            gridViewTextBoxColumn1.Name = "TransDateCol";
            gridViewTextBoxColumn1.Width = 125;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "CheckNum";
            gridViewTextBoxColumn2.HeaderText = "Check #";
            gridViewTextBoxColumn2.Name = "CheckNumcol";
            gridViewTextBoxColumn2.Width = 90;
            gridViewTextBoxColumn3.AllowGroup = false;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Payee";
            gridViewTextBoxColumn3.HeaderText = "Payee";
            gridViewTextBoxColumn3.Name = "PayeeCol";
            gridViewTextBoxColumn3.Width = 95;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Account";
            gridViewTextBoxColumn4.HeaderText = "Account";
            gridViewTextBoxColumn4.Name = "AccountCol";
            gridViewTextBoxColumn4.Width = 95;
            gridViewTextBoxColumn5.AllowGroup = false;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Memo";
            gridViewTextBoxColumn5.HeaderText = "Memo";
            gridViewTextBoxColumn5.Name = "MemoCol";
            gridViewTextBoxColumn5.Width = 110;
            gridViewTextBoxColumn6.DataType = typeof(decimal);
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Payment";
            gridViewTextBoxColumn6.FormatString = "{0:c}";
            gridViewTextBoxColumn6.HeaderText = "Payment";
            gridViewTextBoxColumn6.Name = "PaymentCol";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn6.Width = 150;
            gridViewTextBoxColumn7.DataType = typeof(decimal);
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "Deposit";
            gridViewTextBoxColumn7.FormatString = "{0:c}";
            gridViewTextBoxColumn7.HeaderText = "Deposit";
            gridViewTextBoxColumn7.Name = "DepositCol";
            gridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn7.Width = 150;
            gridViewTextBoxColumn8.DataType = typeof(decimal);
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "EndingBalance";
            gridViewTextBoxColumn8.FormatString = "{0:c}";
            gridViewTextBoxColumn8.HeaderText = "Balance";
            gridViewTextBoxColumn8.Name = "EndingBalanceCol";
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn8.Width = 150;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "Id";
            gridViewTextBoxColumn9.HeaderText = "TransId";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "TransIdCol";
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "BeginningBalance";
            gridViewTextBoxColumn10.HeaderText = "BeginBalance";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "BeginBalanceCol";
            this.TransactionsGrid.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.TransactionsGrid.MasterTemplate.EnableGrouping = false;
            this.TransactionsGrid.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.TransactionsGrid.Name = "TransactionsGrid";
            this.TransactionsGrid.ReadOnly = true;
            this.TransactionsGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TransactionsGrid.ShowGroupPanel = false;
            this.TransactionsGrid.Size = new System.Drawing.Size(1505, 477);
            this.TransactionsGrid.TabIndex = 1;
            this.TransactionsGrid.ThemeName = "TelerikMetroBlue";
            // 
            // radPanel1
            // 
            this.radPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPanel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.radPanel1.Controls.Add(this.EndDatePicker);
            this.radPanel1.Controls.Add(this.BeginDatePicker);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Location = new System.Drawing.Point(12, 32);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1505, 48);
            this.radPanel1.TabIndex = 2;
            this.radPanel1.ThemeName = "TelerikMetroBlue";
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.BackColor = System.Drawing.SystemColors.Window;
            this.EndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDatePicker.Location = new System.Drawing.Point(362, 12);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(117, 24);
            this.EndDatePicker.TabIndex = 3;
            this.EndDatePicker.TabStop = false;
            this.EndDatePicker.Text = "12/4/2020";
            this.EndDatePicker.ThemeName = "TelerikMetroBlue";
            this.EndDatePicker.Value = new System.DateTime(2020, 12, 4, 16, 43, 41, 792);
            this.EndDatePicker.ValueChanged += new System.EventHandler(this.EndDatePicker_ValueChanged);
            // 
            // BeginDatePicker
            // 
            this.BeginDatePicker.BackColor = System.Drawing.SystemColors.Window;
            this.BeginDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BeginDatePicker.Location = new System.Drawing.Point(119, 12);
            this.BeginDatePicker.Name = "BeginDatePicker";
            this.BeginDatePicker.Size = new System.Drawing.Size(117, 24);
            this.BeginDatePicker.TabIndex = 2;
            this.BeginDatePicker.TabStop = false;
            this.BeginDatePicker.Text = "12/4/2020";
            this.BeginDatePicker.ThemeName = "TelerikMetroBlue";
            this.BeginDatePicker.Value = new System.DateTime(2020, 12, 4, 16, 43, 41, 792);
            this.BeginDatePicker.ValueChanged += new System.EventHandler(this.BeginDatePicker_ValueChanged);
            // 
            // radLabel2
            // 
            this.radLabel2.ForeColor = System.Drawing.Color.White;
            this.radLabel2.Location = new System.Drawing.Point(286, 13);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(76, 19);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Ending Date:";
            this.radLabel2.ThemeName = "TelerikMetroBlue";
            // 
            // radLabel1
            // 
            this.radLabel1.ForeColor = System.Drawing.Color.White;
            this.radLabel1.Location = new System.Drawing.Point(27, 13);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(93, 19);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Beginning Date:";
            this.radLabel1.ThemeName = "TelerikMetroBlue";
            // 
            // ReportsButton
            // 
            this.ReportsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReportsButton.Location = new System.Drawing.Point(1534, 50);
            this.ReportsButton.Name = "ReportsButton";
            this.ReportsButton.Size = new System.Drawing.Size(110, 24);
            this.ReportsButton.TabIndex = 3;
            this.ReportsButton.Text = "Reports";
            this.ReportsButton.ThemeName = "TelerikMetroBlue";
            this.ReportsButton.Click += new System.EventHandler(this.ReportsButton_Click);
            // 
            // TransactionEntryButton
            // 
            this.TransactionEntryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionEntryButton.Location = new System.Drawing.Point(1534, 80);
            this.TransactionEntryButton.Name = "TransactionEntryButton";
            this.TransactionEntryButton.Size = new System.Drawing.Size(110, 24);
            this.TransactionEntryButton.TabIndex = 4;
            this.TransactionEntryButton.Text = "Transaction Entry";
            this.TransactionEntryButton.ThemeName = "TelerikMetroBlue";
            this.TransactionEntryButton.Click += new System.EventHandler(this.TransactionEntryButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 15);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 497);
            this.Controls.Add(this.TransactionEntryButton);
            this.Controls.Add(this.ReportsButton);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.TransactionsGrid);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abundance Ministries Ledger";
            this.ThemeName = "TelerikMetroBlue";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionsGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndDatePicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeginDatePicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionEntryButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadMenu MainMenu;
        private Telerik.WinControls.UI.RadMenuItem FileMenuItem;
        private Telerik.WinControls.UI.RadMenuItem FileMaintenanceMenuItem;
        private Telerik.WinControls.UI.RadMenuItem FileReportsMenuItem;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
        private Telerik.WinControls.UI.RadMenuItem FileExitMenuItem;
        private Telerik.WinControls.UI.RadGridView TransactionsGrid;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadDateTimePicker EndDatePicker;
        private Telerik.WinControls.UI.RadDateTimePicker BeginDatePicker;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton ReportsButton;
        private Telerik.WinControls.UI.RadButton TransactionEntryButton;
        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
    }
}
