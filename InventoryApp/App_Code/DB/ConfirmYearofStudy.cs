using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ConfirmYearofStudy
/// </summary>
public class ConfirmYearofStudy
{
	public ConfirmYearofStudy()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static Int64   UpdateStudentYearofStudy(string Username)
    {
        string constr = ConfigurationManager.AppSettings["ConnStr"];

        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("STP_STUDENT_YEAR_OF_STUDY_UPDATE_STUDENT_YEAR_OF_STUDY", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();

        //SqlTransaction myTran = conn.BeginTransaction();

        try
        {

            SqlParameter paramOUTPUT = new SqlParameter("@paramOUTPUT", SqlDbType.BigInt, 100);
            paramOUTPUT.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramOUTPUT);


            SqlParameter paramREGNO = new SqlParameter("@paramREGNO", SqlDbType.VarChar, 100);
            paramREGNO.Value = Username;
            paramREGNO.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramREGNO);
                       

            cmd.ExecuteNonQuery();

            //myTran.Commit();
            conn.Close();

            Int64 A = Convert.ToInt64(cmd.Parameters["@paramOUTPUT"].Value);
            return A  ;



        }
        catch (Exception ex)
        {
            //myTran.Rollback();
            throw ex;
        }

        return 0 ;

    }

}