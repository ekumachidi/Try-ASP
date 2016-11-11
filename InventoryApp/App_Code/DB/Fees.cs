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
/// Summary description for Fees
/// </summary>
public class Fees
{
	public Fees()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static bool  HasStudentPaidschoolFeesInSession(string profileId, string sessionid)
    {
       
        try
        {
            DataSet dsRefcode = ConnectDB.LoadDatasource("Select * from SCHOOL_FEES_PAYMENT_LOG where STUDENT_PERSONAL_DATA_ID ='" + profileId + "' AND PAYMENT_SESSION_ID ='" + sessionid + "'");
            if (dsRefcode != null)
            {
                if (dsRefcode.Tables[0].Rows.Count > 0)
                {

                   return true ;

                }
            }
        }
        catch (Exception ex)
        {

            ;
        }
        return false ;

    }

}
