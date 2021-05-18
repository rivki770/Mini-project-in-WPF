using BE;
using BL;
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
    /// Interaction logic for HostList.xaml
    /// </summary>
    public partial class HostList : PageBase
    {
       

        public List<Host> HostsList { get; set; }
        public HostList()
        {
            InitializeComponent();
            HostsList = app.GetAllHosts();
            FillGrid();
        }

        public void Refresh()
        {
            FillGrid();
        }

        private void FillGrid()
        {
            HostsGrid.DataContext = HostsList;
            for (int i = 0; i < HostsList.Count; i++)
            {
                UnitHost hostCtrl = new UnitHost(HostsList[i]);
                HostsGrid.Children.Add(hostCtrl);
                HostsGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50) });
                Grid.SetRow(hostCtrl, i + 1);
            }
        }

        private void AddHost_Click(object sender, RoutedEventArgs e)
        {

            EditHost hostPage = new EditHost(new Host());
            MainNavigate(hostPage);
           



        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {


            BackToMain();
            //(App.Current.MainWindow as MainWindow).Show();

        }
    }
}
