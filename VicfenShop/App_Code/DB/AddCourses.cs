using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO ;
using System.Data.OleDb;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AddCourses
/// </summary>
public class AddCourses
{
    private static string imagePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

	public AddCourses()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataSet UploadExcelFile( System.Web.UI.WebControls.FileUpload fileupload)
    {
        DataSet  Result = null ;
        try
        {
            string passportFolder = "/Modules/ExcelProcessor/File";

            // Get the name of the file to upload.
            string fileName = fileupload.FileName;
            string passPortFolderPath = "~/" + passportFolder;

            //Append the name of the file to upload to the path.
            string passportFolderPath1 = @imagePath + passportFolder;
            string fullPath = passPortFolderPath + "/" + fileName;

            //get the file extension
            FileInfo fi = new FileInfo(fullPath);
            string fileExtension = fi.Extension;

            //update file name and file path
            string jambRegNo = "UPLOAD";
            string matricNo = jambRegNo.Replace("/", "-").Replace(@"\", "-") + "-" + DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "");
            fileName = matricNo + fileExtension;
            fullPath = passPortFolderPath + "/" + fileName;

            //if folder does not already exist then create folder
            if (!Directory.Exists(passportFolderPath1))
            {
                Directory.CreateDirectory(passportFolderPath1);
            }

            if (fileupload.HasFile)
            {
                //check the selected file format
                if (fileExtension != ".xls" && fileExtension != ".XLSX" && fileExtension != ".xlsx" && fileExtension != ".XLSX")
                {
                    throw new Exception("This is not an excel file");
                    return null ;
                }


                //Call the SaveAs method to save the 
                //uploaded file to the specified path and
                //display the uploaded image
                fileupload.SaveAs(passportFolderPath1 + @"\" + fileName);



                string xConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + passportFolderPath1 + @"\" + fileName + ";" + "Extended Properties=Excel 8.0;";
                OleDbConnection connection = new OleDbConnection(xConnStr);
                OleDbCommand command = new OleDbCommand("Select * FROM [Sheet1$]", connection);
                connection.Open();
                // Create DbDataReader to Data Worksheet
                //OleDbDataReader dr = command.ExecuteReader();
                OleDbDataAdapter MyData = new OleDbDataAdapter();
                MyData.SelectCommand = command;
                DataSet ds = new DataSet();
                ds.Clear();
                MyData.Fill(ds);
                connection.Close();

                Result = ds;
            }
            else
            {

                throw new Exception("No Excel file is selected");
                return null;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Result;
    }

    public static Int64  InsertCourses(string CourseCode, string CourseTitle)
    {
        string constr = ConfigurationManager.AppSettings["ConnStr"];

        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("STP_COURSES_INSERT_COURSES", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
       
        //SqlTransaction myTran = conn.BeginTransaction();
            
        try
        {
            SqlParameter @paramID = new SqlParameter("@paramID", SqlDbType.BigInt, 70);
            @paramID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(@paramID);


            SqlParameter paramCOURSECODE = new SqlParameter("@paramCOURSECODE", SqlDbType.VarChar, 70);
            paramCOURSECODE.Value = CourseCode;
            paramCOURSECODE.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramCOURSECODE);


            SqlParameter paramCOURSETITLE = new SqlParameter("@paramCOURSETITLE", SqlDbType.VarChar, 370);
            paramCOURSETITLE.Value = CourseTitle;
            paramCOURSETITLE.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramCOURSETITLE);

                
                cmd.ExecuteNonQuery();

               //myTran.Commit();
                conn.Close();
                Int64 Id = Convert.ToInt64(cmd.Parameters["@paramID"].Value);
                return Id  ;

         

        }
        catch (Exception ex)
        {
            //myTran.Rollback();
            throw ex;
        }
       
        return 0;

    }

    public static Int64   UpdateCourses(string courseid,string CourseCode, string CourseTitle, bool Activated)
    {
        string constr = ConfigurationManager.AppSettings["ConnStr"];

        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("STP_COURSES_UPDATE_COURSES", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();

        //SqlTransaction myTran = conn.BeginTransaction();

        try
        {
            SqlParameter @paramID = new SqlParameter("@paramID", SqlDbType.BigInt, 70);
            @paramID.Value = courseid;
            @paramID.Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add(@paramID);
            
            SqlParameter paramCOURSECODE = new SqlParameter("@paramCOURSECODE", SqlDbType.VarChar, 70);
            paramCOURSECODE.Value = CourseCode;
            paramCOURSECODE.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramCOURSECODE);


            SqlParameter paramCOURSETITLE = new SqlParameter("@paramCOURSETITLE", SqlDbType.VarChar, 370);
            paramCOURSETITLE.Value = CourseTitle;
            paramCOURSETITLE.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramCOURSETITLE);

            SqlParameter paramACTIVATED = new SqlParameter("@paramACTIVATED", SqlDbType.Bit, 370);
            paramACTIVATED.Value = Activated;
            paramACTIVATED.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramACTIVATED);

            cmd.ExecuteNonQuery();

            //myTran.Commit();
            conn.Close();
            Int64 Id = Convert.ToInt64(cmd.Parameters["@paramID"].Value);
            return Id;

        }
        catch (Exception ex)
        {
            //myTran.Rollback();
            throw ex;
        }

        return 0 ;

    }

    public static Int64 InsertCourseType( string CourseType)
    {
        string constr = ConfigurationManager.AppSettings["ConnStr"];

        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("STP_COURSE_TYPE_INSERT_COURSE_TYPE", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();

        //SqlTransaction myTran = conn.BeginTransaction();

        try
        {
            SqlParameter @paramID = new SqlParameter("@paramID", SqlDbType.BigInt, 70);
            @paramID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(@paramID);


            SqlParameter paramCOURSETYPE = new SqlParameter("@paramCOURSETYPE", SqlDbType.VarChar, 170);
            paramCOURSETYPE.Value = CourseType;
            paramCOURSETYPE.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramCOURSETYPE);


            
            cmd.ExecuteNonQuery();

            //myTran.Commit();
            conn.Close();
            Int64 Id = Convert.ToInt64(cmd.Parameters["@paramID"].Value);
            return Id;



        }
        catch (Exception ex)
        {
            //myTran.Rollback();
            throw ex;
        }

        return 0;

    }

    public static Int64 UpdateCourseType(string CourseTypeid,string CourseType, bool Activated)
    {
        string constr = ConfigurationManager.AppSettings["ConnStr"];

        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("STP_COURSE_TYPE_UPDATE_COURSE_TYPE", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();

        //SqlTransaction myTran = conn.BeginTransaction();

        try
        {
            SqlParameter paramID = new SqlParameter("@paramID", SqlDbType.BigInt, 70);
            paramID.Value = CourseTypeid;
            paramID.Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add(paramID);


            SqlParameter paramCOURSETYPE = new SqlParameter("@paramCOURSETYPE", SqlDbType.VarChar, 170);
            paramCOURSETYPE.Value = CourseType;
            paramCOURSETYPE.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramCOURSETYPE);

           

            SqlParameter paramACTIVATED = new SqlParameter("@paramACTIVATED", SqlDbType.Bit, 1);
            paramACTIVATED.Value = Activated;
            paramACTIVATED.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramACTIVATED);

            cmd.ExecuteNonQuery();

            //myTran.Commit();
            conn.Close();
          
            Int64 Id = Convert.ToInt64(CourseTypeid);
            return Id;



        }
        catch (Exception ex)
        {
            //myTran.Rollback();
            throw ex;
        }

        return 0;

    }

