using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DS
{
    public class Banks
    {

        public static List<Bank> getAllBanks()
        {

            List<Bank> list = new List<Bank>();
            list.Add(new Bank() { BankName = "בנק אגוד לישראל בעמ", BankCode = 13 });
            list.Add(new Bank() { BankName = "בנק אוצר החייל בעמ", BankCode = 14 });
            list.Add(new Bank() { BankName = "בנק דיסקונט לישראל בעמ", BankCode = 11 });
            list.Add(new Bank() { BankName = "בנק דקסיה ישראל בעמ", BankCode = 68 });
            list.Add(new Bank() { BankName = "בנק הפועלים בעמ", BankCode = 12 });
            list.Add(new Bank() { BankName = "בנק יהב לעובדי מדינה בעמ", BankCode = 4 });
            list.Add(new Bank() { BankName = "בנק ירושלים בעמ", BankCode = 54 });
            list.Add(new Bank() { BankName = "בנק לאומי לישראל בעמ", BankCode = 10 });
            list.Add(new Bank() { BankName = "בנק מזרחי טפחות בעמ", BankCode = 20 });
            list.Add(new Bank() { BankName = "בנק מסד בעמ", BankCode = 46 });
            list.Add(new Bank() { BankName = "בנק מרכנתיל דיסקונט בעמ", BankCode = 17 });
            list.Add(new Bank() { BankName = "בנק ערבי ישראל בעמ", BankCode = 34 });
            list.Add(new Bank() { BankName = "בנק פועלי אגודת ישראל בעמ", BankCode = 52 });
            list.Add(new Bank() { BankName = "בנק הבינלאומי הראשון לישראל בעמ", BankCode = 31 });
            list.Add(new Bank() { BankName = "יובנק בעמ", BankCode = 26 });
            // Add all missing banks
            return list;
        }
    }
}
