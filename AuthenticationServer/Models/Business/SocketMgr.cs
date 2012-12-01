using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using AuthenticationServer.Models.Services.Exceptions;

namespace AuthenticationServer.Models.Business
{
    public class SocketMgr:ConnectionMgr
    {
        private Boolean exit;   
   
	
    public SocketMgr(){}//default constructor
    
    
    /**method for testing if user login is correct */
    public void ValidateLogin() 
    {
       exit = true;
       try
       {
           this.CreateServerSocket();//creates server socket

           while (exit == true)
           {
               this.WaitForConnection(); //wait for a connection         

               //multithreaded connection management-----------------------------------
               ThreadMgr threadMgr = new ThreadMgr(this.GetSocket());
               Thread thread = new Thread(new ThreadStart(threadMgr.Run));
               thread.Name = "Socket Server";
               thread.Start();
               //-----------------------------------------
           }
       }
       catch (Exception e)
       {

           throw new ServerConnectionException(e.ToString());

       }
        
    }//end validate login method
    
    
    
    /**closes server connection */
       public void CloseServer() 
       {
            exit = false;           
            this.CloseConnection(); // close socket           
           
       }    


    }
}