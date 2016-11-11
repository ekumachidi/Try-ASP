using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Net;

public partial class micModules_Utilities_CreateUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthenticationFilter.validateSession(Session,Response);
        if (!Page.IsPostBack)
        {
            
            PopulateCampus();
            PopulateRole();

        }
    }

    private void PopulateCampus()
    {
        try
        {
            string campusName = "";
            string campusCode = "";
            ddlCampus.Items.Clear();
            ddlCampus.Items.Add("Select Campus");
            DataSet dsCampus = ConnectDB.LoadDatasource("Select * from CAMPUS where activated = 'True' order by Campus_ID");
            if (dsCampus != null)
            {
                if (dsCampus.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsCampus.Tables[0].Rows.Count; i++)
                    {
                        campusName = Convert.ToString(dsCampus.Tables[0].Rows[i]["Campus_Name"]);
                        campusCode = Convert.ToString(dsCampus.Tables[0].Rows[i]["Campus_Id"]);
                        ddlCampus.Items.Add(new ListItem(campusName, campusCode));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Error : " + ex.Message;
        }
    }

    private void PopulateRole()
    {
        try
        {
            string RoleName = "";
            string RoleId = "";
            ddlRole.Items.Clear();
            ddlRole.Items.Add("Select Role");
            DataSet dsROLE = ConnectDB.LoadDatasource("Select * from aspnet_Roles order by RoleName");
            if (dsROLE != null)
            {
                if (dsROLE.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsROLE.Tables[0].Rows.Count; i++)
                    {
                        RoleName = Convert.ToString(dsROLE.Tables[0].Rows[i]["RoleName"]);
                        RoleId = Convert.ToString(dsROLE.Tables[0].Rows[i]["RoleId"]);
                        ddlRole.Items.Add(new ListItem(RoleName, RoleId));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Error : " + ex.Message;
        }
    }


    protected void btnCreate_Click(object sender, EventArgs e)
    {
        try
        {
            string username = txtbxUsername.Text;
            string password = txtbxPassword.Text;
            
            bool IsUserValid = Membership.ValidateUser(username, password);

            if (IsUserValid == false)
            {
                try
                {
                    Membership.CreateUser(username, password);
                    

                }
                catch (Exception ex)
                {

                    lblStatus.Text = "Create User Failed! Try Again";
                    return;
                }

                string role = ddlRole.SelectedItem.Text;
                Roles.AddUserToRole(username, role);

                
                string userid = Membership.GetUser(username).ProviderUserKey.ToString();
                string user = HttpContext.Current.User.Identity.Name;

                string createOperation = user+" created account for "+username+" on "+DateTime.Now;

                Int64 idx = CreateUserCampusMap(userid, ddlCampus.SelectedValue, user, createOperation);


                if (idx <= 0)
                {
                    Roles.RemoveUserFromRole(username, Roles.GetRolesForUser(username).GetValue(0).ToString());
                    Membership.DeleteUser(username);
                    return;
                }

                lblNotif.Text = string.Format("Successfully Created Account! UserName: {0}; Password: {1}", username, password);
                RadNotification1.Show();
                Clear();

            }
            else
            {

                lblError.Text = "The User is already in the database !";
            }


        }
        catch ( Exception ex)
        {
            
            lblError.Text = ex.Message+"! Please contact the administrator";
        }
    }


    public Int64 CreateUserCampusMap(string userID, string campusID,string username,string operation)
    {
        string constr = ConfigurationManager.AppSettings["MIC1"];

        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("STP_INSERT_USER_CAMPUS", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();

        SqlTransaction myTran = conn.BeginTransaction();
        try
        {

            cmd.Transaction = myTran;

            lblError.Text = "";
            cmd.Transaction = myTran;


            SqlParameter paramID = new SqlParameter("@paramID", SqlDbType.BigInt,20);
            paramID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramID);

            SqlParameter paramUSER_ID = new SqlParameter("@paramUSER_ID", SqlDbType.VarChar,1000);
            paramUSER_ID.Value = userID;
            paramUSER_ID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramUSER_ID);

            SqlParameter paramCAMPUS_ID = new SqlParameter("@paramCAMPUS_ID", SqlDbType.VarChar,50);
            paramCAMPUS_ID.Value = campusID;
            paramCAMPUS_ID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramCAMPUS_ID);

            SqlParameter paramUSERNAME = new SqlParameter("@paramUSERNAME", SqlDbType.VarChar, 50);
            paramUSERNAME.Value = username;
            paramUSERNAME.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramUSERNAME);

            SqlParameter paramOPERATION = new SqlParameter("@paramOPERATION", SqlDbType.VarChar,1000);
            paramOPERATION.Value = operation;
            paramOPERATION.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramOPERATION);

            cmd.ExecuteNonQuery();


            ///////////////test data 
            Int64 ProfileId = Convert.ToInt64(cmd.Parameters["@paramID"].Value);


            if (ProfileId < 0)
            {
                myTran.Rollback();
                conn.Close();
                return ProfileId;
            }

            myTran.Commit();
            conn.Close();
            return ProfileId;
        }
        catch (Exception ex)
        {
            myTran.Rollback();
            conn.Close();
            lblError.Text = "Error :" + ex.Message + ". Please contact the administrator";
        }
        return 0;
    }

    private void Clear()
    {
        txtbxUsername.Text = "";
        txtbxPassword.Text = "";
        txtbxPasswordC.Text = "";
        ddlCampus.SelectedIndex = 0;
        ddlRole.SelectedIndex = 0;
    }
}