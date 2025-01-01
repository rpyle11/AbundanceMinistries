namespace AbLedger
{
    partial class Transaction
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
            this.components = new System.ComponentModel.Container();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.TransDatePicker = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.PayeeAddressText = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.MemoText = new Telerik.WinControls.UI.RadTextBox();
            this.AmountText = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.CancelTransactionButton = new Telerik.WinControls.UI.RadButton();
            this.ApplyTransactionButton = new Telerik.WinControls.UI.RadButton();
            this.OptionDeposit = new Telerik.WinControls.UI.RadRadioButton();
            this.OptionPayment = new Telerik.WinControls.UI.RadRadioButton();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.AccountDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.PayeeDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.CheckNumText = new Telerik.WinControls.UI.RadTextBox();
            this.TransErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransDatePicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeAddressText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CancelTransactionButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyTransactionButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckNumText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(28, 14);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(32, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Date:";
            // 
            // TransDatePicker
            // 
            this.TransDatePicker.BackColor = System.Drawing.SystemColors.Window;
            this.TransDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TransDatePicker.Location = new System.Drawing.Point(66, 12);
            this.TransDatePicker.Name = "TransDatePicker";
            this.TransDatePicker.Size = new System.Drawing.Size(194, 24);
            this.TransDatePicker.TabIndex = 1;
            this.TransDatePicker.TabStop = false;
            this.TransDatePicker.Text = "12/6/2020";
            this.TransDatePicker.ThemeName = "TelerikMetroBlue";
            this.TransDatePicker.Value = new System.DateTime(2020, 12, 6, 15, 23, 27, 934);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(22, 47);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(38, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Payee:";
            // 
            // PayeeAddressText
            // 
            this.PayeeAddressText.BackColor = System.Drawing.Color.LightCyan;
            this.PayeeAddressText.Location = new System.Drawing.Point(66, 76);
            this.PayeeAddressText.Multiline = true;
            this.PayeeAddressText.Name = "PayeeAddressText";
            this.PayeeAddressText.ReadOnly = true;
            // 
            // 
            // 
            this.PayeeAddressText.RootElement.StretchVertically = true;
            this.PayeeAddressText.Size = new System.Drawing.Size(194, 55);
            this.PayeeAddressText.TabIndex = 0;
            this.PayeeAddressText.TabStop = false;
            this.PayeeAddressText.ThemeName = "TelerikMetroBlue";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(11, 79);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(49, 18);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "Address:";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(303, 14);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(49, 18);
            this.radLabel4.TabIndex = 6;
            this.radLabel4.Text = "Check #:";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(302, 47);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(50, 18);
            this.radLabel5.TabIndex = 8;
            this.radLabel5.Text = "Account:";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(303, 74);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(41, 18);
            this.radLabel6.TabIndex = 11;
            this.radLabel6.Text = "Memo:";
            // 
            // MemoText
            // 
            this.MemoText.BackColor = System.Drawing.SystemColors.Window;
            this.MemoText.Location = new System.Drawing.Point(358, 76);
            this.MemoText.Multiline = true;
            this.MemoText.Name = "MemoText";
            // 
            // 
            // 
            this.MemoText.RootElement.StretchVertically = true;
            this.MemoText.Size = new System.Drawing.Size(194, 55);
            this.MemoText.TabIndex = 5;
            this.MemoText.ThemeName = "TelerikMetroBlue";
            // 
            // AmountText
            // 
            this.AmountText.BackColor = System.Drawing.SystemColors.Window;
            this.AmountText.Location = new System.Drawing.Point(347, 10);
            this.AmountText.Mask = "C";
            this.AmountText.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.AmountText.Name = "AmountText";
            this.AmountText.Size = new System.Drawing.Size(173, 24);
            this.AmountText.TabIndex = 6;
            this.AmountText.TabStop = false;
            this.AmountText.Text = "$0.00";
            this.AmountText.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.AmountText.ThemeName = "TelerikMetroBlue";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.CancelTransactionButton);
            this.radGroupBox1.Controls.Add(this.ApplyTransactionButton);
            this.radGroupBox1.Controls.Add(this.OptionDeposit);
            this.radGroupBox1.Controls.Add(this.OptionPayment);
            this.radGroupBox1.Controls.Add(this.radLabel7);
            this.radGroupBox1.Controls.Add(this.AmountText);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 144);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(540, 100);
            this.radGroupBox1.TabIndex = 13;
            this.radGroupBox1.ThemeName = "TelerikMetroBlue";
            // 
            // CancelTransactionButton
            // 
            this.CancelTransactionButton.Location = new System.Drawing.Point(74, 55);
            this.CancelTransactionButton.Name = "CancelTransactionButton";
            this.CancelTransactionButton.Size = new System.Drawing.Size(139, 24);
            this.CancelTransactionButton.TabIndex = 10;
            this.CancelTransactionButton.Text = "Cancel Transaction";
            this.CancelTransactionButton.ThemeName = "TelerikMetroBlue";
            this.CancelTransactionButton.Click += new System.EventHandler(this.CancelTransactionButton_Click);
            // 
            // ApplyTransactionButton
            // 
            this.ApplyTransactionButton.Location = new System.Drawing.Point(361, 55);
            this.ApplyTransactionButton.Name = "ApplyTransactionButton";
            this.ApplyTransactionButton.Size = new System.Drawing.Size(139, 24);
            this.ApplyTransactionButton.TabIndex = 9;
            this.ApplyTransactionButton.Text = "Apply Transaction";
            this.ApplyTransactionButton.ThemeName = "TelerikMetroBlue";
            this.ApplyTransactionButton.Click += new System.EventHandler(this.ApplyTransactionButton_Click);
            // 
            // OptionDeposit
            // 
            this.OptionDeposit.Location = new System.Drawing.Point(148, 11);
            this.OptionDeposit.Name = "OptionDeposit";
            this.OptionDeposit.Size = new System.Drawing.Size(65, 19);
            this.OptionDeposit.TabIndex = 8;
            this.OptionDeposit.Text = "Deposit";
            this.OptionDeposit.ThemeName = "TelerikMetroBlue";
            // 
            // OptionPayment
            // 
            this.OptionPayment.Location = new System.Drawing.Point(54, 11);
            this.OptionPayment.Name = "OptionPayment";
            this.OptionPayment.Size = new System.Drawing.Size(70, 19);
            this.OptionPayment.TabIndex = 7;
            this.OptionPayment.Text = "Payment";
            this.OptionPayment.ThemeName = "TelerikMetroBlue";
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(290, 12);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(49, 18);
            this.radLabel7.TabIndex = 13;
            this.radLabel7.Text = "Amount:";
            // 
            // AccountDropDownList
            // 
            this.AccountDropDownList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AccountDropDownList.BackColor = System.Drawing.SystemColors.Window;
            this.AccountDropDownList.Location = new System.Drawing.Point(358, 44);
            this.AccountDropDownList.Name = "AccountDropDownList";
            this.AccountDropDownList.Size = new System.Drawing.Size(194, 24);
            this.AccountDropDownList.TabIndex = 4;
            this.AccountDropDownList.ThemeName = "TelerikMetroBlue";
            // 
            // PayeeDropDownList
            // 
            this.PayeeDropDownList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.PayeeDropDownList.BackColor = System.Drawing.SystemColors.Window;
            this.PayeeDropDownList.DropDownAnimationEnabled = false;
            this.PayeeDropDownList.DropDownHeight = 160;
            this.PayeeDropDownList.Location = new System.Drawing.Point(66, 44);
            this.PayeeDropDownList.Name = "PayeeDropDownList";
            this.PayeeDropDownList.Size = new System.Drawing.Size(194, 24);
            this.PayeeDropDownList.TabIndex = 2;
            this.PayeeDropDownList.ThemeName = "TelerikMetroBlue";
            this.PayeeDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.PayeeDropDownList_SelectedIndexChanged);
            // 
            // CheckNumText
            // 
            this.CheckNumText.BackColor = System.Drawing.SystemColors.Window;
            this.CheckNumText.Location = new System.Drawing.Point(359, 11);
            this.CheckNumText.Name = "CheckNumText";
            this.CheckNumText.Size = new System.Drawing.Size(192, 24);
            this.CheckNumText.TabIndex = 3;
            this.CheckNumText.ThemeName = "TelerikMetroBlue";
            this.CheckNumText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckNumText_KeyPress);
            // 
            // TransErrorProvider
            // 
            this.TransErrorProvider.ContainerControl = this;
            // 
            // Transaction
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 15);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(568, 273);
            this.Controls.Add(this.CheckNumText);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.MemoText);
            this.Controls.Add(this.AccountDropDownList);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.PayeeAddressText);
            this.Controls.Add(this.PayeeDropDownList);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.TransDatePicker);
            this.Controls.Add(this.radLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(573, 308);
            this.Name = "Transaction";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction Entry";
            this.ThemeName = "TelerikMetroBlue";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Transaction_FormClosed);
            this.Load += new System.EventHandler(this.Transaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransDatePicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeAddressText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CancelTransactionButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyTransactionButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckNumText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDateTimePicker TransDatePicker;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox PayeeAddressText;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox MemoText;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadMaskedEditBox AmountText;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton CancelTransactionButton;
        private Telerik.WinControls.UI.RadButton ApplyTransactionButton;
        private Telerik.WinControls.UI.RadRadioButton OptionDeposit;
        private Telerik.WinControls.UI.RadRadioButton OptionPayment;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadDropDownList AccountDropDownList;
        private Telerik.WinControls.UI.RadDropDownList PayeeDropDownList;
        private Telerik.WinControls.UI.RadTextBox CheckNumText;
        private System.Windows.Forms.ErrorProvider TransErrorProvider;
    }
}
