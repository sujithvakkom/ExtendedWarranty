using System;
using System.Collections.Generic;
using System.Text;

namespace LSExtendedWarrenty.AppBase.DataHelper
{
    class NoWarrentySettingFoundException : Exception
    {

        public NoWarrentySettingFoundException(string Message, string InnerMessage)
            :base(Message,new Exception(InnerMessage))
        {

        }
    }
}
