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
using PL.Pages.Reports;

namespace PL.Pages
{
    /// <summary>
    /// Interaction logic for ReportToHost.xaml
    /// </summary>
    public partial class ReportToHost : PageBase
    {
        public ReportToHost()
        {
            InitializeComponent();
            initRequestReport();
        }


        private void initRequestReport()
        {
            RrequestToHost rrequestToHost = new RrequestToHost();
            ReportFrame.Content = rrequestToHost;
            GridCursor.Margin = new Thickness(0, 0, 0, 0);
        }
        private void RequestButtonClick_Click_1(object sender, RoutedEventArgs e)
        {
            initRequestReport();
        }

        private void HostingButtonClick_Click_1(object sender, RoutedEventArgs e)
        {
            Rhosting rhost = new Rhosting();
            ReportFrame.Content = rhost;
            GridCursor.Margin = new Thickness(150, 0, 0, 0);
        }
    }
}
