using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;
using System.Reflection;
using AuthenticationServer.Models.Services.Exceptions;



namespace AuthenticationServer.Models.Services
{

    /*
    * Author: Kedrian James
    * Decoupled Factory for instantiating services   
    */

    public class Factory
    {
        //singleton implementation of factory-----------------
        private Factory() { }
        private static Factory factory = new Factory();
        public static Factory GetInstance() { return factory; }
        //----------------------------------------------------

        //Here is the  call to initialize the log object
        //private static readonly log4net.ILog log =
        //log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //method for loading and returning service
        public IService GetService(String serviceName)
        {

            //logger Configuration here----------------
            // log4net.Config.XmlConfigurator.Configure();
            //------------------------------------------

            Type type;
            Object serviceObj = null;

            try
            {
                //log.Info("Attempting to look up service");

                //looks up service via name
                type = Type.GetType(GetImplName(serviceName));
                //creates an instance of the service
                serviceObj = Activator.CreateInstance(type);

                // log.Info("Service Look-up Successful");
            }
            catch (Exception e)
            {
                //if service not found or load error, service load
                //exception is thrown
                //log.Error("Service Look-up Failed: "+e.ToString());
                throw new ServiceLoadException("Error Loading Service: " + e.Message);

            }
            return (IService)serviceObj;//returns instance of service

        }//---------------------------------------------------------------------------------

        //private helper method for service look-up--------
        private string GetImplName(string serviceName)
        {
            string svcName = null;
            NameValueCollection settings = null;
            try
            {
                settings = ConfigurationManager.AppSettings;
                svcName = settings.Get(serviceName);
                // log.Info("Configurtion file sucessfully read");
            }
            catch (ConfigurationErrorsException e)
            {
                //log.Error("Service Look-up Failed: " + e.ToString());
                throw new ServiceLoadException("Error Loading Service: " + settings.Count + e.Message);
            }

            return svcName;
        }//------------------------------------------------
    }
}
