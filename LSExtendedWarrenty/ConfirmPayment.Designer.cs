namespace LSExtendedWarrenty
{
    partial class ConfirmPayment
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
            this.textBoxPaymentCashmemo = new System.Windows.Forms.TextBox();
            this.labelPaymentCashmemo = new System.Windows.Forms.Label();
            this.labelValid = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelCashMemoSummary = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPaymentCashmemo
            // 
            this.textBoxPaymentCashmemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPaymentCashmemo.Location = new System.Drawing.Point(223, 132);
            this.textBoxPaymentCashmemo.Name = "textBoxPaymentCashmemo";
            this.textBoxPaymentCashmemo.Size = new System.Drawing.Size(150, 20);
            this.textBoxPaymentCashmemo.TabIndex = 0;
            this.textBoxPaymentCashmemo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPaymentCashmemo_KeyPress);
            // 
            // labelPaymentCashmemo
            // 
            this.labelPaymentCashmemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPaymentCashmemo.AutoSize = true;
            this.labelPaymentCashmemo.ForeColor = System.Drawing.Color.Red;
            this.labelPaymentCashmemo.Location = new System.Drawing.Point(114, 135);
            this.labelPaymentCashmemo.Name = "labelPaymentCashmemo";
            this.labelPaymentCashmemo.Size = new System.Drawing.Size(107, 13);
            this.labelPaymentCashmemo.TabIndex = 1;
            this.labelPaymentCashmemo.Text = "Payment Cash Memo";
            // 
            // labelValid
            // 
            this.labelValid.AutoSize = true;
            this.labelValid.Location = new System.Drawing.Point(231, 13);
            this.labelValid.Name = "labelValid";
            this.labelValid.Size = new System.Drawing.Size(0, 13);
            this.labelValid.TabIndex = 2;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(303, 158);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(69, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(222, 158);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(69, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelCashMemoSummary
            // 
            this.labelCashMemoSummary.AutoSize = true;
            this.labelCashMemoSummary.Location = new System.Drawing.Point(13, 13);
            this.labelCashMemoSummary.Name = "labelCashMemoSummary";
            this.labelCashMemoSummary.Size = new System.Drawing.Size(212, 13);
            this.labelCashMemoSummary.TabIndex = 6;
            this.labelCashMemoSummary.Text = "Enter Cash Memo with Following Particulars";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.Location = new System.Drawing.Point(12, 29);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(360, 97);
            this.dataGridView.TabIndex = 7;
            // 
            // ConfirmPayment
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(385, 190);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.labelCashMemoSummary);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelValid);
            this.Controls.Add(this.labelPaymentCashmemo);
            this.Controls.Add(this.textBoxPaymentCashmemo);
            this.Name = "ConfirmPayment";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirm Payment";
            this.Load += new System.EventHandler(this.ConfirmPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPaymentCashmemo;
        private System.Windows.Forms.Label labelPaymentCashmemo;
        private System.Windows.Forms.Label labelValid;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelCashMemoSummary;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}