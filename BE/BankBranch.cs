using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankBranch
    {

        int _BankNumber;
        string _BankName;
        int _BranchNumber;
        string _BranchName;
        string _BranchAddress;
        string _BranchCity;

        public int BankNumber { get => _BankNumber; set => _BankNumber = value; }
        public string BankName { get => _BankName; set => _BankName = value; }
        public int BranchNumber { get => _BranchNumber; set => _BranchNumber = value; }
        public string BranchName { get => _BranchName; set => _BranchName = value; }
        public string BranchAddress { get => _BranchAddress; set => _BranchAddress = value; }
        public string BranchCity { get => _BranchCity; set => _BranchCity = value; }

        public string BranchNameAndNum
        {
            get
            {
                return BranchName + " | " + BranchNumber;
            }
        }
        
        public override string ToString()
        {
            return "Bank Name: " + BankName.ToString() + " - " + BankNumber + ", BranchNumber:  " + BranchNumber
                + "\n BranchName: " + BranchAddress + ", " + BranchCity;
        }
    }
}
