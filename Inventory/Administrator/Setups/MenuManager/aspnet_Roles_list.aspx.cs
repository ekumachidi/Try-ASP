
#region " using "
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Threading;
using System.Globalization;
#endregion

public partial class Caspnet_Roles_list : System.Web.UI.Page 
{
  
    private int iDefaultRecordsPerPage = 20;
   private int iRecordCount = 0;

    private bool bSort = true;

protected void Page_Load( object sender,  System.EventArgs e)  
{
    AuthenticationFilter.validateSession(Session, Response);
	 if (!ConnectDB.IsProfileUserAdminSupplied(Response))
        {
            Response.Redirect("~/UpdateStaffRole.aspx");
            return;

        }
    lblMessage.Text = "";
    dbGrid_aspnet_Roles.Visible = true;

    string sCulture = ConfigurationManager.AppSettings["LCID"];
    if (!String.IsNullOrEmpty(sCulture)) 
    {
        int nCulture = int.Parse(sCulture);
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(nCulture, false);
    } 
       
    if (! Page.IsPostBack )
    {    
   
       // func.GetMenu(ddlQuickJump, "dbo.aspnet_Roles");

        BuildDataSource();
    } //  ! Page.IsPostBack
    
}

private void BuildDataSource()
{
    try
    {
        string sSqlWhere = "";
        aspnet_RolesSqlDataSource.SelectParameters.Clear();
        
        if (Session["dbGrid_aspnet_Roles_SearchSQL"] != null) 
            sSqlWhere =  func.WhereBuilder(sSqlWhere, "(" + Session["dbGrid_aspnet_Roles_SearchSQL"].ToString() + ")","And");
        if (Session["dbGrid_aspnet_Roles_SearchParams"] != null) 
        {
            ParameterCollection Params = (ParameterCollection)Session["dbGrid_aspnet_Roles_SearchParams"];
            foreach (Parameter p in Params) 
            {
                txtSearchValue.Text = p.DefaultValue;
                aspnet_RolesSqlDataSource.SelectParameters.Add(p);
            }
        }               

        if (Session["dbGrid_aspnet_Roles_AdvSearch"] != null)
            sSqlWhere = func.WhereBuilder( sSqlWhere , Session["dbGrid_aspnet_Roles_AdvSearch"].ToString());
        if (Session["dbGrid_aspnet_Roles_AdvParam"] != null)
        {
            ParameterCollection Params = (ParameterCollection)Session["dbGrid_aspnet_Roles_AdvParam"];
            foreach (Parameter p in Params) aspnet_RolesSqlDataSource.SelectParameters.Add(p);
        }    

        if(sSqlWhere != string.Empty) aspnet_RolesSqlDataSource.SelectCommand = func.SqlBuilder(aspnet_RolesSqlDataSource.SelectCommand, sSqlWhere);
        
        dbGrid_aspnet_Roles.DataBind();
       
        if (Session["dbGrid_aspnet_Roles_SortExpression"] != null)
        {
            bSort = false;
            dbGrid_aspnet_Roles.Sort((string)Session["dbGrid_aspnet_Roles_SortExpression"], (SortDirection)Session["dbGrid_aspnet_Roles_SortDirection"]);
            bSort = true;
        }
        
        if (Session["dbGrid_aspnet_Roles_CurrentPageCount"] != null )
        {
            ddlPagerCount.SelectedValue = (string)Session["dbGrid_aspnet_Roles_CurrentPageCount"];
            dbGrid_aspnet_Roles.PageSize = Convert.ToInt32(ddlPagerCount.SelectedValue);
        } 
        else
        {
            if (ddlPagerCount.Items.FindByValue(iDefaultRecordsPerPage.ToString()) == null) ddlPagerCount.Items.Add(iDefaultRecordsPerPage.ToString());
            ddlPagerCount.SelectedValue = iDefaultRecordsPerPage.ToString();
            dbGrid_aspnet_Roles.PageSize = iDefaultRecordsPerPage;
        }
        
        int iCurrentPageIndex = (Session["dbGrid_aspnet_Roles_CurrentPageIndex"] == null)?0:Convert.ToInt32(Session["dbGrid_aspnet_Roles_CurrentPageIndex"]);
        if (dbGrid_aspnet_Roles.PageCount >= iCurrentPageIndex)
            dbGrid_aspnet_Roles.PageIndex = iCurrentPageIndex;
        else 
        {
            dbGrid_aspnet_Roles.PageIndex = 0;
            Session["dbGrid_aspnet_Roles_CurrentPageIndex"] = 0;
        }
    }
    catch (Exception ex)
    {
        lblMessage.Text += "Error description" + ": " + ex.Message + "<p>";
        dbGrid_aspnet_Roles.Visible = false;
    }  
    finally
    {
        /* #if(DEBUG)
        {

            lblMessage.Text += "<p>SQL = " + aspnet_RolesSqlDataSource.SelectCommand  + "<p>";
            foreach (Parameter p in aspnet_RolesSqlDataSource.SelectParameters)
                lblMessage.Text += p.Name + "(" + p.Type.ToString()+")="+p.DefaultValue+"<br>";

        }
        #endif */
    }
}

protected void dbGrid_aspnet_Roles_RowDataBound(object sender,  GridViewRowEventArgs e)
{
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        DataRowView rowData;
        rowData = (DataRowView)e.Row.DataItem;

        iRecordCount += 1;
        
        if (rowData["RoleId"] != System.DBNull.Value) e.Row.Attributes.Add("DetailKey_RoleId", rowData["RoleId"].ToString());

    if (e.Row.Cells[2].Text.Length > 80)
        e.Row.Cells[2].Text = func.ProcessLargeText(e.Row.Cells[2].Text, 80, "aspnet_Roles", "field=RoleName&key="  + "RoleId=" + Convert.ToString(rowData["RoleId"]) + ";" );   

    }
    
