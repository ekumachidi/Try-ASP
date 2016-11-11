using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for UserUtil
/// </summary>
public class UserUtil
{
	public UserUtil()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Guid GetUserGuid()
    {
        MembershipUser user;
        user = Membership.GetUser(HttpContext.Current.User.Identity.Name);
        return (Guid)user.ProviderUserKey;

    }
}
