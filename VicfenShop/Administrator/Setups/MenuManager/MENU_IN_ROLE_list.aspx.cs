//
#region " using "
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Threading;
using System.Globalization;
#endregion

public partial class CMENU_IN_ROLE_list : System.Web.UI.Page 
{
  
    private int iDefaultRecordsPerPage = 20;

    private bool bSort = true;

protected void Page_Load( object sender,  System.EventArgs e)  
{
   // AuthenticationFilter.validateSession(Session, Response);
    lblMessage.Text = "";
    dbGrid_MENU_IN_ROLE.Visible = true;

    string sCulture = ConfigurationManager.AppSettings["LCID"];
    if (!String.IsNullOrEmpty(sCulture)) 
    {
        int nCulture = int.Parse(sCulture);
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(nCulture, false);
    } 
       
    if (! Page.IsPostBack )
    {    
   
        //func.GetMenu(ddlQuickJump, "dbo.MENU_IN_ROLE");

        btnDelete.Attributes.Add("onclick", "return confirm('"+"Do you really want to delete these records?"+"');");

        BuildDataSource();
    } //  ! Page.IsPostBack
    
}

private void BuildDataSource()
{
    try
    {
        string sSqlWhere = "";
        MENU_IN_ROLESqlDataSource.SelectParameters.Clear();
        
        if (Session["mKey_MENU_IN_ROLE"] != null)
        {
            maspnet_RolesSqlDataSource.SelectParameters.Clear();
            DataKey dkKeys = (DataKey)Session["mKey_MENU_IN_ROLE"];
            string sMasterWhere = "";
            foreach (string s in dkKeys.Values.Keys)
            {
                string sParamName = func.BuildParameterName(s);
                sMasterWhere = func.WhereBuilder(sMasterWhere, "[" + s + "] =@" + sParamName);
                if (dkKeys[s] != null) maspnet_RolesSqlDataSource.SelectParameters.Add(sParamName,  GetFieldType(s), dkKeys[s].ToString());
            }
            maspnet_RolesSqlDataSource.SelectCommand = func.SqlBuilder(maspnet_RolesSqlDataSource.SelectCommand, sMasterWhere);
            dbGrid_faspnet_Roles.DataSourceID = "maspnet_RolesSqlDataSource";
            dbGrid_faspnet_Roles.DataBind();
        }
        else lnkBackToMainList.Visible = false;

        if (Session["fKey_MENU_IN_ROLE_DetailParams"] != null && Session["fKey_MENU_IN_ROLE_DetailWhere"] != null) 
        {
            sSqlWhere =  func.WhereBuilder(sSqlWhere, "(" + Session["fKey_MENU_IN_ROLE_DetailWhere"].ToString() + ")","And");
            ParameterCollection Params = (ParameterCollection)Session["fKey_MENU_IN_ROLE_DetailParams"];
            foreach (Parameter p in Params) MENU_IN_ROLESqlDataSource.SelectParameters.Add(p);
        }                       

        if (Session["dbGrid_MENU_IN_ROLE_SearchSQL"] != null) 
            sSqlWhere =  func.WhereBuilder(sSqlWhere, "(" + Session["dbGrid_MENU_IN_ROLE_SearchSQL"].ToString() + ")","And");
        if (Session["dbGrid_MENU_IN_ROLE_SearchParams"] != null) 
        {
            ParameterCollection Params = (ParameterCollection)Session["dbGrid_MENU_IN_ROLE_SearchParams"];
            foreach (Parameter p in Params) 
            {
                txtSearchValue.Text = p.DefaultValue;
                MENU_IN_ROLESqlDataSource.SelectParameters.Add(p);
            }
        }               

        if (Session["dbGrid_MENU_IN_ROLE_AdvSearch"] != null)
            sSqlWhere = func.WhereBuilder( sSqlWhere , Session["dbGrid_MENU_IN_ROLE_AdvSearch"].ToString());
        if (Session["dbGrid_MENU_IN_ROLE_AdvParam"] != null)
        {
            ParameterCollection Params = (ParameterCollection)Session["dbGrid_MENU_IN_ROLE_AdvParam"];
            foreach (Parameter p in Params) MENU_IN_ROLESqlDataSource.SelectParameters.Add(p);
        }    

        if(sSqlWhere != string.Empty) MENU_IN_ROLESqlDataSource.SelectCommand = func.SqlBuilder(MENU_IN_ROLESqlDataSource.SelectCommand, sSqlWhere);
        
        dbGrid_MENU_IN_ROLE.DataBind();
       
        if (Session["dbGrid_MENU_IN_ROLE_SortExpression"] != null)
        {
            bSort = false;
            dbGrid_MENU_IN_ROLE.Sort((string)Session["dbGrid_MENU_IN_ROLE_SortExpression"], (SortDirection)Session["dbGrid_MENU_IN_ROLE_SortDirection"]);
            bSort = true;
        }
        
        if (Session["dbGrid_MENU_IN_ROLE_CurrentPageCount"] != null )
        {
            ddlPagerCount.SelectedValue = (string)Session["dbGrid_MENU_IN_ROLE_CurrentPageCount"];
            dbGrid_MENU_IN_ROLE.PageSize = Convert.ToInt32(ddlPagerCount.SelectedValue);
        } 
        else
        {
            if (ddlPagerCount.Items.FindByValue(iDefaultRecordsPerPage.ToString()) == null) ddlPagerCount.Items.Add(iDefaultRecordsPerPage.ToString());
            ddlPagerCount.SelectedValue = iDefaultRecordsPerPage.ToString();
            dbGrid_MENU_IN_ROLE.PageSize = iDefaultRecordsPerPage;
        }
        
        int iCurrentPageIndex = (Session["dbGrid_MENU_IN_ROLE_CurrentPageIndex"] == null)?0:Convert.ToInt32(Session["dbGrid_MENU_IN_ROLE_CurrentPageIndex"]);
        if (dbGrid_MENU_IN_ROLE.PageCount >= iCurrentPageIndex)
            dbGrid_MENU_IN_ROLE.PageIndex = iCurrentPageIndex;
        else 
        {
            dbGrid_MENU_IN_ROLE.PageIndex = 0;
            Session["dbGrid_MENU_IN_ROLE_CurrentPageIndex"] = 0;
        }
    }
    catch (Exception ex)
    {
        lblMessage.Text += "Error description" + ": " + ex.Message + "<p>";
        dbGrid_MENU_IN_ROLE.Visible = false;
    }  
    finally
    {
        /*#if(DEBUG)
        {

          if (Session["mKey_MENU_IN_ROLE"] != null)
          {
              lblMessage.Text += "<p>Master SQL = " + maspnet_RolesSqlDataSource.SelectCommand  + "<p>";
              foreach (Parameter p in maspnet_RolesSqlDataSource.SelectParameters)
                  lblMessage.Text += p.Name + "(" + p.Type.ToString()+")="+p.DefaultValue+"<br>";
          }

            lblMessage.Text += "<p>SQL = " + MENU_IN_ROLESqlDataSource.SelectCommand  + "<p>";
            foreach (Parameter p in MENU_IN_ROLESqlDataSource.SelectParameters)
                lblMessage.Text += p.Name + "(" + p.Type.ToString()+")="+p.DefaultValue+"<br>";

        }
        #endif */
    }
}

protected void dbGrid_MENU_IN_ROLE_RowCreated(object sender,  GridViewRowEventArgs e)
{

    if (e.Row.RowType == DataControlRowType.Header) func.AddGlyph(dbGrid_MENU_IN_ROLE, e.Row);

    if (e.Row.RowType == DataControlRowType.DataRow)
    { 

       }

   }
 
protected void dbGrid_MENU_IN_ROLE_RowDataBound(object sender,  GridViewRowEventArgs e)
{
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        DataRowView rowData;
        rowData = (DataRowView)e.Row.DataItem;

    if (e.Row.Cells[1].Text.Length > 80)
        e.Row.Cells[1].Text = func.ProcessLargeText(e.Row.Cells[1].Text, 80, "MENU_IN_ROLE", "field=MenuId&key="  + "MenuId=" + Convert.ToString(rowData["MenuId"]) + ";" + "RoleId=" + Convert.ToString(rowData["RoleId"]) + ";" );   

        if (rowData["MenuId"] != System.DBNull.Value) e.Row.Cells[1].Text = func.GetLookupValue("[MenuTitle]", "[MenuId]", "[dbo].[MENU_SUB]", Convert.ToString(rowData["MenuId"]), TypeCode.Int32);

    }

}    

