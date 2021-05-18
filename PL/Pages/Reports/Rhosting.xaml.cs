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

namespace PL.Pages.Reports
{
    /// <summary>
    /// Interaction logic for Rhost.xaml
    /// </summary>
    public partial class Rhosting : PageBase
    {
        public Rhosting()
        {
            InitializeComponent();
            FillList();
        }

        private void FillList()
        {
            int numRooms = 0;
            int.TryParse(NumRooms.Text, out numRooms);

            int SelectedAreaId = 0;
            int SelectedTypeId = 0;
            if (FilterArea.SelectedValue != null)
                int.TryParse(FilterArea.SelectedValue.ToString(), out SelectedAreaId);
            if (TypeHostingUnit.SelectedValue != null)
                int.TryParse(TypeHostingUnit.SelectedValue.ToString(), out SelectedTypeId);

            //1 Get filters

            var list = app.GetHostingUnits(c => ((c.HostingUnitName == FilterName.Text || c.HostingUnitName == FilterName.Text) || c.HostingUnitName == FilterName.Text || FilterName.Text == "")
                    && (c.Rooms == numRooms || numRooms == 0)
                    && (c.AreaId == SelectedAreaId || SelectedAreaId == 0)
                    && (c.TypeId == SelectedTypeId || SelectedTypeId == 0)
                    && (c.OwnerId == OwnerId)
                );
           
            //2 Fill the list view

            ListRequests.ItemsSource = list;
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            FillList();
        }
    }
}
