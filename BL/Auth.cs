using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;  

namespace BL
{
    public class Auth : BL.IAuth
    {
        private IDal dal { get; set; }
        public Auth(IDal _dal)
        {
            dal = _dal;
        }


        public Enums.AuthPermission Login(string user, string password, out Enums.LoginStatus status, out int OwnerId)
        {
            OwnerId = 0;
            Enums.AuthPermission ret = Enums.AuthPermission.Guest;
            status = Enums.LoginStatus.Faild;
            //check for admin
            if (user == "admin")
            {
                var appSettingsPass = ConfigurationManager.AppSettings["AdminPasword"];
                if (password == appSettingsPass)
                {
                    status = Enums.LoginStatus.Success;
                    ret = Enums.AuthPermission.Admin;
                }
            }
            else
            {
                var owner =  dal.GetAllHosts(c=>c.Password == password && c.MailAddress == user).FirstOrDefault();
                if (owner != null)
                {
                    status = Enums.LoginStatus.Success;
                    ret = Enums.AuthPermission.Host;
                    OwnerId = owner.Id;
                }
            }
            return ret;
        }
    }
}
