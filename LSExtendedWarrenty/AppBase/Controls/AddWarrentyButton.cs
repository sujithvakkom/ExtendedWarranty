using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LSExtendedWarrenty.AppBase.Controls
{
    class AddWarrentyButton:Button
    {
        public AddWarrentyButton()
            : base()
        {
            Item = null;
        }
        private RecieptItem _Item;
        public RecieptItem Item
        {
            get { return _Item; }
            set
            {
                _Item = value;

                if (_Item == null)
                {
                    this.Enabled = false;
                    this.Text = "Add Warranty";
                }
                else
                {

                    this.Enabled = true;
                    this.Text = "Add Warranty" + System.Environment.NewLine + _Item.Description;
                }
                this.Refresh();
            }
        }
    }
}
