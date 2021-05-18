using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    [Serializable()]
    public class Host
    {
        public Host()
        {
            RelatedHostingUnit = new List<HostingUnit>();
        }

        int _Id;
        string _HostKey;
        string _FirstName;
        string _LastName;
        string _PhonePre;
        string _PhoneExt;
        string _MailAddress;
        string _Password;
        int _Discount;
        int _BankNumber;
        int _BranchNumber;
        int _BankAccount;
        bool _CollectionClearance;

        public int Id { get => _Id; set => _Id = value; }
        public string HostKey { get => _HostKey; set => _HostKey = value; }
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public string LastName { get => _LastName; set => _LastName = value; }

        [XmlIgnore]
        public string FullName { get => FirstName + " " + LastName; }

        public string PhonePre { get => _PhonePre; set => _PhonePre = value; }
        public string PhoneExt { get => _PhoneExt; set => _PhoneExt = value; }
        
        [XmlIgnore]
        public string Phone { get => PhonePre + "-" + PhoneExt; }

        public string MailAddress { get => _MailAddress; set => _MailAddress = value; }
        public string Password { get => _Password; set => _Password = value; }
        public int Discount { get => _Discount; set => _Discount = value; }
        public int BankNumber { get => _BankNumber; set => _BankNumber = value; }
        public int BranchNumber { get => _BranchNumber; set => _BranchNumber = value; }
        public int BankAccount { get => _BankAccount; set => _BankAccount = value; }
        public bool CollectionClearance { get => _CollectionClearance; set => _CollectionClearance = value; }

        public override string ToString()
        {
            return (HostKey + ", " + FirstName + " " + LastName + "\n" + PhonePre + PhoneExt + ", " + MailAddress
                + "\n" + BankAccount.ToString() + "\nCollectionClearance: " + CollectionClearance);
        }
        

        [XmlIgnore]
        public BankBranch Branch { get => null; }
       
        [XmlIgnore]
        public List<HostingUnit> RelatedHostingUnit { get; set; }
        [XmlIgnore]
        public int NumHostingUnit { get => RelatedHostingUnit.Count; }
        
        
    }


  
 
}
