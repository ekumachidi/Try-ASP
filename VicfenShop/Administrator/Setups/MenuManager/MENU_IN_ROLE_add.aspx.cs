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


public partial class CMENU_IN_ROLE_Add : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
       // AuthenticationFilter.validateSession(Session, Response);
        lblMessage.Text = "";

        string sCulture = ConfigurationManager.AppSettings["LCID"];
        if (!String.IsNullOrEmpty(sCulture)) 
        {
            int nCulture = int.Parse(sCulture);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(nCulture, false);
        } 

        if (!Page.IsPostBack) 
        {

        }        
    }
    
    protected void BindData() 
    {
        try
        {

            string sKey = Server.UrlDecode(Request.QueryString["key"]);
            if(!String.IsNullOrEmpty(sKey)) 
            {

                DropDownList ddlRoleId = MENU_IN_ROLEDetailsView.FindControl("fldRoleId") as DropDownList;
                if (ddlRoleId != null && ddlRoleId.Items.FindByValue(sKey) != null) 
                {
                    ddlRoleId.SelectedValue = sKey;
                    ddlRoleId.Enabled = false;
                }       

            }               

        }
        catch (Exception ex)
        {
            lblMessage.Text += "Error description" + ": " + ex.Message + "<p>";
        }
    }
    
    protected void MENU_IN_ROLEDetailsView_DataBound(object sender, EventArgs e)
    {
        BindData();
    }

    protected void MENU_IN_ROLEDetailsView_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {         

        string sKey = Server.UrlDecode(Request.QueryString["key"]);

    }

    protected void MENU_IN_ROLESqlDataSource_Inserted(object sender, SqlDataSourceStatusEventArgs e)
    {
        if (e.Exception == null)
        {
            lblMessage.Text = "<b>" + "Record inserted" + "</b><p>";
        }
        else
        {
            lblMessage.Text += "Error description" + ": " + e.Exception.Message + "<p>";
            e.ExceptionHandled = true;
        }

//#if ( DEBUG )
//        lblMessage.Text += "<p>InsertCommand = " + MENU_IN_ROLESqlDataSource.InsertCommand + "<p>";
//        foreach (System.Data.Common.DbParameter p in e.Command.Parameters)
//            lblMessage.Text += p.ParameterName + "(" + p.DbType.ToString() + ")=" + p.Value.ToString() + "<br>";
//#endif
    } 
   
    protected void MENU_IN_ROLESqlDataSource_Inserting(object sender, SqlDataSourceCommandEventArgs e)
    {

    }

}
