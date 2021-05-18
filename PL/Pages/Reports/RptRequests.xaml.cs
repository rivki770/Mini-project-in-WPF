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
    /// Interaction logic for RptRequests.xaml
    /// </summary>
    public partial class RptRequests : PageBase
    {
        public RptRequests()
        {
            InitializeComponent();
            FillList();
        }
        private void FillList()
        {
            int SelectedStatusId = -1;
            int SelectedAreaId = 0;
            if (FilterArea.SelectedValue != null)
                int.TryParse(FilterArea.SelectedValue.ToString(), out SelectedAreaId);
            if (FilterStatus.SelectedValue != null)
                int.TryParse(FilterStatus.SelectedValue.ToString(), out SelectedStatusId);
            //1 Get filters
            var list = app.GetGuestRequests(
                c => ((c.LastName == FilterName.Text || c.FirstName == FilterName.Text) || c.FullName == FilterName.Text || FilterName.Text == "")
                    && (c.MailAddress == FilterEmail.Text || FilterEmail.Text == "")
                    && (c.AreaId == SelectedAreaId || SelectedAreaId == 0)
                    && (c.StatusId == SelectedStatusId || SelectedStatusId == -1)
                );

            //2 Fill the list view

            ListRequests.ItemsSource = list;
          

        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            FillList();
        }
        
    }
}
