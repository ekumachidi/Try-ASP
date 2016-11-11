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

public partial class Caspnet_Roles_Add : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        AuthenticationFilter.validateSession(Session, Response);
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

        }
        catch (Exception ex)
        {
            lblMessage.Text += "Error description" + ": " + ex.Message + "<p>";
        }
    }
    
    protected void aspnet_RolesDetailsView_DataBound(object sender, EventArgs e)
    {
        BindData();
    }

    protected void aspnet_RolesDetailsView_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
       
    }

    protected void aspnet_RolesSqlDataSource_Inserted(object sender, SqlDataSourceStatusEventArgs e)
    {
        lblMessage.Text = "";
        if (e.Exception == null)
        {
            lblMessage.Text = "<b>" + "Record inserted" + "</b><p>";
        }
        else
        {
            //lblMessage.Text += "Error description" + ": " + e.Exception.Message + "<p>";
            e.ExceptionHandled = true;
        }

#if ( DEBUG )
        lblMessage.Text += "<p>InsertCommand = " + aspnet_RolesSqlDataSource.InsertCommand + "<p>";
        foreach (System.Data.Common.DbParameter p in e.Command.Parameters)
            lblMessage.Text += p.ParameterName + "(" + p.DbType.ToString() + ")=" + p.Value.ToString() + "<br>";
#endif
    } 
   
    protected void aspnet_RolesSqlDataSource_Inserting(object sender, SqlDataSourceCommandEventArgs e)
    {

    }

    protected void aspnet_RolesDetailsView_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }
    protected void aspnet_RolesDetailsView_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        Response.Write("<script>parent.frames['menu'].location.href='../../../menu.aspx';</script>");
    }
}
