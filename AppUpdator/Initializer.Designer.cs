namespace AppUpdator
{
    partial class Initializer
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
            this.labelSettingsServer = new System.Windows.Forms.Label();
            this.textBoxSettingsServer = new System.Windows.Forms.TextBox();
            this.labelSettingDB = new System.Windows.Forms.Label();
            this.textBoxDatabase = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelLocation = new System.Windows.Forms.Label();
            this.textBoxLoction = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonManualConfigure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSettingsServer
            // 
            this.labelSettingsServer.AutoSize = true;
            this.labelSettingsServer.Location = new System.Drawing.Point(9, 10);
            this.labelSettingsServer.Name = "labelSettingsServer";
            this.labelSettingsServer.Size = new System.Drawing.Size(79, 13);
            this.labelSettingsServer.TabIndex = 0;
            this.labelSettingsServer.Text = "Settings Server";
            // 
            // textBoxSettingsServer
            // 
            this.textBoxSettingsServer.Location = new System.Drawing.Point(105, 7);
            this.textBoxSettingsServer.Name = "textBoxSettingsServer";
            this.textBoxSettingsServer.Size = new System.Drawing.Size(167, 20);
            this.textBoxSettingsServer.TabIndex = 1;
            this.textBoxSettingsServer.Text = "GSLSR";
            // 
            // labelSettingDB
            // 
            this.labelSettingDB.AutoSize = true;
            this.labelSettingDB.Location = new System.Drawing.Point(35, 39);
            this.labelSettingDB.Name = "labelSettingDB";
            this.labelSettingDB.Size = new System.Drawing.Size(53, 13);
            this.labelSettingDB.TabIndex = 2;
            this.labelSettingDB.Text = "Database";
            // 
            // textBoxDatabase
            // 
            this.textBoxDatabase.Location = new System.Drawing.Point(105, 36);
            this.textBoxDatabase.Name = "textBoxDatabase";
            this.textBoxDatabase.Size = new System.Drawing.Size(167, 20);
            this.textBoxDatabase.TabIndex = 3;
            this.textBoxDatabase.Text = "Sitemanager";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(59, 68);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(29, 13);
            this.labelUser.TabIndex = 4;
            this.labelUser.Text = "User";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(105, 65);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(167, 20);
            this.textBoxUser.TabIndex = 5;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(35, 97);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(105, 94);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(167, 20);
            this.textBoxPassword.TabIndex = 7;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(40, 126);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(48, 13);
            this.labelLocation.TabIndex = 8;
            this.labelLocation.Text = "Location";
            // 
            // textBoxLoction
            // 
            this.textBoxLoction.Location = new System.Drawing.Point(105, 123);
            this.textBoxLoction.Name = "textBoxLoction";
            this.textBoxLoction.Size = new System.Drawing.Size(167, 20);
            this.textBoxLoction.TabIndex = 9;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(197, 149);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(116, 150);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonManualConfigure
            // 
            this.buttonManualConfigure.Location = new System.Drawing.Point(12, 150);
            this.buttonManualConfigure.Name = "buttonManualConfigure";
            this.buttonManualConfigure.Size = new System.Drawing.Size(98, 23);
            this.buttonManualConfigure.TabIndex = 12;
            this.buttonManualConfigure.Text = "Manual Configure";
            this.buttonManualConfigure.UseVisualStyleBackColor = true;
            this.buttonManualConfigure.Click += new System.EventHandler(this.buttonManualConfigure_Click);
            // 
            // Initializer
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(284, 181);
            this.Controls.Add(this.buttonManualConfigure);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxLoction);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.textBoxDatabase);
            this.Controls.Add(this.labelSettingDB);
            this.Controls.Add(this.textBoxSettingsServer);
            this.Controls.Add(this.labelSettingsServer);
            this.Name = "Initializer";
            this.Text = "Initializer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSettingsServer;
        private System.Windows.Forms.TextBox textBoxSettingsServer;
        private System.Windows.Forms.Label labelSettingDB;
        private System.Windows.Forms.TextBox textBoxDatabase;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.TextBox textBoxLoction;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonManualConfigure;
    }
}