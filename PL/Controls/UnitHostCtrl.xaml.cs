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
    /// Interaction logic for UnitHost.xaml
    /// </summary>
    public partial class UnitHost : UserControlBase
    {
        public Host CurrHost { get; set; }
      
        public UnitHost(Host _CurrHost)
        {
            this.CurrHost = _CurrHost;
            InitializeComponent();
            hostGrid.DataContext = CurrHost;
        }

        private void BindList(){
            
        }

        private void DeleteClick_Click(object sender, RoutedEventArgs e)
        {
            Enums.HostValidationStatus status = Enums.HostValidationStatus.Deleted;
            var b = (Button)sender;
            if (b != null)
            {
                int id = Int16.Parse( b.Tag.ToString());
                app.DeleteHost(id, out status);
                if (status == Enums.HostValidationStatus.HasActiveHostingUnits)
                {
                    MessageBox.Show("קיימות יחידות אירוח למארח");
                }
               // Window yourParentWindow = Window.GetWindow(this);
               // yourParentWindow.Close();
                Pages.HostList hostListPage = new Pages.HostList();
                MainNavigate(hostListPage);
                //hostListPage.Show();
                
                
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            if (b != null)
            {
                int id = Int16.Parse(b.Tag.ToString());
                 var h = app.GetHostById(id);
               

                //Window yourParentWindow = Window.GetWindow(this);
                //yourParentWindow.Close();
               // Pages.HostList hostListPage = new Pages.HostList();
               // MainNavigate(hostListPage);
                Pages.EditHost hostPage = new Pages.EditHost( h);
                MainNavigate(hostPage);
                //hostPage.ShowDialog();
               

            }
        }
    }
}
