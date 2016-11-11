using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class loginproccessor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            if(Session["Username"] != null)
            {
                if (Convert.ToString(Session["Username"]) != HttpContext.Current.User.Identity.Name.ToString())
                {

                    Response.Redirect("~/Logout.aspx");
                }
            }
          

            String[] rolenames = new String[5];
            String rolename;
            String role;
            String Sessionid = Session.SessionID;
            
            SqlConnection con = new SqlConnection();
            SqlCommand cmdRole = new SqlCommand();
            rolenames = Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name);
            rolename = (String)rolenames.GetValue(0);
            con.ConnectionString = ConfigurationManager.AppSettings["ConnStr"];
            cmdRole.CommandType = CommandType.StoredProcedure;
            cmdRole.CommandText = "dbo.STP_GET_ROLE_ID";
            cmdRole.Connection = con;
            cmdRole.Parameters.Add(new SqlParameter("@RoleName", SqlDbType.VarChar, 50));
            cmdRole.Parameters["@RoleName"].Value = rolename;
            cmdRole.Parameters.Add(new SqlParameter("@RoleID", SqlDbType.VarChar, 100));
            cmdRole.Parameters["@RoleID"].Direction = ParameterDirection.Output;
           
            UserUtil ut = new UserUtil();
            Guid UserGUID = ut.GetUserGuid();
            try
            {
                con.Open();
                cmdRole.ExecuteNonQuery();
                role = (String)cmdRole.Parameters["@RoleID"].Value;
                
                Session["role"] = (String)cmdRole.Parameters["@RoleID"].Value;
                Response.Cookies["pur"].Value = "";
                Response.Cookies["User"].Value = "";
                Response.Cookies["RoleId"].Value = "";
                Response.Cookies["pur"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["RoleId"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["User"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["pur"].Value = "R";
                Response.Cookies["RoleId"].Value = role;  //assig
                
                Response.Cookies["User"].Value = HttpContext.Current.User.Identity.Name;
                Session["Username"] = HttpContext.Current.User.Identity.Name;
            }
            catch(Exception ex)
            {
                 Response.Redirect("login.aspx?msg=" + ex.Message,true);                
                //con.Close;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            string userid = ConnectDB.GetASPNetUserId(HttpContext.Current.User.Identity.Name);
            ConnectDB.LockUser(userid);
             
            Response.Redirect("welcome_home.aspx", true);
            
        }
        else
        {
            Response.Redirect("login.aspx?err=2", true);
            
        }

    }
    
    
}
