 
#region " using "
using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
#endregion

public partial class Caspnet_Roles_search : System.Web.UI.Page
{

    private System.Collections.Hashtable htPeramaspnet_Roles = new System.Collections.Hashtable();

 protected void Page_Load( object sender,  System.EventArgs e)  
 {
        // 
        //
     AuthenticationFilter.validateSession(Session, Response);
        if (! Page.IsPostBack ) 
        { 
            Session["dbGrid_aspnet_Roles_SearchSQL"] = null;
            Session["dbGrid_aspnet_Roles_SearchParams"] = null;

            BindData();
        }        
}

protected void BindData() 
{

    htPeramaspnet_Roles = (System.Collections.Hashtable)Session["htPeramaspnet_Roles"];
    if ( htPeramaspnet_Roles !=null ) 
    {
        if (htPeramaspnet_Roles.ContainsKey("rb")) { rbAnd.Checked = (bool)htPeramaspnet_Roles["rb"]; }

		if ( htPeramaspnet_Roles.ContainsKey("ddlOperation_RoleName") ) ddlOperation_RoleName.SelectedValue = (string)htPeramaspnet_Roles["ddlOperation_RoleName"];
        if ( htPeramaspnet_Roles.ContainsKey("chNot_RoleName") ) chNot_RoleName.Checked = (bool)htPeramaspnet_Roles["chNot_RoleName"];

        if ( htPeramaspnet_Roles.ContainsKey("fldRoleName") ) fldRoleName.Text = (string)htPeramaspnet_Roles["fldRoleName"];
        if ( htPeramaspnet_Roles.ContainsKey("fld2RoleName") )fld2RoleName.Text = (string)htPeramaspnet_Roles["fld2RoleName"];

    }
}

protected void hlBack_Click( object sender,  System.EventArgs e) 
{
    Response.Redirect("aspnet_Roles_list.aspx");
}

protected void btnSearch_Click( object sender,  System.EventArgs e)
{
    string  sWhere = "";
    ParameterCollection Params = new ParameterCollection();
    string  sValue = "";
    string  sValue2 = "";
    htPeramaspnet_Roles.Add("rb", rbAnd.Checked);

    htPeramaspnet_Roles.Add("ddlOperation_RoleName", ddlOperation_RoleName.SelectedValue);
    htPeramaspnet_Roles.Add("chNot_RoleName", chNot_RoleName.Checked);

    sValue = fldRoleName.Text;
    sValue2 = fld2RoleName.Text;

    if(sValue != string.Empty) htPeramaspnet_Roles.Add("fldRoleName", sValue);
    if(sValue2 != string.Empty) htPeramaspnet_Roles.Add("fld2RoleName", sValue2);
  
    sWhere = func.WhereBuilder(sWhere, WhereOneField("[RoleName]",TypeCode.String, ddlOperation_RoleName.SelectedItem.Value.ToString(), 
            sValue, sValue2, Params, chNot_RoleName.Checked), (rbAnd.Checked?"And":"Or"));            
    
    if ( sWhere.Trim() == "" ) 
    {
            Session["dbGrid_aspnet_Roles_AdvSearch"] = null;
            Session["dbGrid_aspnet_Roles_AdvParam"] = null;
            Session["htPeramaspnet_Roles"] = null;
    }
    else 
    {
            Session["dbGrid_aspnet_Roles_AdvSearch"] = "(" + sWhere +")";
            Session["dbGrid_aspnet_Roles_AdvParam"] = Params;
            Session["htPeramaspnet_Roles"] = htPeramaspnet_Roles;
    }
    Response.Redirect("aspnet_Roles_list.aspx");

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

   