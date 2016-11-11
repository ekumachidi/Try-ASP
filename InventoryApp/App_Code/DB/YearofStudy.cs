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
/// Summary description for YearofStudy
/// </summary>
public class YearofStudy
{
	public YearofStudy()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static Int64 InsertYearofstudy(string yearofstudy,  string programmeid)
    {
        try
        {
            string constring = ConfigurationManager.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("STP_YEAR_OF_STUDY_INSERT_YEAR_OF_STUDY", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlParameter paramID = new SqlParameter("@paramID", SqlDbType.BigInt, 10);
            paramID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramID);

            SqlParameter paramYEAROFSTUDY = new SqlParameter("@paramYEAROFSTUDY", SqlDbType.VarChar, 100);
            paramYEAROFSTUDY.Value = yearofstudy;
            paramYEAROFSTUDY.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramYEAROFSTUDY);

            

            SqlParameter paramPROGRAMMEID = new SqlParameter("@paramPROGRAMMEID", SqlDbType.VarChar, 6);
            paramPROGRAMMEID.Value =programmeid;
            paramPROGRAMMEID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramPROGRAMMEID);



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


    public static bool UpdateYearofstudy(string yearofstudy, string yearofstudyid, string schoolid, bool activated)
    {
        try
        {
            string constring = ConfigurationManager.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("STP_YEAR_OF_STUDY_UPDATE_YEAR_OF_STUDY", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();


            SqlParameter paramYEAROFSTUDY = new SqlParameter("@paramYEAROFSTUDY", SqlDbType.VarChar, 100);
            paramYEAROFSTUDY.Value = yearofstudy;
            paramYEAROFSTUDY.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramYEAROFSTUDY);

            //SqlParameter paramDEPARTMENTID = new SqlParameter("@paramDEPARTMENTID", SqlDbType.VarChar, 100);
            //paramDEPARTMENTID.Value = deptid;
            //paramDEPARTMENTID.Direction = ParameterDirection.Input;
            //cmd.Parameters.Add(paramDEPARTMENTID);

            SqlParameter paramSCHOOLID = new SqlParameter("@paramSCHOOLID", SqlDbType.VarChar, 6);
            paramSCHOOLID.Value = schoolid;
            paramSCHOOLID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSCHOOLID);

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
