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
using System.Web.SessionState;
/// <summary>
/// Summary description for ConnectDB
/// </summary>
public class ConnectDB
{
	public ConnectDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
  

    public static DataSet LoadDatasource(string querystring)
    {

        try
        {
            string constring = ConfigurationManager.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand(querystring, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataAdapter myAdp = new SqlDataAdapter();
            myAdp.SelectCommand = cmd;
            DataSet ds = new DataSet();
            ds.Clear();
            myAdp.Fill(ds);
            con.Close();
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return null;


    }

  

    public static bool UpdateDatasource(string querystring)
    {

        try
        {
            string constring = ConfigurationManager.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand(querystring, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
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

    public static bool IsProfileUserAdminSupplied(System.Web.HttpResponse response)
    {
        try
        {
            string userid = "";
            string rolename = "";
            try
            {
                userid = Membership.GetUser(HttpContext.Current.User.Identity.Name.ToString()).ProviderUserKey.ToString();
                rolename = Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name.ToString()).GetValue(0).ToString();
            }
            catch (Exception ex)
            {
                LogOutUser(response);
                return false;
            }



            System.Collections.ArrayList roles = new System.Collections.ArrayList();
            roles.Clear();
            DataSet dsRole = LoadDatasource("Select * from aspnet_Roles where RoleName not in ('Student','Guest','PG Guest')");
            if (dsRole != null)
            {
                if (dsRole.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsRole.Tables[0].Rows.Count; i++)
                    {
                        roles.Add(Convert.ToString(dsRole.Tables[0].Rows[i]["RoleName"]));
                    }
                }
            }

            
            return true;
        }
        catch (Exception ex)
        {

            throw ex;
        }

        return false;
    }


    public static string GetASPNetUserId(string username)
    {
       string Userid ="";
        try{

            DataSet dsUser =ConnectDB.LoadDatasource("Select * from aspnet_Users where UserName ='" + username + "'");
            if(dsUser != null )
            {
                if(dsUser.Tables[0].Rows.Count >0)
                {
                   Userid = Convert.ToString(dsUser.Tables[0].Rows[0]["UserId"]);


                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Userid ;
    }

    public static string GetASPNetRoleId(string username)
    {
        string Userid = "";
        try
        {
            string userid = ConnectDB.GetASPNetUserId(username);

            DataSet dsUser = ConnectDB.LoadDatasource("Select * from aspnet_UsersInRoles where UserId ='" + userid  + "'");
            if (dsUser != null)
            {
                if (dsUser.Tables[0].Rows.Count > 0)
                {
                    Userid = Convert.ToString(dsUser.Tables[0].Rows[0]["RoleId"]);


                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Userid;
    }


    public static bool LockUser(string userid)
    {
        try
        {

            if (UpdateDatasource("Update aspnet_Membership set IsApproved ='False' where UserId ='" + userid + "'"))
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

    public static void DisplayHeaderDetails(Guid userid ,ref  string fullname, ref string passport)
    {
        try
        {
            string constring = ConfigurationManager.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("STP_DISPLAY_HEADER_DETAILS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlParameter RefCode = new SqlParameter("@RefCode", SqlDbType.UniqueIdentifier, 100);
            RefCode.Value = userid;
            RefCode.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(RefCode);

            SqlParameter FullNames = new SqlParameter("@FullNames", SqlDbType.VarChar, 500);
            FullNames.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(FullNames);

            SqlParameter PicUrl = new SqlParameter("@PicUrl", SqlDbType.VarChar, 100);
            PicUrl.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(PicUrl);

            SqlDataAdapter myAdp = new SqlDataAdapter();
            myAdp.SelectCommand = cmd;
            DataSet ds = new DataSet();
            ds.Clear();
            myAdp.Fill(ds);
            con.Close();
            fullname = Convert.ToString(cmd.Parameters["@FullNames"].Value);
            passport = Convert.ToString(cmd.Parameters["@PicUrl"].Value);

        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    public static bool UnLockUser(string userid)
    {
        try
        {

            if (UpdateDatasource("Update aspnet_Membership set IsApproved ='True' where UserId ='" + userid + "'"))
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

    public static bool SignOutUser()
    {
        try
        {
            string username = Convert.ToString(HttpContext.Current.User.Identity.Name.ToString());
            
            if (username.Trim() == "")
            {
                return false ;
            }
            string userid = ConnectDB.GetASPNetUserId(username);
            bool A = ConnectDB.UnLockUser(userid);
         
            FormsAuthentication.SignOut();
           
            return true;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return false;
    }

    public static bool SignUserOut(string username)
    {
        try
        {
             
            if (username.Trim() == "")
            {
                return false;
            }
            string userid = ConnectDB.GetASPNetUserId(username);
            bool A = ConnectDB.UnLockUser(userid);

            FormsAuthentication.SignOut();

            return true;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return false;
    }


    public static bool IsDefaultPasswordChanged(string username)

    {
        try
        {
            DataSet dsPassword = ConnectDB.LoadDatasource("Select * from aspnet_Membership where Password ='" + username + "'");
            if (dsPassword != null)
            {
                if (dsPassword.Tables[0].Rows.Count > 0)
                {
                    return false;
                }

            }
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return false;
    }

    public static Int64  InsertStaffProfile(string surname,string firstname,string middlename,string departmentid,string telephone,string sex,string refcode,string programme, string yearofstudy)
    {
        try
        {
            string constring = ConfigurationManager.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("STP_INSERT_STAFF_PROFILE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlParameter paramSURNAME = new SqlParameter("@paramSURNAME", SqlDbType.VarChar, 100);
            paramSURNAME.Value = surname;
            paramSURNAME.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSURNAME);

            SqlParameter paramFIRSTNAME = new SqlParameter("@paramFIRSTNAME", SqlDbType.VarChar, 100);
            paramFIRSTNAME.Value = firstname;
            paramFIRSTNAME.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramFIRSTNAME);

            SqlParameter paramMIDDLENAME = new SqlParameter("@paramMIDDLENAME", SqlDbType.VarChar, 100);
            paramMIDDLENAME.Value = middlename;
            paramMIDDLENAME.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramMIDDLENAME);

            SqlParameter paramDEPARTMENTID = new SqlParameter("@paramDEPARTMENTID", SqlDbType.VarChar, 100);
            paramDEPARTMENTID.Value = departmentid;
            paramDEPARTMENTID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramDEPARTMENTID);

            SqlParameter paramTELEPHONE = new SqlParameter("@paramTELEPHONE", SqlDbType.VarChar, 100);
            paramTELEPHONE.Value = telephone ;
            paramTELEPHONE.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramTELEPHONE);

            SqlParameter paramSEX = new SqlParameter("@paramSEX", SqlDbType.VarChar, 100);
            paramSEX.Value = sex ;
            paramSEX.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSEX);

            
            SqlParameter PortalRef = new SqlParameter("@PortalRef", SqlDbType.VarChar, 100);
            PortalRef.Value = refcode;
            PortalRef.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(PortalRef);

            SqlParameter paramPROGRAMME = new SqlParameter("@paramPROGRAMME", SqlDbType.VarChar, 100);
            paramPROGRAMME.Value = programme;
            paramPROGRAMME.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramPROGRAMME);

            SqlParameter paramYEAROFSTUDY = new SqlParameter("@paramYEAROFSTUDY", SqlDbType.VarChar, 100);
            paramYEAROFSTUDY.Value = yearofstudy;
            paramYEAROFSTUDY.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramYEAROFSTUDY);


            cmd.ExecuteNonQuery();
            con.Close();
            return 1;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        return 0;
    }

    public static Int64 InsertStaffProfileDetails(string departmentid, string refcode, string programme, string yearofstudy)
    {
        try
        {
            string constring = ConfigurationManager.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("STP_INSERT_STAFF_PROFILE_DETAILS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

           
            SqlParameter paramDEPARTMENTID = new SqlParameter("@paramDEPARTMENTID", SqlDbType.VarChar, 100);
            paramDEPARTMENTID.Value = departmentid;
            paramDEPARTMENTID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramDEPARTMENTID);

          
            SqlParameter PortalRef = new SqlParameter("@PortalRef", SqlDbType.VarChar, 100);
            PortalRef.Value = refcode;
            PortalRef.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(PortalRef);

            SqlParameter paramPROGRAMME = new SqlParameter("@paramPROGRAMME", SqlDbType.VarChar, 100);
            paramPROGRAMME.Value = programme;
            paramPROGRAMME.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramPROGRAMME);

            SqlParameter paramYEAROFSTUDY = new SqlParameter("@paramYEAROFSTUDY", SqlDbType.VarChar, 100);
            paramYEAROFSTUDY.Value = yearofstudy;
            paramYEAROFSTUDY.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramYEAROFSTUDY);


            cmd.ExecuteNonQuery();
            con.Close();
            return 1;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        return 0;
    }


    public static Int64 GetStudentProfileId(string UsernameRefcodeId)
    {
        Int64 StudentId = 0;
        try
        {
            DataSet dsRefcode = ConnectDB.LoadDatasource("Select * from STUDENT_PERSONAL_DATA where REF_CODE ='" + UsernameRefcodeId + "'");
            if (dsRefcode != null)
            {
                if (dsRefcode.Tables[0].Rows.Count > 0)
                {

                    StudentId = Convert.ToInt64(dsRefcode.Tables[0].Rows[0]["STUDENT_ID"]);

                }
            }
        }
        catch (Exception ex)
        {

            return -1;
        }
        return StudentId;

    }


    public static string  GetStudentProfileRefCodeId(string studentId)
    {
        string  StudentId = "";
        try
        {
            DataSet dsRefcode = ConnectDB.LoadDatasource("Select * from STUDENT_PERSONAL_DATA where STUDENT_ID ='" + studentId + "'");
            if (dsRefcode != null)
            {
                if (dsRefcode.Tables[0].Rows.Count > 0)
                {

                    StudentId = Convert.ToString(dsRefcode.Tables[0].Rows[0]["REF_CODE"]);

                }
            }
        }
        catch (Exception ex)
        {

           throw ex;
        }
        return StudentId;

    }


    public static void ChangeGuestRoleToStudentRoleAndReloadMenuPage(string username, System.Web.HttpResponse response)
    {
        try
        {
            string role = Roles.GetRolesForUser(username).GetValue(0).ToString();
            string newrolename = "Student";

            Roles.RemoveUserFromRole(username, role);
            Roles.AddUserToRole(username, newrolename);

            response.Write("<script>parent.frames['menu'].location.href='../../menu.aspx';</script>");
            
        }
        catch
            (Exception ex)
        {
            throw ex;
        }
    }

    public static void LogOutUser(System.Web.HttpResponse response)
    {
        try
        {
            response.Redirect("~/Logout.aspx");
            response.Write("<script>parent.frames['menu'].location.href='../../menu.aspx';</script>");

        }
        catch
            (Exception ex)
        {
            throw ex;
        }
    }


    public static string GetUserSchoolProgrammeId(string userid)
    {
        string programmeid = "";
        try
        {
            DataSet dsprogramme = LoadDatasource("Select * from STUDENT_PERSONAL_DATA S,STUDENT_PROGRAMME_DETAILS P where S.STUDENT_ID =P.STUDENT_ID and S.REF_CODE ='" + userid + "'");
            if (dsprogramme != null)
            {
                if(dsprogramme.Tables[0].Rows.Count >0)
                {
                    programmeid = Convert.ToString(dsprogramme.Tables[0].Rows[0]["STUDENT_TYPE_ID"]);

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return programmeid;
    }


    public static string GetCheckAdmissionRedirectUrl(string programmeid)
    {
        string url = "";
        try
        {
            DataSet dsURL = LoadDatasource("Select * from CHECK_ADMISSION_ASSIGNMENT where STUDENT_TYPE_ID ='" + programmeid + "'");
            if (dsURL != null)
            {
                if (dsURL.Tables[0].Rows.Count > 0)
                {
                    url = Convert.ToString(dsURL.Tables[0].Rows[0]["URL"]);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return url;
    }

    public static DataSet GetStudentdata(string refcode)
    {
        try
        {
            DataSet dsData = LoadDatasource("Select * from WV_STUDENT_PERSONAL_DETAILS where REF_CODE ='" + refcode + "'");

            return dsData;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return null;
    }

    public static DataSet GetStudentPersonaldata(string studentid)
    {
        try
        {
            DataSet dsData = LoadDatasource("Select * from STUDENT_PERSONAL_DATA where STUDENT_ID ='" + studentid + "'");

            return dsData;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return null;
    }

    public static DataSet GetStudentPersonaldataByRefCode(string RefCode)
    {
        try
        {
            DataSet dsData = LoadDatasource("Select * from STUDENT_PERSONAL_DATA where REF_CODE ='" + RefCode + "'");

            return dsData;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return null;
    }


    public static DataSet GetStudentSponsordetails(string studentid)
    {
        try
        {
            DataSet dsData = LoadDatasource("Select * from STUDENT_SPONSOR_DETAILS where STUDENT_ID ='" + studentid + "'");

            return dsData;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return null;
    }

    public static DataSet GetStudentNextOKindetails(string studentid)
    {
        try
        {
            DataSet dsData = LoadDatasource("Select * from STUDENT_NEXT_OF_KIN where STUDENT_ID ='" + studentid + "'");

            return dsData;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return null;
    }
    public static DataSet GetStudentProgrammedetails(string studentid)
    {
        try
        {
            DataSet dsData = LoadDatasource("Select * from STUDENT_PROGRAMME_DETAILS where STUDENT_ID ='" + studentid + "'");

            return dsData;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return null;
    }

    public static string GetSession(string sessionid)
    {
        string session = "";
        try
        {
            DataSet dssession = LoadDatasource("Select * from SESSION where SESSION_ID ='" + sessionid + "'");
            if (dssession != null)
            {
                if (dssession.Tables[0].Rows.Count > 0)
                {
                    session = Convert.ToString(dssession.Tables[0].Rows[0]["SESSION_NAME"]);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return session;
    }

    public static string GetSemester(string semesterid)
    {
        string Semester = "";
        try
        {
            DataSet dsSemester = LoadDatasource("Select * from SEMESTER where SEMESTER_ID ='" + semesterid + "'");
            if (dsSemester != null)
            {
                if (dsSemester.Tables[0].Rows.Count > 0)
                {
                    Semester = Convert.ToString(dsSemester.Tables[0].Rows[0]["SEMESTER_NAME"]);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return Semester;
    }

    public static string GetStaffDepartmentId(string refcode)
    {
        string deptid = "";
        try
        {
            DataSet dsStaff = LoadDatasource("Select * from STAFF_BASE_PROFILE where REF_CODE ='" + refcode + "'");
            if (dsStaff != null)
            {
                if (dsStaff.Tables[0].Rows.Count > 0)
                {
                    deptid = Convert.ToString(dsStaff.Tables[0].Rows[0]["department"]); 
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return deptid;
    }

    public static string GetStaffProgrammeId(string refcode)
    {
        string deptid = "";
        try
        {
            DataSet dsStaff = LoadDatasource("Select * from STAFF_BASE_PROFILE where REF_CODE ='" + refcode + "'");
            if (dsStaff != null)
            {
                if (dsStaff.Tables[0].Rows.Count > 0)
                {
                    deptid = Convert.ToString(dsStaff.Tables[0].Rows[0]["PROGRAMME"]);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return deptid;
    }

    public static string GetStaffYearId(string refcode)
    {
        string deptid = "";
        try
        {
            DataSet dsStaff = LoadDatasource("Select * from STAFF_BASE_PROFILE where REF_CODE ='" + refcode + "'");
            if (dsStaff != null)
            {
                if (dsStaff.Tables[0].Rows.Count > 0)
                {
                    deptid = Convert.ToString(dsStaff.Tables[0].Rows[0]["YEAR_OF_STUDY"]);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return deptid;
    }


    public static bool UpdateUserAccount(string Regno, Guid userid, string studentType)
    {
        try
        {
            string constring = ConfigurationManager.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("STP_USER_ACCOUNT_UPDATE_USER_ACCOUNT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlParameter paramREGNO = new SqlParameter("@paramREGNO", SqlDbType.VarChar, 70);
            paramREGNO.Value = Regno;
            paramREGNO.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramREGNO);

            SqlParameter paramUSERID = new SqlParameter("@paramUSERID", SqlDbType.UniqueIdentifier, 100);
            paramUSERID.Value =userid;
            paramUSERID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramUSERID);

            SqlParameter paramSTUDENTTYPEID = new SqlParameter("@paramSTUDENTTYPEID", SqlDbType.VarChar, 10);
            paramSTUDENTTYPEID.Value = studentType;
            paramSTUDENTTYPEID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramSTUDENTTYPEID);

           
            cmd.ExecuteNonQuery();
            con.Close();
            return true ;




        }
        catch (Exception ex)
        {
            throw ex;
        }
        return false;
    }

    public static string GetStudentTypeIdFromAccountDetails(string id)
    {
        string userid = "";
        try
        {
            DataSet dsUserid = LoadDatasource("Select * from aspnet_Users where UserId ='" + id + "'");
            if (dsUserid != null)
            {
                if (dsUserid.Tables[0].Rows.Count > 0)
                {
                    userid = Convert.ToString(dsUserid.Tables[0].Rows[0]["StudentType"]);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return userid;
    }


    
}
