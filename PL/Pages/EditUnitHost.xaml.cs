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
    /// Interaction logic for EditUnitHost.xaml
    /// </summary>
    public partial class EditUnitHost : PageBase
    {
        protected HostingUnit CurrentHU { get; set; }
        public EditUnitHost(int id = 0)
        {
            string[] months = new string[]{ "ינו", "פבר", "מרץ", "אפר", "מאי", "יונ", "יול", "אוג", "ספט", "אוק", "נוב", "דצמ" };
            if (id > 0)
            {
                CurrentHU = app.GetHostingUnitById(id);
           
            }
            else
            {
                CurrentHU = new HostingUnit();
                CurrentHU.OwnerId = OwnerId;
                CurrentHU.Status = Enums.HosignUnitStatus.Active;
            }
            InitializeComponent();
            hostEditGrid.DataContext = CurrentHU;
            if (OwnerId == 0)
            {
                SaveChangeButton.Visibility =  System.Windows.Visibility.Hidden;
            }
            for (int i = 0; i <= 31; i++)
            {
                calendarGrid.ColumnDefinitions.Add(new ColumnDefinition());

            }

            ImageGalleryCtrl ic = new ImageGalleryCtrl(CurrentHU);
            GalleryGrid.Children.Add(ic);

            for (int i = 0; i < 12; i++)
            {
                var rowDefinition = new RowDefinition();
                //rowDefinition.Height = GridLength.Auto;
                rowDefinition.Height = new GridLength(40);
                calendarGrid.RowDefinitions.Add(rowDefinition);
                Label l = new Label();
                l.Height = 30;
                l.Content = months[i];
                calendarGrid.Children.Add(l);
                Grid.SetRow(l, i);
                Grid.SetColumn(l, 0);
            }
        

            for (DateTime date = new DateTime(2020, 1,1); date <  new DateTime(2021, 1,1); date = date.AddDays(1))
            {
                Label l = new Label();
                l.Content = date.ToString("dd");
                l.Height = 30;
                calendarGrid.Children.Add(l);
                Grid.SetRow(l, date.Month -1);
                Grid.SetColumn(l, date.Day );
                var exist = CurrentHU.Days.Where(c => c.Date.Date == date.Date).FirstOrDefault();
                if (exist != null)
                {
                    l.Foreground = new SolidColorBrush(Colors.Blue);
                    l.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    l.Foreground = new SolidColorBrush(Colors.Gray);
                }

            }


        }


        private void ShowPanel_Click(object sender, RoutedEventArgs e)
        {


            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (150 * index), 0, 0, 0);

            switch (index)
            {
                case 0:
                    hostEditGrid.Visibility = System.Windows.Visibility.Visible;
                    calendarGrid.Visibility = System.Windows.Visibility.Hidden;
                    GalleryGrid.Visibility = System.Windows.Visibility.Hidden;
                    break;
                case 1:
                    hostEditGrid.Visibility = System.Windows.Visibility.Hidden;
                    calendarGrid.Visibility = System.Windows.Visibility.Visible;
                    GalleryGrid.Visibility = System.Windows.Visibility.Hidden;

                    break;
                case 2:
                     hostEditGrid.Visibility = System.Windows.Visibility.Hidden;
                    calendarGrid.Visibility = System.Windows.Visibility.Hidden;
                    GalleryGrid.Visibility = System.Windows.Visibility.Visible;
                    break;

            }
        }


        private void BackToList_Click(object sender, RoutedEventArgs e)
        {
            if (OwnerId > 0)
            {
                ListHostingUnits lhpage = new ListHostingUnits();
                MainNavigate(lhpage);
            }
            else
            {
                //is admin
                var parenthost = app.GetHostById(CurrentHU.OwnerId);
                EditHost hostpage = new EditHost(parenthost);
                MainNavigate(hostpage);
            }
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Enums.HostingUnitSaveStatus status;
            if (CurrentHU.stSerialKey == 0)
                app.AddHostingUnit(CurrentHU, out status);
            else
                app.UpdatingHostingUnit(CurrentHU, out status);

            switch (status)
            {
                case Enums.HostingUnitSaveStatus.Success:
                    MessageBox.Show("נשמר בהצלחה");
                    ListHostingUnits lhpage = new ListHostingUnits();
                    
                        var RequestsList = app.GetRequestsThatRelevantForOwner(c => c.Status == Enums.GuestRequestStatus.Opened || c.Status == Enums.GuestRequestStatus.InProccess, OwnerId);
                        int counter = RequestsList.Count();
                        CurrentWindow.setBadge(counter);
                    
                    MainNavigate(lhpage);
                    break;
                case Enums.HostingUnitSaveStatus.MissingFields:
                    MessageBox.Show("שדות חובה חסרים או שגויים");
                    break;
                case Enums.HostingUnitSaveStatus.ImageMissing:
                   
                    break;
                default:
                    break;
            }

        }



    }
}