protected void dbGrid_MENU_IN_ROLE_RowCommand(object source,  GridViewCommandEventArgs e)
{        
    if (e.CommandName == "Page") return;
    if (e.CommandName == "Sort")  return;
    
    int index = Convert.ToInt32(e.CommandArgument);
    DataKey dkKeys = dbGrid_MENU_IN_ROLE.DataKeys[index];    
    
    string sKeysArg = "";   
    foreach (string s in dkKeys.Values.Keys)    
        sKeysArg += s + "=" + Convert.ToString(dkKeys[s])+"&";    
    if (sKeysArg == String.Empty) return;

}

protected void dbGrid_MENU_IN_ROLE_RowDeleted(object sender, GridViewDeletedEventArgs e)
{
    lblMessage.Text = "<b>Record has been deleted!</b><br>";
}

protected void dbGrid_MENU_IN_ROLE_PageIndexChanged(object source, EventArgs e)
{
    Session["dbGrid_MENU_IN_ROLE_CurrentPageIndex"] = dbGrid_MENU_IN_ROLE.PageIndex;
    BuildDataSource();

}

protected void dbGrid_MENU_IN_ROLE_Sorted(object sender, EventArgs e)
{
    Session["dbGrid_MENU_IN_ROLE_SortExpression"] = null;
    if (bSort) BuildDataSource();
    Session["dbGrid_MENU_IN_ROLE_SortExpression"] = dbGrid_MENU_IN_ROLE.SortExpression;
    Session["dbGrid_MENU_IN_ROLE_SortDirection"] = dbGrid_MENU_IN_ROLE.SortDirection;
}

