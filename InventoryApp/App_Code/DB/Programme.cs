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
/// Summary description for Programme
/// </summary>
public class Programme
{
	public Programme()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static Int64 InsertProgramme(string programme)
    {
        try
        {
            string constring = ConfigurationManager.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("STP_PROGRAMME_INSERT_PROGRAMME", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlParameter paramID = new SqlParameter("@paramID", SqlDbType.BigInt, 10);
            paramID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramID);

            SqlParameter paramPROGRAMME = new SqlParameter("@paramPROGRAMME", SqlDbType.VarChar, 100);
            paramPROGRAMME.Value = programme;
            paramPROGRAMME.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramPROGRAMME);

           


            cmd.ExecuteNonQuery();
            con.Close();

            Int64 A = Convert.ToInt64(cmd.Parameters["@paramID"].Value);

            return A;


        }
        catch (Exception ex)
        {
            throw ex;
            return -1;
        }
        return 0;
    }


    public static bool UpdateProgramme(string programme, string programmeid, bool activated)
    {
        try
        {
            string constring = ConfigurationManager.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("STP_PROGRAMME_UPDATE_PROGRAMME", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();


            SqlParameter paramPROGRAMME = new SqlParameter("@paramPROGRAMME", SqlDbType.VarChar, 100);
            paramPROGRAMME.Value = programme;
            paramPROGRAMME.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramPROGRAMME);

            SqlParameter paramPROGRAMMEID = new SqlParameter("@paramPROGRAMMEID", SqlDbType.VarChar, 6);
            paramPROGRAMMEID.Value = programmeid;
            paramPROGRAMMEID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramPROGRAMMEID);

            SqlParameter paramACTIVATED = new SqlParameter("@paramACTIVATED", SqlDbType.Bit, 16);
            paramACTIVATED.Value = activated;
            paramACTIVATED.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramACTIVATED);



            cmd.ExecuteNonQuery();
            con.Close();

            return true;


        }
        catch (Exception ex)
        {
            throw ex;

        }
        return false;
    }
}
