using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LSExtendedWarrenty
{
    public partial class Authorize : Form
    {
        public Authorize()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            String password = "ADMIN"+DateTime.Now.ToString("ddMMyyyy");
            if (textBoxUserName.Text == "ADMIN" && textBoxPassword.Text == password)
            {
                this.DialogResult = DialogResult.Yes;
            }
            else this.DialogResult = DialogResult.No;
        }
    }
}
