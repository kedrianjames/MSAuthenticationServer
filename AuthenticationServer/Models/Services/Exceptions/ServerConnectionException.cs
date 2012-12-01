using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationServer.Models.Services.Exceptions
{
    public class ServerConnectionException:Exception
    {
        public ServerConnectionException(String s)
                : base(s)
            {

            }
    }
}