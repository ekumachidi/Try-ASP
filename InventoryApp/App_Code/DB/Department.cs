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
/// Summary description for Department
/// </summary>
public class Department
{
	public Department()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static Int64 InsertDepartment(string department,string departmentid, string schoolid, string duration)
    {
        try
        {
            string constring = ConfigurationManager.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("STP_DEPARTMENT_INSERT_DEPARTMENT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlParameter paramID = new SqlParameter("@paramID", SqlDbType.BigInt, 10);
            paramID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramID);

            SqlParameter paramDEPARTMENT = new SqlParameter("@paramDEPARTMENT", SqlDbType.VarChar, 100);
            paramDEPARTMENT.Value = department;
            paramDEPARTMENT.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramDEPARTMENT);

            SqlParameter paramDEPARTMENTID = new SqlParameter("@paramDEPARTMENTID", SqlDbType.VarChar, 100);
            paramDEPARTMENTID.Value = departmentid;
            paramDEPARTMENTID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramDEPARTMENTID);

            SqlParameter paramSCHOOLID = new SqlParameter("@paramSCHOOLID", SqlDbType.VarChar, 6);
            paramSCHOOLID.Value = schoolid;
            paramSCHOOLID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSCHOOLID);

            SqlParameter paramDURATION = new SqlParameter("@paramDURATION", SqlDbType.BigInt);
            paramDURATION.Value = duration;
            paramDURATION.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramDURATION);


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


    public static bool UpdateDepartment(string dept,string deptid, string schoolid, bool activated, string duration)
    {
        try
        {
            string constring = ConfigurationManager.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("STP_DEPARTMENT_UPDATE_DEPARTMENT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();


            SqlParameter paramDEPARTMENT = new SqlParameter("@paramDEPARTMENT", SqlDbType.VarChar, 100);
            paramDEPARTMENT.Value = dept;
            paramDEPARTMENT.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramDEPARTMENT);

            SqlParameter paramDEPARTMENTID = new SqlParameter("@paramDEPARTMENTID", SqlDbType.VarChar, 100);
            paramDEPARTMENTID.Value = deptid;
            paramDEPARTMENTID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramDEPARTMENTID);

            SqlParameter paramSCHOOLID = new SqlParameter("@paramSCHOOLID", SqlDbType.VarChar, 6);
            paramSCHOOLID.Value = schoolid;
            paramSCHOOLID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSCHOOLID);

            SqlParameter paramACTIVATED = new SqlParameter("@paramACTIVATED", SqlDbType.Bit, 16);
            paramACTIVATED.Value = activated;
            paramACTIVATED.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramACTIVATED);

            SqlParameter paramDURATION = new SqlParameter("@paramDURATION", SqlDbType.BigInt);
            paramDURATION.Value = duration;
            paramDURATION.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramDURATION);


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
