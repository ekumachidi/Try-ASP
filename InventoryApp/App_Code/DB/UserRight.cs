using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Security;

/// <summary>
/// Summary description for UserRight
/// </summary>
public class UserRight
{
	public UserRight()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void   validateUser(string PageUrl, System.Web.HttpResponse response)
    {
        try
        {
            string userid = "";
            try
            {
                userid = Membership.GetUser(HttpContext.Current.User.Identity.Name.ToString()).ProviderUserKey.ToString();

            }
            catch (Exception ex)
            {
                response.Redirect("~/logout_processor.htm?err=x1", true);
            }
            string page = "";
            DataSet dsData = ConnectDB.LoadDatasource("Select * from aspnet_UsersInRoles U, PAGE_RIGHT P where P.ROLEID = U.RoleId and U.UserId ='" + userid + "'");
            if (dsData != null)
            {
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsData.Tables[0].Rows.Count; i++)
                    {
                        page = Convert.ToString(dsData.Tables[0].Rows[i]["PAGEURL"]).ToUpper();
                        if (PageUrl.ToUpper().Contains(page))
                        {
                            return;
                        }
 
                    }
					
                }
            }

                response.Redirect("~/logout_processor.htm?err=x1", true);

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

}