using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contact
    {
        string _Subjec;
        string _Body;
        string _SenderMail;
        string _ReciverMail;

        public string Subject { get => _Subjec; set => _Subjec = value; }
        public string Body { get => _Body; set => _Body = value; }
        public string SenderMail { get => _SenderMail; set => _SenderMail = value; }
        public string ReciverMail { get => _ReciverMail; set => _ReciverMail = value; }
    }
}
