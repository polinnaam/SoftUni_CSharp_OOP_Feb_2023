using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class Smartphone : IPhone
    {
        public string Calling(string phoneNumber)
        {
            return $"Calling... {phoneNumber}";
        }
        public string Browsing(string URL)
        {
            return $"Browsing: {URL}!";
        }
    }
}
