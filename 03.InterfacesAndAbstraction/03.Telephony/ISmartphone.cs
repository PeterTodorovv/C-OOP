using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public interface ISmartphone
    {
        public void MakeCall(string phoneNumber);
        public void BrowseTheWeb(string website);
    }
}
