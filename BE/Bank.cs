using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bank
    {
        string _BankName;
        int _BankCode;

        public string BankName { get => _BankName; set => _BankName = value; }
        public int BankCode { get => _BankCode; set => _BankCode = value; }
    }
}