    if (e.Row.RowType == DataControlRowType.Footer)
    {

        e.Row.Cells[2].Text = "Count: " + iRecordCount.ToString("d");
        iRecordCount = 0;

    }

}    

protected void dbGrid_aspnet_Roles_RowCommand(object source,  GridViewCommandEventArgs e)
{        
    if (e.CommandName == "Page") return;
    if (e.CommandName == "Sort")  return;
    
    int index = Convert.ToInt32(e.CommandArgument);
    DataKey dkKeys = dbGrid_aspnet_Roles.DataKeys[index];    
    
    if ( e.CommandName == "Details_MENU_IN_ROLE" ) 
    {
        GridViewRow row = ((GridView)source).Rows[index];
        if (row.Attributes["DetailKey_RoleId"] == null) return;          
        string sParamName = func.BuildParameterName("RoleId"); 
        string sWhere = "[RoleId]=@Master" + sParamName;
        ParameterCollection Params = new ParameterCollection();
        Params.Add("Master" + sParamName, GetFieldType("RoleId"), row.Attributes["DetailKey_RoleId"].ToString());
        
        Session["fKey_MENU_IN_ROLE_DetailWhere"] = sWhere;
        Session["fKey_MENU_IN_ROLE_DetailParams"] = Params;
        Session["mKey_MENU_IN_ROLE"] = dkKeys;        
        Response.Redirect("MENU_IN_ROLE_list.aspx");    
  }
    
    string sKeysArg = "";   
    foreach (string s in dkKeys.Values.Keys)    
        sKeysArg += s + "=" + Convert.ToString((dkKeys[s]).ToString())+"&";    
    if (sKeysArg == String.Empty) return;

  if ( e.CommandName == "cmdEdit" )  Response.Redirect("aspnet_Roles_Edit.aspx?" + sKeysArg);

}

protected void dbGrid_aspnet_Roles_PageIndexChanged(object source, EventArgs e)
{
    Session["dbGrid_aspnet_Roles_CurrentPageIndex"] = dbGrid_aspnet_Roles.PageIndex;
    BuildDataSource();

}

