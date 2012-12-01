using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthenticationServer.Models.Services;
using AuthenticationServer.Models.Domain;

namespace AuthenticationServer.Models.Business
{
    /**
    * Manager
    Layer Super-Type Implementation*/
    public class AuthenticationManager
    {
        private Factory factory = Factory.GetInstance();

        protected IService GetService(String name)
        {

            return factory.GetService(name);
        }

        public Boolean ISValidCredentials(Credentials credential)
        {

            IAuthenticationSvc svc = (IAuthenticationSvc)GetService(typeof(IAuthenticationSvc).Name);
            return svc.isValidCredentials(credential.Username, credential.Password);

        }

    }


    
}