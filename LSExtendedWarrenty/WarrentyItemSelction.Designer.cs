namespace LSExtendedWarrenty
{
    partial class WarrentyItemSelction
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelYearsOfWarrenty = new System.Windows.Forms.Label();
            this.textBoxItemSerial = new System.Windows.Forms.TextBox();
            this.labelItemSerial = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxItem = new System.Windows.Forms.TextBox();
            this.textBoxSalePrice = new System.Windows.Forms.TextBox();
            this.textBoxWarrentyAmount = new System.Windows.Forms.TextBox();
            this.labelItem = new System.Windows.Forms.Label();
            this.labelSalePrice = new System.Windows.Forms.Label();
            this.labelWarrentyAmount = new System.Windows.Forms.Label();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBoxDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(110, 133);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(66, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDown1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown1_KeyPress);
            // 
            // labelYearsOfWarrenty
            // 
            this.labelYearsOfWarrenty.AutoSize = true;
            this.labelYearsOfWarrenty.Location = new System.Drawing.Point(14, 135);
            this.labelYearsOfWarrenty.Name = "labelYearsOfWarrenty";
            this.labelYearsOfWarrenty.Size = new System.Drawing.Size(92, 13);
            this.labelYearsOfWarrenty.TabIndex = 4;
            this.labelYearsOfWarrenty.Text = "&Years of Warranty";
            // 
            // textBoxItemSerial
            // 
            this.textBoxItemSerial.Location = new System.Drawing.Point(110, 106);
            this.textBoxItemSerial.Name = "textBoxItemSerial";
            this.textBoxItemSerial.Size = new System.Drawing.Size(147, 20);
            this.textBoxItemSerial.TabIndex = 5;
            this.textBoxItemSerial.TextChanged += new System.EventHandler(this.textBoxItemSerial_TextChanged);
            this.textBoxItemSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxItemSerial_KeyPress);
            // 
            // labelItemSerial
            // 
            this.labelItemSerial.AutoSize = true;
            this.labelItemSerial.Location = new System.Drawing.Point(50, 109);
            this.labelItemSerial.Name = "labelItemSerial";
            this.labelItemSerial.Size = new System.Drawing.Size(56, 13);
            this.labelItemSerial.TabIndex = 3;
            this.labelItemSerial.Text = "&Item Serial";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(185, 159);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(104, 159);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxItem
            // 
            this.textBoxItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxItem.ForeColor = System.Drawing.Color.DarkRed;
            this.textBoxItem.Location = new System.Drawing.Point(100, 19);
            this.textBoxItem.Name = "textBoxItem";
            this.textBoxItem.ReadOnly = true;
            this.textBoxItem.Size = new System.Drawing.Size(136, 13);
            this.textBoxItem.TabIndex = 9;
            // 
            // textBoxSalePrice
            // 
            this.textBoxSalePrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSalePrice.ForeColor = System.Drawing.Color.DarkRed;
            this.textBoxSalePrice.Location = new System.Drawing.Point(100, 38);
            this.textBoxSalePrice.Name = "textBoxSalePrice";
            this.textBoxSalePrice.ReadOnly = true;
            this.textBoxSalePrice.Size = new System.Drawing.Size(136, 13);
            this.textBoxSalePrice.TabIndex = 9;
            // 
            // textBoxWarrentyAmount
            // 
            this.textBoxWarrentyAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxWarrentyAmount.Location = new System.Drawing.Point(100, 57);
            this.textBoxWarrentyAmount.Name = "textBoxWarrentyAmount";
            this.textBoxWarrentyAmount.ReadOnly = true;
            this.textBoxWarrentyAmount.Size = new System.Drawing.Size(136, 13);
            this.textBoxWarrentyAmount.TabIndex = 9;
            // 
            // labelItem
            // 
            this.labelItem.AutoSize = true;
            this.labelItem.Location = new System.Drawing.Point(64, 19);
            this.labelItem.Name = "labelItem";
            this.labelItem.Size = new System.Drawing.Size(27, 13);
            this.labelItem.TabIndex = 3;
            this.labelItem.Text = "Item";
            // 
            // labelSalePrice
            // 
            this.labelSalePrice.AutoSize = true;
            this.labelSalePrice.Location = new System.Drawing.Point(36, 38);
            this.labelSalePrice.Name = "labelSalePrice";
            this.labelSalePrice.Size = new System.Drawing.Size(55, 13);
            this.labelSalePrice.TabIndex = 3;
            this.labelSalePrice.Text = "Sale Price";
            // 
            // labelWarrentyAmount
            // 
            this.labelWarrentyAmount.AutoSize = true;
            this.labelWarrentyAmount.Location = new System.Drawing.Point(2, 57);
            this.labelWarrentyAmount.Name = "labelWarrentyAmount";
            this.labelWarrentyAmount.Size = new System.Drawing.Size(89, 13);
            this.labelWarrentyAmount.TabIndex = 3;
            this.labelWarrentyAmount.Text = "Warranty Amount";
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.labelItem);
            this.groupBoxDetails.Controls.Add(this.textBoxWarrentyAmount);
            this.groupBoxDetails.Controls.Add(this.labelSalePrice);
            this.groupBoxDetails.Controls.Add(this.textBoxSalePrice);
            this.groupBoxDetails.Controls.Add(this.textBoxItem);
            this.groupBoxDetails.Controls.Add(this.labelWarrentyAmount);
            this.groupBoxDetails.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(242, 83);
            this.groupBoxDetails.TabIndex = 10;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Details";
            // 
            // WarrentyItemSelction
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(266, 193);
            this.Controls.Add(this.groupBoxDetails);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.labelYearsOfWarrenty);
            this.Controls.Add(this.textBoxItemSerial);
            this.Controls.Add(this.labelItemSerial);
            this.MaximumSize = new System.Drawing.Size(282, 232);
            this.MinimumSize = new System.Drawing.Size(282, 232);
            this.Name = "WarrentyItemSelction";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item Config.";
            this.Load += new System.EventHandler(this.WarrentyItemSelction_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WarrentyItemSelction_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label labelYearsOfWarrenty;
        private System.Windows.Forms.TextBox textBoxItemSerial;
        private System.Windows.Forms.Label labelItemSerial;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxItem;
        private System.Windows.Forms.TextBox textBoxSalePrice;
        private System.Windows.Forms.TextBox textBoxWarrentyAmount;
        private System.Windows.Forms.Label labelItem;
        private System.Windows.Forms.Label labelSalePrice;
        private System.Windows.Forms.Label labelWarrentyAmount;
        private System.Windows.Forms.GroupBox groupBoxDetails;
    }
}