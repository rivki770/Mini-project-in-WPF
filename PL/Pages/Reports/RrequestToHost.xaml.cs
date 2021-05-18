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

namespace PL.Pages.Reports
{
    /// <summary>
    /// Interaction logic for RrequestToHost.xaml
    /// </summary>
    public partial class RrequestToHost : PageBase
    {
        public RrequestToHost()
        {
            InitializeComponent();
            FillList();
        }
        private void FillList()
        {

            var unitKeys = app.GetHostingUnits(c => c.OwnerId == OwnerId).Select(c => c.stSerialKey).ToArray(); //מקבל יחידות אירוח של המארח
            //var list2 = app.GetOrders(c => unitKeys.Contains(c.HostingUnitKey)).ToList(); //בודק איזה הזמנות קשורות ליחידות של המארח
            var list = app.GetFullOrder(c => unitKeys.Contains(c.HostingUnitKey)).ToList();
            
            ListRequests.ItemsSource = list;
        }

    }

}
