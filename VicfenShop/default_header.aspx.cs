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
using System.Web.Services;

public partial class default_header : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // AuthenticationFilter.validateSession(Session, Response);
            DateTime date = System.DateTime.Now;

            string Fullnames = "";
            String PicUrl = "";

            string strDate = date.ToLongDateString();
         //   lblDate.Text = strDate;

            ConnectDB.DisplayHeaderDetails(new UserUtil().GetUserGuid(), ref Fullnames, ref PicUrl);
            if (PicUrl == "")
            {
                PicUrl = @"~/images/default_employee_image.gif";
            }

            Label1.Text = Fullnames;
            Image1.ImageUrl = PicUrl;
           
           
        }
        catch (Exception ex)
        {
            Response.Redirect("~/login.aspx");
        }
    }

    [WebMethod]
    public static void  SignOutUser()
    {
        try
        {
            
            ConnectDB.SignOutUser();
        }
        catch (Exception ex)
        {

        }
    }
}
