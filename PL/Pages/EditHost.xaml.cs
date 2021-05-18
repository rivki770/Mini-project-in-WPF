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
    /// Interaction logic for EditHost.xaml
    /// </summary>
    public partial class EditHost : PageBase
    {
        public Host CurrHost { get; set; }
        public List<string> PhonePreList { get; set; }
        public EditHost(Host _curr)
        { 
            PhonePreList = app.GetPrePhones();
            this.CurrHost = _curr;
            InitializeComponent();

            hostEditGrid.DataContext = CurrHost;
            prePhoneCb.ItemsSource = PhonePreList;
            if (CurrHost.Id > 0) //אם המדובר על עריכה
            {
                IdTxt.IsEnabled = false;
                EmailTxt.IsEnabled = false;
            }
            else //מדובר על רשומה חדשה
            {
                UnitHostButton.Visibility = System.Windows.Visibility.Hidden;
            }

            BankBranchSelector bs = new BankBranchSelector( CurrHost);
            hostEditGrid.Children.Add(bs);
            bs.Margin = new Thickness(10, 15, 0, 0);
            Grid.SetColumn(bs, 1);
            Grid.SetRow(bs, 7);


            HostingUnitList hostingListCtrl = new HostingUnitList(CurrHost.Id);
            hostingList.Children.Add(hostingListCtrl);
        }


     
       

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var state = Enums.HostValidationStatus.Success;
            if (CurrHost.Id > 0)
            {
                app.UpdateHost(CurrHost, out state);
            }
            else
            {
                app.AddHost(CurrHost, out state);
            }

            if (state != Enums.HostValidationStatus.Success)
            {
                string ErrorMessage = "";
                switch (state)
                {

                    case Enums.HostValidationStatus.MissingFields:
                        ErrorMessage = "יש למלא שדות חובה";
                        break;
                    case Enums.HostValidationStatus.DuplicateId:
                        ErrorMessage = "תעודת זהות קיימת כבר במערכת";
                        break;
                    case Enums.HostValidationStatus.WrongFields:
                        ErrorMessage = "מבנה שדות שגויים";
                        break;
                    case Enums.HostValidationStatus.HasActiveHostingUnits:
                        break;
                    case Enums.HostValidationStatus.Faild:
                        ErrorMessage = " שגיאת מסד";
                        break;
                    case Enums.HostValidationStatus.WrongId:
                        ErrorMessage = " תעודת זהות צריך להכיל 9 תווים";
                        break;
                    case Enums.HostValidationStatus.MissingBankAccount:
                        ErrorMessage = "חובה להכניס נתוני חשבון";
                        break;
                    case Enums.HostValidationStatus.EmailExist:
                        ErrorMessage = "האימייל קיים במערכת";
                        break;
                    default:
                        break;
                }
                MessageBox.Show(ErrorMessage, "שגיאה");
            }
            else
            {
                

                BackToList();
            }


        }


        private void ShowPanel_Click(object sender, RoutedEventArgs e)
        {


            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (150 * index), 0, 0, 0);

            switch(index)
            {
                case 0:
                    hostEditGrid.Visibility = System.Windows.Visibility.Visible;
                    hostingList.Visibility = System.Windows.Visibility.Hidden;
                    break;
                case 1:
                    hostEditGrid.Visibility = System.Windows.Visibility.Hidden;
                    hostingList.Visibility = System.Windows.Visibility.Visible;
                    break;
                case 2:
                    BackToList();
                    break;
               
            }
        }


        private void BackToList_Click(object sender, RoutedEventArgs e)
        {
            BackToList();
        }
        

        private void BackToList()
        {


            Pages.HostList hostListPage = new Pages.HostList();
            MainNavigate(hostListPage);

        }
    }
}
