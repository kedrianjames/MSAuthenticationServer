using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security.Principal;
namespace AuthenticationServer.Models.Services
{
    public class AuthenticationSvcSocketImpl : IAuthenticationSvc
    {
        //validates a user
        public Boolean isValidCredentials(string Username, string Password)
        {
            if (Membership.ValidateUser(Username, Password) == true) return true;

            return false;

        }
    }
}