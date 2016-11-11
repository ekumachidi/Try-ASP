 
#region " using "
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections;
using System.IO;
using System.Web.UI.WebControls;
#endregion

public partial class Caspnet_Roles_FullText : System.Web.UI.Page
{	
	private string sKeyFields;
    private string sFieldName = "";
    
private void Page_Load( object sender,  System.EventArgs e)
{
    //Put user code to initialize the page here
    AuthenticationFilter.validateSession(Session, Response);
    lblText.Text = "";
    if ( Request.QueryString["key"] != null ) 
    {
        sKeyFields = Request.QueryString["key"];
        if ( Request.QueryString["field"] != null ) sFieldName = Request.QueryString["field"].Split(';')[0];
    } 
    else 
    {
        lblText.Text = "Invalid key field value" + "<p>";
        return;
    }    
    if (!Page.IsPostBack) 
    {
        BindData();
    }
  }

private void BindData() 
{
    if ( sKeyFields == "" || sFieldName == "" ) return;

    ConnectionStringSettings cts = ConfigurationManager.ConnectionStrings["Project1ConnectionString"];
    SqlDataSource sds = new SqlDataSource();
  
	try 
	{

        sds.ConnectionString = cts.ConnectionString;
        sds.ProviderName = cts.ProviderName;
        sds.DataSourceMode = SqlDataSourceMode.DataReader;
        sds.SelectCommand = "select [" + sFieldName  + "] from [dbo].[aspnet_Roles] where 2=2 ";

        foreach(string s in sKeyFields.Split(";".ToCharArray()))
        {
            if(s.Split('=').Length != 2) continue;
            string sKeyFieldName = s.Split('=')[0];
            sds.SelectCommand +=  " And [" + sKeyFieldName + "]=@"+func.BuildParameterName(sKeyFieldName);           
            sds.SelectParameters.Add(func.BuildParameterName(sKeyFieldName), s.Split('=')[1]);
        }
        System.Data.Common.DbDataReader dbDr = (System.Data.Common.DbDataReader)sds.Select(System.Web.UI.DataSourceSelectArguments.Empty);          
        if (dbDr.HasRows && dbDr.Read()) lblText.Text = dbDr[sFieldName].ToString();        
    }
    finally
    {
        sds.Dispose();
    }        
}

}