protected void ddlPagerCount_SelectedIndexChanged(object sender,  EventArgs e)  
{
    Session["dbGrid_MENU_IN_ROLE_CurrentPageCount"] = ddlPagerCount.SelectedValue;
    Session["dbGrid_MENU_IN_ROLE_CurrentPageIndex"] = 0;
    BuildDataSource();
}

protected void btnShowAll_Click( object sender,  System.EventArgs e) 
{
    ViewState["bNoRecords"] = false;
    txtSearchValue.Text = "";
    ddlSearchOperation.SelectedIndex = 0;
    ddlSearchField.SelectedIndex = 0;

    Session["dbGrid_MENU_IN_ROLE_CurrentPageIndex"] = 0;
    Session["dbGrid_MENU_IN_ROLE_SearchSQL"]= null;
    Session["dbGrid_MENU_IN_ROLE_SearchParams"]= null;           
    Session["dbGrid_MENU_IN_ROLE_AdvSearch"] = null;
    Session["dbGrid_MENU_IN_ROLE_AdvParam"] = null;
    Session["htPeramMENU_IN_ROLE"] = null;

    Session["htPeramMENU_IN_ROLE"] = null;
    BuildDataSource();
}

protected void btnSearch_Click( object sender,  System.EventArgs e) 
{
  if (txtSearchValue.Text.Trim() == String.Empty && ddlSearchOperation.SelectedValue.ToString() != "IsNull") return;

  string  sSqlWhere = "";
  ParameterCollection Params = new ParameterCollection();

if (ddlSearchField.SelectedValue.ToString() == "Any Field")
  {

        sSqlWhere =  func.WhereBuilder(sSqlWhere, WhereOneField("MenuId", "SearchMenuId", Params), "Or");

  }
  else
  {
      sSqlWhere = WhereOneField(ddlSearchField.SelectedValue.ToString(), func.BuildParameterName("Search" + ddlSearchField.SelectedValue.ToString()), Params);
  }
  
  if ( sSqlWhere.Trim() != "" )
  {
    Session["dbGrid_MENU_IN_ROLE_SearchSQL"]= sSqlWhere;
    Session["dbGrid_MENU_IN_ROLE_SearchParams"]= Params;   
  }
  else
  {
    Session["dbGrid_MENU_IN_ROLE_SearchSQL"] = "2<>2";
    Session["dbGrid_MENU_IN_ROLE_SearchParams"] = null;
  }  
  Session["dbGrid_MENU_IN_ROLE_CurrentPageIndex"] = 0;
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
  
        case "MenuId": return TypeCode.Int32;
  
        case "RoleId": return TypeCode.String;
  
        default: return TypeCode.String;
    }    
}

