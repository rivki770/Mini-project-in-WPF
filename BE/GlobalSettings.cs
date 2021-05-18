using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GlobalSettings
    {
        string _ContactMail;
        string _OrderMailText;
        string _OrderMailSubject;
        int _PayForDay;

        public string ContactMail { get => _ContactMail; set => _ContactMail = value; }
        public string OrderMailText { get => _OrderMailText; set => _OrderMailText = value; }
        public string OrderMailSubject { get => _OrderMailSubject; set => _OrderMailSubject = value; }
        public int PayForDay { get => _PayForDay; set => _PayForDay = value; }
    }
}
