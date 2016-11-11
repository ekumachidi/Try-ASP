using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
/// <summary>
/// Summary description for PageUserRight
/// </summary>
public class PageUserRight
{
	public PageUserRight()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public  static  bool IsPageinRole(string userid, string PageUrl)
    {
        try
        {
            string[] pageUrlData = PageUrl.Split('/');
            string Pagename = pageUrlData[pageUrlData.GetUpperBound(0)].ToString();
            ArrayList AryPageinRoles = new ArrayList();
            AryPageinRoles.Clear();
            DataSet dsData = ConnectDB.LoadDatasource("select  * from VW_USER_AND_ROLES where Userid ='" + userid + "'");
            if (dsData != null)
            {
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsData.Tables[0].Rows.Count; i++)
                    {
                        string[] PageRoleData = Convert.ToString(dsData.Tables[0].Rows[i]["URL"]).ToUpper().Split('/');
                        AryPageinRoles.Add(PageRoleData[PageRoleData.GetUpperBound(0)]);

                    }
                }
            }

            if (AryPageinRoles.Contains(Pagename))
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return false;
    }

    
    

}