    public static Int64 InsertAssignedCourses(string deptid,string studenttype,string yearofstudy,string semesterid,string courseid,string coursetype,string courseunit)
    {
        string constr = ConfigurationManager.AppSettings["ConnStr"];

        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("STP_COURSE_ASSIGNMENT_INSERT_COURSE_ASSIGNMENT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        try
        {

            SqlParameter paramID = new SqlParameter("@paramID", SqlDbType.BigInt, 70);
            paramID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramID);


            SqlParameter paramDEPARTMENTID = new SqlParameter("@paramDEPARTMENTID", SqlDbType.VarChar, 170);
            paramDEPARTMENTID.Value = deptid;
            paramDEPARTMENTID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramDEPARTMENTID);

            SqlParameter paramSTUDENTTYPEID = new SqlParameter("@paramSTUDENTTYPEID", SqlDbType.VarChar, 170);
            paramSTUDENTTYPEID.Value = studenttype;
            paramSTUDENTTYPEID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSTUDENTTYPEID);


            SqlParameter paramYEAROFSTUDYID = new SqlParameter("@paramYEAROFSTUDYID", SqlDbType.VarChar, 170);
            paramYEAROFSTUDYID.Value = yearofstudy;
            paramYEAROFSTUDYID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramYEAROFSTUDYID);


            SqlParameter paramSEMESTERID = new SqlParameter("@paramSEMESTERID", SqlDbType.VarChar, 170);
            paramSEMESTERID.Value = semesterid;
            paramSEMESTERID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSEMESTERID);


            SqlParameter paramCOURSEID = new SqlParameter("@paramCOURSEID", SqlDbType.VarChar, 170);
            paramCOURSEID.Value = courseid;
            paramCOURSEID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramCOURSEID);


            SqlParameter paramCOURSETYPEID = new SqlParameter("@paramCOURSETYPEID", SqlDbType.VarChar, 170);
            paramCOURSETYPEID.Value = coursetype;
            paramCOURSETYPEID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramCOURSETYPEID);

            SqlParameter paramCOURSEUNITID = new SqlParameter("@paramCOURSEUNITID", SqlDbType.VarChar, 170);
            paramCOURSEUNITID.Value = courseunit;
            paramCOURSEUNITID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramCOURSEUNITID);



            cmd.ExecuteNonQuery();

            //myTran.Commit();
            conn.Close();
            Int64 Id = Convert.ToInt64(cmd.Parameters["@paramID"].Value);
            return Id;


        }
        catch (Exception ex)
        {

            throw ex;
        }

        return 0;
    }

    public static bool  DeleteAssignedCourses(string id)
    {
        string constr = ConfigurationManager.AppSettings["ConnStr"];

        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("STP_COURSE_ASSIGNMENT_DELETE_COURSE_ASSIGNMENT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        try
        {

            SqlParameter paramID = new SqlParameter("@paramID", SqlDbType.BigInt, 70);
            paramID.Value = id;
            paramID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramID);


           
            cmd.ExecuteNonQuery();

            //myTran.Commit();
            conn.Close();
            
            return true ;


        }
        catch (Exception ex)
        {

            throw ex;
        }

        return false ;
    }

    public static bool UpdateActivationStatusForAssignedCourses(string id, bool status)
    {
        string constr = ConfigurationManager.AppSettings["ConnStr"];

        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("STP_COURSE_ASSIGNMENT_STATUS_UPDATE_COURSE_ASSIGNMENT_STATUS", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        try
        {

            SqlParameter paramID = new SqlParameter("@paramID", SqlDbType.BigInt, 70);
            paramID.Value = id;
            paramID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramID);

            SqlParameter paramSTATUS = new SqlParameter("@paramSTATUS", SqlDbType.Bit, 70);
            paramSTATUS.Value = status ;
            paramSTATUS.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSTATUS);



            cmd.ExecuteNonQuery();

            //myTran.Commit();
            conn.Close();

            return true;


        }
        catch (Exception ex)
        {

            throw ex;
        }

        return false;
    }


    public static Int64 ModifyUnitLoad(string deptid, string studenttype, string yearofstudy, string semesterid, string MaxUnit, string MinUnit)
    {
        string constr = ConfigurationManager.AppSettings["ConnStr"];

        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("STP_COURSE_UNIT_LOAD_MODIFY_COURSE_UNIT_LOAD", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        try
        {

            SqlParameter paramID = new SqlParameter("@paramID", SqlDbType.BigInt, 70);
            paramID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramID);


            SqlParameter paramDEPARTMENTID = new SqlParameter("@paramDEPARTMENTID", SqlDbType.VarChar, 170);
            paramDEPARTMENTID.Value = deptid;
            paramDEPARTMENTID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramDEPARTMENTID);

            SqlParameter paramSTUDENTTYPEID = new SqlParameter("@paramSTUDENTTYPEID", SqlDbType.VarChar, 170);
            paramSTUDENTTYPEID.Value = studenttype;
            paramSTUDENTTYPEID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSTUDENTTYPEID);


            SqlParameter paramYEAROFSTUDYID = new SqlParameter("@paramYEAROFSTUDYID", SqlDbType.VarChar, 170);
            paramYEAROFSTUDYID.Value = yearofstudy;
            paramYEAROFSTUDYID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramYEAROFSTUDYID);


            SqlParameter paramSEMESTERID = new SqlParameter("@paramSEMESTERID", SqlDbType.VarChar, 170);
            paramSEMESTERID.Value = semesterid;
            paramSEMESTERID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSEMESTERID);


            SqlParameter paramMAXUNIT = new SqlParameter("@paramMAXUNIT", SqlDbType.VarChar, 70);
            paramMAXUNIT.Value = MaxUnit;
            paramMAXUNIT.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramMAXUNIT);


            SqlParameter paramMINUNIT = new SqlParameter("@paramMINUNIT", SqlDbType.VarChar, 70);
            paramMINUNIT.Value = MinUnit;
            paramMINUNIT.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramMINUNIT);

           


            cmd.ExecuteNonQuery();

            //myTran.Commit();
            conn.Close();
            Int64 Id = Convert.ToInt64(cmd.Parameters["@paramID"].Value);
            return Id;


        }
        catch (Exception ex)
        {

            throw ex;
        }

        return 0;
    }

    public static bool IsCourseAssignforDepartment(string departmentid, string studenttypeid, string yearofstudyid, string semesterid)
    {
        try
        {

            DataSet dsCourse = ConnectDB.LoadDatasource("Select * from COURSE_ASSIGN_FOR_DEPARTMENT where SEMESTER_ID ='" + semesterid + "' and STUDENT_TYPE_ID ='" + studenttypeid + "' and DEPARTMENT_ID ='" + departmentid + "' and YEAR_OF_STUDY_ID ='" + yearofstudyid + "' AND ACTIVATED ='TRUE'");
            if (dsCourse != null)
            {
                if (dsCourse.Tables[0].Rows.Count > 0)
                {

                    return true;
                }
            }



        }
        catch (Exception ex)
        {
            throw ex;
        }
        return false;
    }

    public static bool IsUnitLoadAssignforDepartment(string departmentid, string studenttypeid, string yearofstudyid, string semesterid)
    {
        try
        {

            DataSet dsCourse = ConnectDB.LoadDatasource("Select * from COURSE_DEPARTMENT_UNIT_LOAD where SEMESTER_ID ='" + semesterid + "' and STUDENT_TYPE_ID ='" + studenttypeid + "' and DEPARTMENT_ID ='" + departmentid + "' and YEAR_OF_STUDY_ID ='" + yearofstudyid + "'");
            if (dsCourse != null)
            {
                if (dsCourse.Tables[0].Rows.Count > 0)
                {

                    return true;
                }
            }



        }
        catch (Exception ex)
        {
            throw ex;
        }
        return false;
    }

    public static bool HasStudentRegisteredCourse(string studentid, string sessionid, string semesterid)
    {
        try
        {

            DataSet dsCourse = ConnectDB.LoadDatasource("Select * from  COURSES_REGISTERED where STUDENT_ID ='" + studentid + "' AND SESSION_ID ='" + sessionid + "' AND SEMESTER_ID ='" + semesterid + "'");
            if (dsCourse != null)
            {
                if (dsCourse.Tables[0].Rows.Count > 0)
                {
                    return true ;
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return false;
    }

    public static bool HasStudentRegisteredCourseAndApproved(string studentid, string sessionid, string semesterid)
    {
        try
        {

            DataSet dsCourse = ConnectDB.LoadDatasource("Select * from  COURSES_REGISTERED where STUDENT_ID ='" + studentid + "' AND SESSION_ID ='" + sessionid + "' AND SEMESTER_ID ='" + semesterid + "' AND APPROVED ='TRUE'");
            if (dsCourse != null)
            {
                if (dsCourse.Tables[0].Rows.Count > 0)
                {
                    return true ;
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return false;
    }


    public static bool ActivateCoursesregistered(string studentid, string semesterid, string sessionid)
    {
        string constr = ConfigurationManager.AppSettings["ConnStr"];

        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("STP_COURSES_REGISTERED_ACTIVATE_COURSES_REGISTERED", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        try
        {

            SqlParameter paramSTUDENTID = new SqlParameter("@paramSTUDENTID", SqlDbType.BigInt, 70);
            paramSTUDENTID.Value = studentid ;
            paramSTUDENTID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSTUDENTID);

            SqlParameter paramSEMESTERID = new SqlParameter("@paramSEMESTERID", SqlDbType.VarChar, 70);
            paramSEMESTERID.Value = semesterid;
            paramSEMESTERID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSEMESTERID);

            SqlParameter paramSESSIONID = new SqlParameter("@paramSESSIONID", SqlDbType.VarChar, 70);
            paramSESSIONID.Value = sessionid;
            paramSESSIONID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSESSIONID);




            cmd.ExecuteNonQuery();

            //myTran.Commit();
            conn.Close();

            return true;


        }
        catch (Exception ex)
        {

            throw ex;
        }

        return false;
    }

    public static bool ModifyCoursesAssigned(string id, string coursetype,string courseunit, string sessionid)
    {
        string constr = ConfigurationManager.AppSettings["ConnStr"];

        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("STP_COURSES_ASSIGNED_MODIFY_COURSES_ASSIGNED", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        try
        {

            SqlParameter paramID = new SqlParameter("@paramID", SqlDbType.BigInt, 70);
            paramID.Value = id;
            paramID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramID);

            SqlParameter paramCOURSETYPEID = new SqlParameter("@paramCOURSETYPEID", SqlDbType.VarChar, 70);
            paramCOURSETYPEID.Value = coursetype;
            paramCOURSETYPEID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramCOURSETYPEID);

            SqlParameter paramCOURSEUNITID = new SqlParameter("@paramCOURSEUNITID", SqlDbType.VarChar, 70);
            paramCOURSEUNITID.Value = courseunit;
            paramCOURSEUNITID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramCOURSEUNITID);


            SqlParameter paramSESSIONID = new SqlParameter("@paramSESSIONID", SqlDbType.VarChar, 70);
            paramSESSIONID.Value = sessionid;
            paramSESSIONID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSESSIONID);




            cmd.ExecuteNonQuery();

            //myTran.Commit();
            conn.Close();

            return true;


        }
        catch (Exception ex)
        {

            throw ex;
        }

        return false;
    }

}
