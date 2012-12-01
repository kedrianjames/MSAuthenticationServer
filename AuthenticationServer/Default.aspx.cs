using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuthenticationServer.Models.Business;

namespace AuthenticationServer
{
    public partial class _Default : System.Web.UI.Page
    {
        SocketMgr socketMgr = new SocketMgr();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                Button1.Text = "Server Started";
                socketMgr.ValidateLogin();
               
            }
            catch(Exception ex)
            {
                Label1.Text = ex.ToString();
            }

           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {

                socketMgr.CloseServer();
                Button2.Text = "Server Stopped";
                
            }
            catch (Exception ex)
            {
                Label2.Text = ex.ToString();
            }

        }
    }
}
