using Microsoft.Reporting.WinForms;
namespace LSExtendedWarrenty
{
    partial class FormReciept
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.WarrentyItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.reportViewerWarrentySlip = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.WarrentyItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // WarrentyItemBindingSource
            // 
            this.WarrentyItemBindingSource.DataMember = "WarrentyItem";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(545, 591);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrint.Location = new System.Drawing.Point(464, 591);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 1;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // reportViewerWarrentySlip
            // 
            this.reportViewerWarrentySlip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "WarrentyItem";
            reportDataSource1.Value = this.WarrentyItemBindingSource;
            this.reportViewerWarrentySlip.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerWarrentySlip.LocalReport.ReportEmbeddedResource = "LSExtendedWarrenty.WarrentySlip.rdlc";
            this.reportViewerWarrentySlip.Location = new System.Drawing.Point(12, 12);
            this.reportViewerWarrentySlip.Name = "reportViewerWarrentySlip";
            this.reportViewerWarrentySlip.ShowBackButton = false;
            this.reportViewerWarrentySlip.ShowContextMenu = false;
            this.reportViewerWarrentySlip.ShowCredentialPrompts = false;
            this.reportViewerWarrentySlip.ShowDocumentMapButton = false;
            this.reportViewerWarrentySlip.ShowExportButton = false;
            this.reportViewerWarrentySlip.ShowFindControls = false;
            this.reportViewerWarrentySlip.ShowParameterPrompts = false;
            this.reportViewerWarrentySlip.ShowPrintButton = false;
            this.reportViewerWarrentySlip.ShowPromptAreaButton = false;
            this.reportViewerWarrentySlip.ShowToolBar = false;
            this.reportViewerWarrentySlip.ShowZoomControl = false;
            this.reportViewerWarrentySlip.Size = new System.Drawing.Size(608, 573);
            this.reportViewerWarrentySlip.TabIndex = 2;
            // 
            // FormReciept
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(632, 626);
            this.Controls.Add(this.reportViewerWarrentySlip);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReciept";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormReciept";
            this.Load += new System.EventHandler(this.FormReciept_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WarrentyItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonPrint;
        private ReportViewer reportViewerWarrentySlip;
        private System.Windows.Forms.BindingSource WarrentyItemBindingSource;
    }
}