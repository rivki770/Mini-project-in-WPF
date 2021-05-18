using BE;
using System;
namespace BL
{
    public interface IAuth
    {
        Enums.AuthPermission Login(string user, string password, out BE.Enums.LoginStatus status, out int OwnerId);
    }
}
