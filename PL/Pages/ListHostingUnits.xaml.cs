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
using BE;
using PL.Controls;

namespace PL.Pages
{
    /// <summary>
    /// Interaction logic for ListHostingUnits.xaml
    /// </summary>
    public partial class ListHostingUnits : PageBase
    {
        public ListHostingUnits()
        {
            InitializeComponent();
           
            HostingUnitList hostingListCtrl = new HostingUnitList(OwnerId);
            hostingList.Children.Add(hostingListCtrl);
        }
        private void NewHostingUnit_Click(object sender, RoutedEventArgs e)
        {
            EditUnitHost uh = new EditUnitHost();
            MainNavigate(uh);

        }
        

        //private void ComboBoxItem_Selected(object sender, RoutedEventArgs e) //לחיצה על לפי אזורים
        //{
        //    MessageBox.Show("group לפי אזורים");
        //}

        //private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("group לפי מארחים");
        //}

        //private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("group לפי מס' חדרים");
        //}

        //private void ComboBoxItem_Selected_3(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("group לפי תאריכים");
        //}

        //private void ComboBoxItem_Selected_4(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("כל היחידות");
        //}

    
    }
}
