using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthenticationServer.Models.Services;
using System.Net.Sockets;
using System.Net;
using AuthenticationServer.Models.Services.Exceptions;

namespace AuthenticationServer.Models.Business
{
    public abstract class ConnectionMgr
    {
      
      
        private Factory factory = Factory.GetInstance();//factory instance
        private TcpListener listener = null;//listener
        Int32 port = 8081;//port number
        IPAddress ipAddr = IPAddress.Parse("127.0.0.1");//IPAddress
        Socket socket = null;//socket


        /**method for returning service
   * dynamically loaded by factory 	 */
        protected IService GetService(String name)
        {

            return factory.GetService(name);
        }

       
        
        /**creates server socket/Listener for connection * */
        protected void CreateServerSocket() 
        {
            try
            {
                Console.Write("listener created... ");
                listener = new TcpListener(ipAddr, port); // create Listener  
                listener.Start();
            }
            catch (SocketException e)
            {
                throw new ServerConnectionException(e.ToString());
            }
        }
        
       
        /**waits for a connection from client
         *  */        
        protected void WaitForConnection()
        {
            try
            {
                Console.Write("Waiting for a connection... ");
                socket = listener.AcceptSocket();
            }
            catch (SocketException e)
            {
                throw new ServerConnectionException(e.ToString());
            }
                        
        }
    
        /**closes server connection
         *        
         */
        protected void CloseConnection()
        {
            if (socket != null)
                socket.Close();  // close client

            if (listener != null)
                listener.Stop();  // stop listener
        }
        
        /** returns socket
         *         
         */
        public Socket GetSocket()
        {
            return socket;
        }



    }
}