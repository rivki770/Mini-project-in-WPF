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
    /// Interaction logic for EditGuestRequest.xaml
    /// </summary>
    public partial class EditGuestRequest : PageBase
    {
        public GuestRequest CurrRequest { get; set; }
        public List<string> PhonePreList { get; set; }
        public EditGuestRequest()
        {
           
            CurrRequest = new GuestRequest();

            PhonePreList = app.GetPrePhones();
            InitializeComponent();
            GuestRequestGrid.DataContext = CurrRequest;
            prePhoneCb.ItemsSource = PhonePreList;



        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var state = Enums.GuestRequesteCreateStatus.Success;
            app.AddGusetRequest(CurrRequest, out state);

            if (state != Enums.GuestRequesteCreateStatus.Success)
            {
                string ErrorMessage = "";
                switch (state)
                {
                    case Enums.GuestRequesteCreateStatus.MissingFields:
                        ErrorMessage = "יש למלא שדות חובה";
                        break;
                    case Enums.GuestRequesteCreateStatus.WrongFields:
                        ErrorMessage = "מבנה שדות שגויים";
                        break;
                    case Enums.GuestRequesteCreateStatus.ErrorDates:
                        ErrorMessage = "יש לבדוק תאריכים";
                        break;
                    case Enums.GuestRequesteCreateStatus.NoHosting:
                        ErrorMessage = "המערכת לא מצאה יחידות אירוח מתאימים לתאריכים שצויינו, נסה בתאריכים נוספים";
                        break;
                    case Enums.GuestRequesteCreateStatus.Success:
                        break;
                    default:
                        break;
                }


                MessageBox.Show(ErrorMessage, "שגיאה");
            }
            else
            {
                if (OwnerId > 0)
                {
                    var RequestsList = app.GetRequestsThatRelevantForOwner(c => c.Status == Enums.GuestRequestStatus.Opened || c.Status == Enums.GuestRequestStatus.InProccess, OwnerId);
                    int counter = RequestsList.Count();
                    CurrentWindow.setBadge(counter);
                }
                MessageBox.Show("תודה רבה, בקשתך נקלטה במערכת", "הודעת מערכת");
                BackToMain();
                
            }


        }

        private void dpick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrRequest.ReleaseDate = CurrRequest.EntryDate.AddDays(7);
           // GuestRequestGrid.DataContext = CurrRequest;
            relatseDateCtrl.SelectedDate = CurrRequest.EntryDate.AddDays(7);
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
