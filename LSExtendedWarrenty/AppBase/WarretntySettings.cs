using System;
using System.Collections.Generic;
using System.Text;

namespace LSExtendedWarrenty.AppBase
{
    public struct WarretntySettings
    {
        public int NumberOfYears { get; set; }
        public int WarrentyPercentage { get; set; }
        public int Brand { get; set; }
        public String PaymentItem { get; set; }
    }
}
