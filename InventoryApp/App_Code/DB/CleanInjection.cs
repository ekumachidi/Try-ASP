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
/// Summary description for CleanInjection
/// </summary>
public class CleanInjection
{
	public CleanInjection()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static  string  CleanInjectionData(string querystring)
    {

        try
        {

            return querystring.ToUpper().Replace("--", "").Replace("SOME", "").Replace("NOT", "").Replace("!", "").Replace("*", "").Replace("ALL", "").Replace("DROP", "").Replace("ALTER", "").Replace("SELECT", "").Replace("INSERT", "").Replace("DELETE", "").Replace("EXEC", "").Replace("SLEEP", "").Replace("SCRIPT", "").Replace("<", "").Replace(">", "");

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return "";


    }
}
