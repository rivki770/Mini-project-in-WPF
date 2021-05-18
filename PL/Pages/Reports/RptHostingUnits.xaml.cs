using BE;
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

namespace PL.Pages
{
    /// <summary>
    /// Interaction logic for RptRequests.xaml
    /// </summary>
    public partial class RptHostingUnits : PageBase
    {
        public RptHostingUnits()
        {
            InitializeComponent();
            FillList();
        }
        private void FillList()
        {
            int numRooms = 0;
            int.TryParse(NumRooms.Text, out numRooms);

            int SelectedAreaId = -1;
            int SelectedTypeId = -1;
            if (FilterArea.SelectedValue != null)
                int.TryParse(FilterArea.SelectedValue.ToString(), out SelectedAreaId);
            if (TypeHostingUnit.SelectedValue != null)
                int.TryParse(TypeHostingUnit.SelectedValue.ToString(), out SelectedTypeId);

            //1 Get filters
            var list = app.GetHostingUnitGrouingByOwner(
                c => ((c.HostingUnitName == FilterName.Text || c.HostingUnitName == FilterName.Text) || c.HostingUnitName == FilterName.Text || FilterName.Text == "")
                    && (c.Rooms == numRooms || numRooms == 0)
                    && (c.AreaId == SelectedAreaId || SelectedAreaId == -1)
                    && (c.TypeId == SelectedTypeId || SelectedTypeId == -1)
                );
            //2 Fill the list view
            ListHostings.ItemsSource = list;
           // ListRequests.ItemsSource = list;
          
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            FillList();
        }

       
        
    }
}
