using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Sockets;
using AuthenticationServer.Models.Domain;
using AuthenticationServer.Models.Services.Exceptions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
using System.IO;

namespace AuthenticationServer.Models.Business
{

    public class ThreadMgr
    {
        private Socket socket; // connection to client   
        NetworkStream stream = null;

        public ThreadMgr(Socket socket)
        {
            this.socket = socket;
            //= new NetworkStream(socket);

        }


        public void Run()
        {
        try
        {        
            
           stream = new NetworkStream(socket); // set up stream for objects
           
           //------------------------
           Credentials credential = new Credentials();
           Boolean valid = false;
           AuthenticationManager authenticationMgr = new AuthenticationManager();
           //-------------------------------------------------------------

            //receive and desearilize object
           
          // BinaryFormatter bf = new BinaryFormatter();
           BinaryReader reader = new BinaryReader(stream);
           BinaryWriter writer = new BinaryWriter(stream);
          // bf.AssemblyFormat = FormatterAssemblyStyle.Simple;
          // object cred = bf.Deserialize(stream);
          // credential = cred as Credentials;
           char[] delimiterChars = { '\t' };
           string cred = reader.ReadString();
           string[] words = cred.Split(delimiterChars);
           string username = words[0];
           string password = words[1];

           credential.Username = username;
           credential.Password = password;
            //--------------------------------------------

                                 
            lock(credential) 
           {          
              valid = authenticationMgr.ISValidCredentials(credential);                    
            }

            
           writer.Write(valid);
           CloseConnection();//closes connection
         
        }
        
        catch(Exception e)
        {
            throw new ServerConnectionException(e.ToString());
        }
    }

        protected void CloseConnection()
        {
            if (socket != null)
                socket.Close();  // close client

            if (stream != null)
                stream.Close();  // stop listener
        }
    }
}