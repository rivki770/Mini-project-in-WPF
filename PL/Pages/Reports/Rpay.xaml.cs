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
    /// Interaction logic for Rpay.xaml
    /// </summary>
    public partial class Rpay : PageBase
    {
        public Rpay()
        {
            var list = app.GetAllHosts();
            InitializeComponent();
            ListRequestsHost.ItemsSource = list;
        }

        private void ListRequestsHost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


       
    }
}
