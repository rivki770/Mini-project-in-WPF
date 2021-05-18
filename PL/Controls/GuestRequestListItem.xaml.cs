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
    /// Interaction logic for GuestRequestListItem.xaml
    /// </summary>
   

    public partial class GuestRequestListItem : UserControlBase
    {

        public GuestRequest CurrGuestRequest { get; set; }
        public List<RelatedHosting> relatedHosting { get; set; }
      
        
        public GuestRequestListItem(GuestRequest _CurrGuestRequest)
        {
          
            this.CurrGuestRequest = _CurrGuestRequest;
         
            relatedHosting = app.GetRelevantHostingByRequest(CurrGuestRequest, OwnerId);
            InitializeComponent();
            GuestGrid.DataContext = CurrGuestRequest;


            lvUsers.ItemsSource = relatedHosting;

           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

       

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            if (b != null)
            {
                int id = Int32.Parse(b.Tag.ToString());

                Enums.OrderCreateStatus state;
                Order o = new Order();
                o.GuestRequestKey = CurrGuestRequest.GuestRequestsKey;
                o.HostingUnitKey = id;
                app.AddOrder(o, out state);
                string mess = "";
                switch (state)
                {
                    case Enums.OrderCreateStatus.MissingCollectionClearance:
                        mess = "יש לאשר חיוב חשבון לפני שליחת הזמנה";
                        break;
                    case Enums.OrderCreateStatus.Success:
                        mess = "המייל נשלח בהצלחה";
                        break;
                    case Enums.OrderCreateStatus.ErrorInDetails:
                        mess = "שגיאה";
                        break;
                    case Enums.OrderCreateStatus.MailFailed:
                        mess = "שגיאה";
                        break;
                    default:
                        break;
                }
                MessageBox.Show(mess);


                RefreshWindow();
                

            }
           
        }


        private void CompleteOrder_Click(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            if (b != null)
            {
                int orderid = Int32.Parse(b.Tag.ToString());

                bool success = app.UpdatingOrder(orderid, Enums.OrderStatus.Success);
                MessageBox.Show((success)?"ההזמנה בוצעה בהצלחה":"שגיאה");

                RefreshWindow();
               


            }

        }

        private void RefreshWindow()
        {

            Pages.GuestRequestList requestList = new Pages.GuestRequestList();
            MainNavigate(requestList);
        }


       
    }
}
