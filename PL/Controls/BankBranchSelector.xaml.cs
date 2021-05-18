using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL.Controls
{
    /// <summary>
    /// Interaction logic for BankBranchSelector.xaml
    /// </summary>
    public partial class BankBranchSelector : UserControlBase
    {
        
        public Host CurrHost { get; set; }
        public List<Bank> BankList { get; set; }
        public List<Bank> BranchList { get; set; }
        public BankBranchSelector( Host _CurrHost)
        {
           
            this.CurrHost = _CurrHost;
            BankList = this.app.GetBanksList();
            InitializeComponent();
            BankBranchGrid.DataContext = CurrHost;
            BankCb.ItemsSource =BankList;
            BankCb.DisplayMemberPath = "BankName";
            BankCb.SelectedValuePath = "BankCode";
            BranchCb.DisplayMemberPath = "BranchNameAndNum";
            BranchCb.SelectedValuePath = "BranchNumber";
            ReloadBranches();




        }

        private void ReloadBranches()
        {
            if (CurrHost.BankNumber > 0)
            {
                BranchCb.IsEnabled = true;
              
                BranchCb.ItemsSource = app.GetBankBranchesByBank(CurrHost.BankNumber);
            }
            else
            {
                BranchCb.IsEnabled = false;
            }
            if(CurrHost.BranchNumber >0){
                BankAccountTxt.IsEnabled = true;
                 
            }
            else
            {
                BankAccountTxt.IsEnabled = false;
            }
        }

        private void BankCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReloadBranches();
        }

        private void Branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReloadBranches();
        }
    }
}
