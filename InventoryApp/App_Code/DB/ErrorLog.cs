using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ErrorLog
/// </summary>
public class ErrorLog
{
	public ErrorLog()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static string  InsertErrorLog(string errorcode)
    {
        string err = "";
        try
        {
            string constring = ConfigurationManager.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("STP_ERROR_CODE_INSERT_ERROR_CODE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlParameter paramCODE = new SqlParameter("@paramCODE", SqlDbType.VarChar, 100);
            paramCODE.Direction = ParameterDirection.Output ;
            cmd.Parameters.Add(paramCODE);

            SqlParameter paramERROR = new SqlParameter("@paramERROR", SqlDbType.VarChar, 100);
            paramERROR.Value = errorcode ;
            paramERROR.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramERROR);

          
            cmd.ExecuteNonQuery();

            err = Convert.ToString(cmd.Parameters["@paramCODE"].Value);
          
            con.Close();

           


        }
        catch (Exception ex)
        {
           throw ex;
        }
        return err;
    }

}
