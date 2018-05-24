using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace LSExtendedWarrenty.AppBase.RichTextBoxPrinter
{
    static class RichTextBoxExtensions
    {
        public static void Print(
            /*this */
            RichTextBox control, PageSettings page, PrinterSettings printer, ref Exception HelperException)
        {
            RichTextBoxPrintHelper helper = new RichTextBoxPrintHelper(control);
            helper.ApplyPageSettings(page);
            helper.ApplyPrintSettings(printer);
            helper.PrintRTF();
            HelperException = helper.GetHelperException();


        }
        public static void Preview(/*this*/ RichTextBox control, PageSettings page, PrinterSettings printer, ref Exception HelperException)
        {
            RichTextBoxPrintHelper helper = new RichTextBoxPrintHelper(control);
            helper.ApplyPageSettings(page);
            helper.ApplyPrintSettings(printer);
            helper.PreviewRTF();
            HelperException = helper.GetHelperException();

        }
    }
}