protected void dbGrid_aspnet_Roles_Sorted(object sender, EventArgs e)
{
    Session["dbGrid_aspnet_Roles_SortExpression"] = null;
    if (bSort) BuildDataSource();
    Session["dbGrid_aspnet_Roles_SortExpression"] = dbGrid_aspnet_Roles.SortExpression;
    Session["dbGrid_aspnet_Roles_SortDirection"] = dbGrid_aspnet_Roles.SortDirection;
}

protected void ddlPagerCount_SelectedIndexChanged(object sender,  EventArgs e)  
{
    Session["dbGrid_aspnet_Roles_CurrentPageCount"] = ddlPagerCount.SelectedValue;
    Session["dbGrid_aspnet_Roles_CurrentPageIndex"] = 0;
    BuildDataSource();
}

protected void btnShowAll_Click( object sender,  System.EventArgs e) 
{
    ViewState["bNoRecords"] = false;
    txtSearchValue.Text = "";
    ddlSearchOperation.SelectedIndex = 0;
    ddlSearchField.SelectedIndex = 0;

    Session["dbGrid_aspnet_Roles_CurrentPageIndex"] = 0;
    Session["dbGrid_aspnet_Roles_SearchSQL"]= null;
    Session["dbGrid_aspnet_Roles_SearchParams"]= null;           
    Session["dbGrid_aspnet_Roles_AdvSearch"] = null;
    Session["dbGrid_aspnet_Roles_AdvParam"] = null;
    Session["htPeramaspnet_Roles"] = null;

    Session["htPeramaspnet_Roles"] = null;
    BuildDataSource();
}

protected void btnSearch_Click( object sender,  System.EventArgs e) 
{
  if (txtSearchValue.Text.Trim() == String.Empty && ddlSearchOperation.SelectedValue.ToString() != "IsNull") return;

  string  sSqlWhere = "";
  ParameterCollection Params = new ParameterCollection();

if (ddlSearchField.SelectedValue.ToString() == "Any Field")
  {

        sSqlWhere =  func.WhereBuilder(sSqlWhere, WhereOneField("RoleName", "SearchRoleName", Params), "Or");

  }
  else
  {
      sSqlWhere = WhereOneField(ddlSearchField.SelectedValue.ToString(), func.BuildParameterName("Search" + ddlSearchField.SelectedValue.ToString()), Params);
  }
  
  if ( sSqlWhere.Trim() != "" )
  {
    Session["dbGrid_aspnet_Roles_SearchSQL"]= sSqlWhere;
    Session["dbGrid_aspnet_Roles_SearchParams"]= Params;   
  }
  else
  {
    Session["dbGrid_aspnet_Roles_SearchSQL"] = "2<>2";
    Session["dbGrid_aspnet_Roles_SearchParams"] = null;
  }  
  Session["dbGrid_aspnet_Roles_CurrentPageIndex"] = 0;
  BuildDataSource();

}

private string WhereOneField(string  sSearchField, string sParamName, ParameterCollection Params) 
{
    string  sSearchOperation = ddlSearchOperation.SelectedValue;
    string  sValue = txtSearchValue.Text.TrimEnd();
    string  sReturn = "";
    string  sSearchType = "";
    TypeCode  fieldType = GetFieldType(sSearchField);
    
    sSearchField = "[" + sSearchField + "]";
    
    if (sSearchOperation == "IsNull") return sSearchField + " is null";
    
    try{object o = Convert.ChangeType(sValue, fieldType);}
    catch { return String.Empty; }

    if (!(func.IsDate(sValue) || func.IsNumeric(sValue))) 
    {

    sSearchType = "upper";

    sValue = sValue.ToUpper();
  }
    
  switch (sSearchOperation)
    { 
            case "Contains":
                sReturn = sSearchType + "(" + sSearchField + ") like '%" + sValue + "%'";break;
            case "Starts with ...":              
                sReturn = sSearchType + "(" + sSearchField + ") like '" + sValue + "%'";break;            
            case "Equals":
                sReturn = sSearchType + "(" + sSearchField + ") = @" + sParamName;break;
            case "More than ...":
                sReturn = sSearchField + ">@" + sParamName;break;
            case "Less than ...":
                sReturn = sSearchField + "<@" + sParamName;break;
            case "Equal or more than ...":
                sReturn = sSearchField + ">=@" + sParamName;break;
            case "Equal or less than ...":
                sReturn = sSearchField + "<=@" + sParamName;break;
            default:
            sReturn = String.Empty; break;
  }

  if (sReturn != string.Empty && (sSearchOperation != "Contains" && sSearchOperation != "Starts with ..."))
  {  
      if (func.IsNumeric(sValue)) Params.Add(sParamName, sValue);
      else Params.Add(sParamName, fieldType, sValue);
  }
  return sReturn;
}

