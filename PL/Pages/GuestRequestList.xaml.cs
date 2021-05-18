using BE;
using PL.Controls;
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
    /// Interaction logic for GuestRequestList.xaml
    /// </summary>
    public partial class GuestRequestList : PageBase
    {
      

     
        public List<GuestRequest> RequestsList { get; set; }
        public GuestRequestList()
        {

            RequestsList = app.GetRequestsThatRelevantForOwner(c => c.Status == Enums.GuestRequestStatus.Opened || c.Status == Enums.GuestRequestStatus.InProccess, OwnerId);
           
            InitializeComponent();
            int counter = RequestsList.Count();
            CurrentWindow.setBadge(counter);
            FillGrid();
        }


        private void FillGrid()
        {
            GuestRequestListGrid.DataContext = RequestsList;
            for (int i = 0; i < RequestsList.Count; i++)
            {
                GuestRequestListItem reqCtrl = new GuestRequestListItem(RequestsList[i]);
                GuestRequestListGrid.Children.Add(reqCtrl);
                GuestRequestListGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(165) });
                Grid.SetRow(reqCtrl, i);
            }
        }

    }
}
