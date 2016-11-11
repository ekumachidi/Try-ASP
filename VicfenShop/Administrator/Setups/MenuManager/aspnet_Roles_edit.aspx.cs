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

public partial class Caspnet_Roles_Edit : System.Web.UI.Page
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

            BindData();
        }    

    }
    
    protected void BindData() 
    {
        try
        {
            aspnet_RolesDetailsView.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text += "Error description" + ": " + ex.Message + "<p>";
        }
    }
    
    protected void aspnet_RolesDetailsView_DataBound(object sender, EventArgs e)
    {


    }
    
    protected void aspnet_RolesDetailsView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {         

    }
    
    protected void aspnet_RolesSqlDataSource_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblMessage.Text += "Error description" + ": " + e.Exception.Message + "<p>";
            e.ExceptionHandled = true;
        }
//#if ( DEBUG )
//        lblMessage.Text += "<p>SelectCommand = " + aspnet_RolesSqlDataSource.SelectCommand + "<p>";
//        foreach (System.Data.Common.DbParameter p in e.Command.Parameters)
//            lblMessage.Text += p.ParameterName + "(" + p.DbType.ToString() + ")=" + p.Value.ToString() + "<br>";
//#endif
    }

    protected void aspnet_RolesSqlDataSource_Updated(object sender, SqlDataSourceStatusEventArgs e)
    {
        if (e.Exception == null)
        {
            lblMessage.Text = "<b>" + "Record updated" + "</b><p>";
        }
        else
        {
            lblMessage.Text += "Error description" + ": " + e.Exception.Message + "<p>";
            e.ExceptionHandled = true;
        }
        
//#if ( DEBUG )
//        lblMessage.Text += "<p>UpdateCommand = " + aspnet_RolesSqlDataSource.UpdateCommand + "<p>";
//        foreach (System.Data.Common.DbParameter p in e.Command.Parameters)
//            lblMessage.Text += p.ParameterName + "(" + p.DbType.ToString() + ")=" + p.Value.ToString() + "<br>";
//#endif
    } 
    
    protected void aspnet_RolesSqlDataSource_Updating(object sender, SqlDataSourceCommandEventArgs e)
    {

    }

}
