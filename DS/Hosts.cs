using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class Hosts
    {
        public static List<Host> getHosts()
        {
            List<Host> hosts = new List<Host>();
            hosts.Add(new Host() { Id=1, FirstName = "אריה", LastName = "דהאן", PhonePre = "052", PhoneExt = "4564444", HostKey = "012456790", MailAddress = "1@nomail.com", Password="1111",  BankNumber=12, BranchNumber=558, BankAccount=123556, CollectionClearance= true });
            hosts.Add(new Host() { Id = 2, FirstName = "מאיר", LastName = "כהן", PhonePre = "054", PhoneExt = "4564444", HostKey = "001222567", MailAddress = "2@nomail.com", Password = "1111", CollectionClearance = true });
            hosts.Add(new Host() { Id = 3, FirstName = "יוסף שלמה", LastName = "ברינבאום", PhonePre = "03", PhoneExt = "4564444", HostKey = "041222567", MailAddress = "3@nomail.com",  Password="1111", BankNumber = 12, BranchNumber = 558, BankAccount = 123556 });
            hosts.Add(new Host() { Id = 4, FirstName = "חווה", LastName = "בוארון", PhonePre = "052", PhoneExt = "4564444", HostKey = "331222567", MailAddress = "4@nomail.com", Password = "1111" });
            return hosts;
        }

    }
}