protected void btnDelete_Click(object sender,  EventArgs e)  
{
    string sWhere = Request.Form["chDelete"];
    if (!string.IsNullOrEmpty(sWhere))
    {
    try
    {
        foreach (string s in sWhere.Split(','))
        {
            int iRowIndex = Convert.ToInt32(s);
     
            dbGrid_MENU_IN_ROLE.DeleteRow(iRowIndex);
        }
        
    }
    catch (Exception ex)
    {
      lblMessage.Text += "Error description" + ": " + ex.Message + "<p>";     
    }  
    }
    BuildDataSource();
}
protected void MENU_IN_ROLESqlDataSource_Deleting(object sender, SqlDataSourceCommandEventArgs e)
{
    
}

protected void btnAdd_Click(object sender,  EventArgs e)  
{

    if ( Session["fKey_MENU_IN_ROLE_DetailParams"] != null ) Response.Redirect("MENU_IN_ROLE_add.aspx?key="+Server.UrlEncode(((ParameterCollection)Session["fKey_MENU_IN_ROLE_DetailParams"])[0].DefaultValue));
    else Response.Redirect("MENU_IN_ROLE_add.aspx");

}
 
protected void lnkBackToMainList_Click(object sender,  System.EventArgs e)   
{
    ClearSession();
    Response.Redirect("aspnet_Roles_list.aspx");
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

protected void ddlQuickJump_SelectedIndexChanged(object sender, EventArgs e)
{
    ClearSession();
    //Response.Redirect(ddlQuickJump.SelectedItem.Value);
}

private void ClearSession() 
{
    Session["dbGrid_MENU_IN_ROLE_Sort"] = null;

    Session["dbGrid_MENU_IN_ROLE_SearchSQL"]= null;
    Session["dbGrid_MENU_IN_ROLE_SearchParams"]= null;   

    Session["dbGrid_MENU_IN_ROLE_AdvSearch"] = null;
    Session["dbGrid_MENU_IN_ROLE_AdvParam"] = null;
    Session["htPeramMENU_IN_ROLE"] = null;   

    Session["htPeramMENU_IN_ROLE"] = null;
    Session["dbGrid_MENU_IN_ROLE_CurrentPageIndex"] = null;
    Session["dbGrid_MENU_IN_ROLE_CurrentPageCount"] = null;

    Session["mKey_MENU_IN_ROLE"] = null;

    Session["fKey_MENU_IN_ROLE_DetailParams"] = null;
    Session["fKey_MENU_IN_ROLE_DetailWhere"] = null;

    Session["dbGrid_MENU_IN_ROLE_SortExpression"] = null;
    Session["dbGrid_MENU_IN_ROLE_SortDirection"] = null;
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

protected void MENU_IN_ROLESqlDataSource_Selected(object sender, SqlDataSourceStatusEventArgs e)
{
    lblCount.Text = "Details found" +": " + e.AffectedRows.ToString();
}

}
