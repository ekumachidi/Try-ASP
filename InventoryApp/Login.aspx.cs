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

    private void ShowMessage(string strMsg)
    {
        string csName = "popupScript";
        Type csType = this.GetType();
        ClientScriptManager cs = Page.ClientScript;

        if (!cs.IsStartupScriptRegistered(csType, csName))
        {
            String cstext = "alert('" + strMsg + "');";
            cs.RegisterStartupScript(csType, csName, cstext, true);

        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string username = txtUsername.Text;
            string Password = txtPassword.Text;

            if (!ConnectDB.DoesUsernameExists(username))
            {

                ShowMessage("The username [" + username + "] does not exists !");
                return;
            }
            if (!ConnectDB.DoesUsernamePasswordExists(username, Password))
            {
                ShowMessage("Invalid Password !");
                return;
            }
           
            //if (Membership.GetUser(username).IsOnline)
            //{
            //    ShowMessage("The User is Currently Logged in !");
            //    ConnectDB.SignUserOut(username);
                FormsAuthentication.SetAuthCookie(username, true);
            //    return;

            //}

            Membership.GetUser(username).UnlockUser();
            if (ConnectDB.IsAccountLockedOut(username))
            {

                ConnectDB.UnLockUserByName(username);

            }

            FormsAuthentication.RedirectFromLoginPage(username, false);
            Response.Redirect("loginproccessor.aspx");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);

        }
    }
}