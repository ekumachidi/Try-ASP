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
/// Summary description for School
/// </summary>
public class School
{
	public School()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static Int64  InsertSchool(string school, string schoolid)
    {
        try
        {
            string constring = ConfigurationManager.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("STP_SCHOOL_INSERT_SCHOOL", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlParameter paramID = new SqlParameter("@paramID", SqlDbType.BigInt , 10);
            paramID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramID);

            SqlParameter paramSCHOOL = new SqlParameter("@paramSCHOOL", SqlDbType.VarChar, 100);
            paramSCHOOL.Value = school;
            paramSCHOOL.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSCHOOL);

            SqlParameter paramSCHOOLID = new SqlParameter("@paramSCHOOLID", SqlDbType.VarChar, 6);
            paramSCHOOLID.Value = schoolid;
            paramSCHOOLID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSCHOOLID);

           

            cmd.ExecuteNonQuery();
            con.Close();

            Int64 A = Convert.ToInt64(cmd.Parameters["@paramID"].Value);

            return A ;


        }
        catch (Exception ex)
        {
            throw ex;
            return -1;
        }
        return 0 ;
    }


    public static bool  UpdateSchool(string school, string schoolid, bool  activated)
    {
        try
        {
            string constring = ConfigurationManager.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("STP_SCHOOL_UPDATE_SCHOOL", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            
            SqlParameter paramSCHOOL = new SqlParameter("@paramSCHOOL", SqlDbType.VarChar, 100);
            paramSCHOOL.Value = school;
            paramSCHOOL.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSCHOOL);

            SqlParameter paramSCHOOLID = new SqlParameter("@paramSCHOOLID", SqlDbType.VarChar, 6);
            paramSCHOOLID.Value = schoolid;
            paramSCHOOLID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSCHOOLID);

            SqlParameter paramACTIVATED = new SqlParameter("@paramACTIVATED", SqlDbType.Bit , 16);
            paramACTIVATED.Value = activated;
            paramACTIVATED.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramACTIVATED);



            cmd.ExecuteNonQuery();
            con.Close();

            return true ;


        }
        catch (Exception ex)
        {
            throw ex;
            
        }
        return false ;
    }


}
