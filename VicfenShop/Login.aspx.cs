using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        String txtUsername = UserName.Text;
        String txtPassword = Password.Text;
        lblMsg.Text = "Please Wait...";
        try
        {
            bool test = Membership.ValidateUser(txtUsername.Trim(), txtPassword.Trim());
            if (test == true)
            {
                FormsAuthentication.RedirectFromLoginPage(txtUsername.Trim(), false);
                Response.Redirect("loginproccessor.aspx");
            }
            else
            {
                lblMsg.Text = "Incorrect Username or Password";
            }
        }
        catch (Exception ex)
        {

            lblMsg.Text = ex.Message;
        }
        
    }
}