protected TypeCode GetFieldType(string  sField) 
{
    switch (sField)
    {
  
        case "ApplicationId": return TypeCode.String;
  
        case "RoleId": return TypeCode.String;
  
        case "RoleName": return TypeCode.String;
  
        case "LoweredRoleName": return TypeCode.String;
  
        case "Description": return TypeCode.String;
  
        default: return TypeCode.String;
    }    
}

protected void btnAdd_Click(object sender,  EventArgs e)  
{

    Response.Redirect("aspnet_Roles_add.aspx");

}
 
protected void hlkBackToMenu_Click(object sender,  EventArgs e)
{
    string sMenuURL = ConfigurationManager.AppSettings["MenuFile"];
    if ( sMenuURL == String.Empty) 
    {
        Response.Write("<script language=javascript>alert('Menu page isn't set');</script>");
        return;
    }
        
    ClearSession();
    Response.Redirect(sMenuURL);
}
/*
protected void ddlQuickJump_SelectedIndexChanged(object sender, EventArgs e)
{
    ClearSession();
    Response.Redirect(ddlQuickJump.SelectedItem.Value);
}
*/
private void ClearSession() 
{
    Session["dbGrid_aspnet_Roles_Sort"] = null;

    Session["dbGrid_aspnet_Roles_SearchSQL"]= null;
    Session["dbGrid_aspnet_Roles_SearchParams"]= null;   

    Session["dbGrid_aspnet_Roles_AdvSearch"] = null;
    Session["dbGrid_aspnet_Roles_AdvParam"] = null;
    Session["htPeramaspnet_Roles"] = null;   

    Session["htPeramaspnet_Roles"] = null;
    Session["dbGrid_aspnet_Roles_CurrentPageIndex"] = null;
    Session["dbGrid_aspnet_Roles_CurrentPageCount"] = null;

    Session["fKey_MENU_IN_ROLE_DetailWhere"] = null;
    Session["fKey_MENU_IN_ROLE_DetailParams"] = null;
    Session["mKey_MENU_IN_ROLE"] = null;        

    Session["dbGrid_aspnet_Roles_SortExpression"] = null;
    Session["dbGrid_aspnet_Roles_SortDirection"] = null;
}

protected void ShowWait() 
{
    Response.Write("<div id='mydiv' align=center>&nbsp;</div>");
    Response.Write("<script>mydiv.innerText = '';</script>");
    Response.Write("<script language=javascript>;");
    Response.Write("var dots = 0;var dotmax = 10;function ShowWait()");
    Response.Write("{var output; output = '"+"Please wait"+"';dots++;if(dots>=dotmax)dots=1;");
    Response.Write("for(var x = 0;x < dots;x++){output += '.';}mydiv.innerText =  output;}");
    Response.Write("function StartShowWait(){mydiv.style.visibility = 'visible'; window.setInterval('ShowWait()',500);}");
    Response.Write("function HideWait(){mydiv.style.visibility = 'hidden';window.clearInterval();}");
    Response.Write("StartShowWait();</script>");
    Response.Flush();
}

protected void aspnet_RolesSqlDataSource_Selected(object sender, SqlDataSourceStatusEventArgs e)
{
    lblCount.Text = "Details found" +": " + e.AffectedRows.ToString();
}

}
