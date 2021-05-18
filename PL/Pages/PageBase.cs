using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Ninject;
using BE;

namespace PL.Pages
{
    public class PageBase : Page
    {
        protected IAppLogic app;

        public Enums.AuthPermission Auth
        {
            get
            {
                return CurrentWindow.Auth;
            }
            set
            {
                CurrentWindow.Auth = value;
            }
        }

        public int OwnerId {

            get
            {
                return CurrentWindow.OwnerId;
            }
            set
            {
                CurrentWindow.OwnerId = value;
            }
        }
        private User currentUser;
        public User CurrentUser
        {
            get
            {
                if (currentUser == null)
                {
                    switch (Auth)
                    {
                        case Enums.AuthPermission.Guest:
                            break;
                        case Enums.AuthPermission.Host:
                            var host = app.GetHostById(OwnerId);
                            if (host != null)
                            {
                                currentUser = new User(){ Name = host.FullName, RelatedHost = host};
                            }
                            break;
                        case Enums.AuthPermission.Admin:
                            currentUser = new User() { Name = "Admin" };
                            break;
                        default:
                            break;
                    }
                }
                return currentUser;
            }
            set
            {
                currentUser = value;
            }
        }

        public  MainWindow CurrentWindow{
            get{
                return (App.Current.MainWindow as MainWindow);
            }
        }

        

 
        
        public PageBase()
        {
            var _app = IoC.Kernel.Get<IAppLogic>();
            this.app = _app;
        }


        public void MainNavigate(PageBase p)
        {
            CurrentWindow.MainFrame.Content = p;
        }

        public void BackToMain(){
            Pages.Main main = new Pages.Main();
            MainNavigate(main);
          
        }


       
    }
}
