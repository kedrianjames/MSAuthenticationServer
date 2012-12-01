using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationServer.Models.Services
{
    public interface IAuthenticationSvc:IService
    {
        Boolean isValidCredentials(string Username, string Password); 
    }
}