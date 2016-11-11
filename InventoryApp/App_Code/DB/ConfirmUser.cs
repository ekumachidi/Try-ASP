using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.Security;


/// <summary>
/// Summary description for ConfirmUser
/// </summary>
public class ConfirmUser
{
	public ConfirmUser()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static bool IsUserAdmin(System.Web.HttpResponse response)
    {

        try
        {
            string userid = "";
            string rolename = "";
            try
            {
                userid = Membership.GetUser(HttpContext.Current.User.Identity.Name.ToString()).ProviderUserKey.ToString();
                rolename = Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name.ToString()).GetValue(0).ToString();
            }
            catch (Exception ex)
            {
             ConnectDB.LogOutUser(response);
                return false;
            }
            DataSet dsRefcode = ConnectDB.LoadDatasource("Select * from VW_ADMIN_ROLE WHERE USERID ='" + userid + "'");
            if (dsRefcode != null)
            {
                if (dsRefcode.Tables[0].Rows.Count > 0)
                {

                    return true;

                }
            }
        }
        catch (Exception ex)
        {

            ;
        }
        return false;

    }

}