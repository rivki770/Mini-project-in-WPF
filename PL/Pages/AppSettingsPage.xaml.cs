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
    /// Interaction logic for AppSettingsPage.xaml
    /// </summary>
    public partial class AppSettingsPage : PageBase
    {
        public GlobalSettings CurrSetting { get; set; }
        public AppSettingsPage()
        {
            CurrSetting = app.GetGlobalSettings();
            InitializeComponent();

            EditSettingsGrid.DataContext = CurrSetting;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            bool success = app.UpdateGlobalSettings(CurrSetting);

            if (!success)
            {

                MessageBox.Show("מבנה נתונים שגויים או חסרים");
            }
            else
            {

                MessageBox.Show("השינויים עודכנו במערכת");
                BackToMain();

            }


        }

    }
}
