 
#region " using "
using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
#endregion

public partial class CMENU_IN_ROLE_search : System.Web.UI.Page
{

    private System.Collections.Hashtable htPeramMENU_IN_ROLE = new System.Collections.Hashtable();

 protected void Page_Load( object sender,  System.EventArgs e)  
 {
        // 
        //
     AuthenticationFilter.validateSession(Session, Response);
        if (! Page.IsPostBack ) 
        { 
            Session["dbGrid_MENU_IN_ROLE_SearchSQL"] = null;
            Session["dbGrid_MENU_IN_ROLE_SearchParams"] = null;

            BindData();
        }        
}

protected void BindData() 
{

    func.LoadDataToLookUp(ref fldMenuId, "SELECT [MenuId], [MenuTitle] FROM [dbo].[MENU_SUB]  ", "");

    htPeramMENU_IN_ROLE = (System.Collections.Hashtable)Session["htPeramMENU_IN_ROLE"];
    if ( htPeramMENU_IN_ROLE !=null ) 
    {
        if (htPeramMENU_IN_ROLE.ContainsKey("rb")) { rbAnd.Checked = (bool)htPeramMENU_IN_ROLE["rb"]; }

		if ( htPeramMENU_IN_ROLE.ContainsKey("ddlOperation_MenuId") ) ddlOperation_MenuId.SelectedValue = (string)htPeramMENU_IN_ROLE["ddlOperation_MenuId"];
        if ( htPeramMENU_IN_ROLE.ContainsKey("chNot_MenuId") ) chNot_MenuId.Checked = (bool)htPeramMENU_IN_ROLE["chNot_MenuId"];

        if ( htPeramMENU_IN_ROLE.ContainsKey("fldMenuId") )fldMenuId.SelectedValue = (string)htPeramMENU_IN_ROLE["fldMenuId"];

    }
}

protected void hlBack_Click( object sender,  System.EventArgs e) 
{
    Response.Redirect("MENU_IN_ROLE_list.aspx");
}

protected void btnSearch_Click( object sender,  System.EventArgs e)
{
    string  sWhere = "";
    ParameterCollection Params = new ParameterCollection();
    string  sValue = "";
    string  sValue2 = "";
    htPeramMENU_IN_ROLE.Add("rb", rbAnd.Checked);

    htPeramMENU_IN_ROLE.Add("ddlOperation_MenuId", ddlOperation_MenuId.SelectedValue);
    htPeramMENU_IN_ROLE.Add("chNot_MenuId", chNot_MenuId.Checked);

    sValue = fldMenuId.SelectedValue;

    if(sValue != string.Empty) htPeramMENU_IN_ROLE.Add("fldMenuId", sValue);
    if(sValue2 != string.Empty) htPeramMENU_IN_ROLE.Add("fld2MenuId", sValue2);
  
    sWhere = func.WhereBuilder(sWhere, WhereOneField("[MenuId]",TypeCode.Int32, ddlOperation_MenuId.SelectedItem.Value.ToString(), 
            sValue, sValue2, Params, chNot_MenuId.Checked), (rbAnd.Checked?"And":"Or"));            
    
    if ( sWhere.Trim() == "" ) 
    {
            Session["dbGrid_MENU_IN_ROLE_AdvSearch"] = null;
            Session["dbGrid_MENU_IN_ROLE_AdvParam"] = null;
            Session["htPeramMENU_IN_ROLE"] = null;
    }
    else 
    {
            Session["dbGrid_MENU_IN_ROLE_AdvSearch"] = "(" + sWhere +")";
            Session["dbGrid_MENU_IN_ROLE_AdvParam"] = Params;
            Session["htPeramMENU_IN_ROLE"] = htPeramMENU_IN_ROLE;
    }
    Response.Redirect("MENU_IN_ROLE_list.aspx");

}

protected string WhereOneField(string  sSearchField, TypeCode FieldType, string sSearchOperation,  string  sValue,  string  sValue2, ParameterCollection Params, bool bNot) 
{

  if (sSearchOperation == "IsNull") return sSearchField + " is null";
  if ( sValue == "" && sValue2 == "") return String.Empty;
/*
  try
  {
      object o = Convert.ChangeType(sValue, FieldType);
      if (sValue2 != string.Empty) o = Convert.ChangeType(sValue2, FieldType);
  }
  catch { return String.Empty; }
  */
  string  sReturn = "";
  string  sSearchType = "";
  string  sParamName = func.BuildParameterName("AdvSearch" + sSearchField);  
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
            sReturn = sSearchType + "(" + sSearchField + ") = @" + sParamName;
            break;
        case "More than ...":
            sReturn = sSearchField + ">@" + sParamName;
            break;
        case "Less than ...":
            sReturn = sSearchField + "<@" + sParamName;
            break;
        case "Equal or more than ...":
            sReturn = sSearchField + ">=@" + sParamName;
            break;
        case "Equal or less than ...":
            sReturn = sSearchField + "<=@" + sParamName;
            break;
        case "Between":
            sReturn = sSearchField + ">=@" + sParamName + " And " + sSearchField + "<=@" + sParamName+"2";
            break;
        default:
            return String.Empty;
    }
    if (sReturn != string.Empty && bNot) sReturn = "(Not (" + sReturn + "))";        
    if (sReturn != string.Empty && (sSearchOperation != "Contains" && sSearchOperation != "Starts with ..."))
    {  
	  Params.Add(sParamName, FieldType, sValue);
      if (sSearchOperation == "Between") Params.Add(sParamName+"2", FieldType, sValue2);
    }
  return sReturn;
}

//
   
}

   