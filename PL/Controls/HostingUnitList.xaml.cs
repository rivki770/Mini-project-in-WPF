using BE;
using BL;
using PL.Pages;
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
    /// Interaction logic for HostingUnitList.xaml
    /// </summary>
    public partial class HostingUnitList : UserControlBase
    {
        public Visibility DeleteVisible
        {
            get
            {
                if (OwnerId > 0) return System.Windows.Visibility.Visible;
                return Visibility.Collapsed;
            }
        }
     
        public string getButtonText
        {
            get
            {
                if (OwnerId > 0) return "עריכה";
                return "צפיה";
            }
        }
        private int ownId { get; set; }
        public HostingUnitList(int _ownId)
        {
            ownId = _ownId;
           
            InitializeComponent();
            FillGrid();

        }

        private void FillGrid()
        {

            var list = app.GetHostingUnits(c => c.OwnerId == ownId);
            HostingListGrid.DataContext = list;
            UnitHostListView.ItemsSource = list;
           
        }

        private void EditHostingUnit_Click(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            if (b != null)
            {
                int id = Int32.Parse(b.Tag.ToString());
                EditUnitHost uh = new EditUnitHost(id);
                MainNavigate(uh);
            }

        }


        private void DeleteHostingUnit_Click(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            if (b != null)
            {
                int id = Int32.Parse(b.Tag.ToString());
               bool ret =  app.DeleteHostingUnit(id);
               if (!ret)
               {
                   MessageBox.Show("לא ניתן למחוק יחידת אירוח בגלל הזמנות מקושרות");

               }
               else
               {
                   MessageBox.Show("נמחק בהצלחה");
                   FillGrid();
               }
            }

        }



    }
}
