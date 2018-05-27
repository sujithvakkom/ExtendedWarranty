using System;
using System.Windows.Forms;
using MyExtentions.Controls.MessageBoxExtentions;

namespace StartUpProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DetailedDialog dia = new DetailedDialog(new PropertyGrid())
            {
                Text = "Detailed Dialog",
                Message="Message Summary",
                Details ="Detailed Message",
                StartPosition=FormStartPosition.CenterParent
            };
            dia.ShowDialog();
        }
    }
}
