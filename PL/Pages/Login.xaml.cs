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
using Ninject;
using BE;

namespace PL.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : PageBase
    {
        protected IAuth auth;
        public Login( )
        {
          
            this.auth = IoC.Kernel.Get<IAuth>();
            InitializeComponent();

            switch (CurrentWindow.Auth)
            {
                case Enums.AuthPermission.Guest:
                    
                    break;
                case Enums.AuthPermission.Host:
                    GuestPanel.Visibility = System.Windows.Visibility.Hidden;
                    LoggedinPanel.Visibility = System.Windows.Visibility.Visible;
                    Username.Text = CurrentUser.Name;
                    break;
                case Enums.AuthPermission.Admin:
                     GuestPanel.Visibility = System.Windows.Visibility.Hidden;
                    LoggedinPanel.Visibility = System.Windows.Visibility.Visible;
                    Username.Text =  CurrentUser.Name;
                    break;
                default:
                    break;
            }
        }

        private void QuickAdmin_Click(object sender, RoutedEventArgs e)
        {
            BackToMain();
            CheckLogin("admin", "admin");
        }

        private void QuickHoster_Click(object sender, RoutedEventArgs e)
        {
            BackToMain();
            CheckLogin("1@nomail.com", "1111");
        }
        private void CheckLogin (string mail, string pass){
             Enums.LoginStatus status ;
             int OwnerId ;
               var permission = auth.Login(mail, pass , out status, out OwnerId);

              switch (status)
            {
                case Enums.LoginStatus.Success:
                    break;
                case Enums.LoginStatus.Faild:
                    MessageBox.Show("שם או סיסמא שגויים");
                    return;
                case Enums.LoginStatus.Missing:
                    MessageBox.Show("יש להכניס שם או סיסמא");
                    return;
                default:
                    break;
            }

            CurrentUser = null;
            CurrentWindow.OwnerId = OwnerId;
            CurrentWindow.Auth = permission;

         }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {


            CheckLogin(EmailTxt.Text, PasswordText.Password);
         

           
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            BackToMain();
            CurrentUser = null;
            CurrentWindow.OwnerId = 0;
            CurrentWindow.Auth =  Enums.AuthPermission.Guest;
        }
        


    }
}
