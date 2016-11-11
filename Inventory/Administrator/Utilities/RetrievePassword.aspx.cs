using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using Telerik.Web.UI;

public partial class micModules_NEW_AddClasses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        AuthenticationFilter.validateSession(Session,Response);
        if(!Page.IsPostBack)
        {

            //On Page Load!
            string username = HttpContext.Current.User.Identity.Name;
            string userid = ConnectDB.GetASPNetUserId(username).ToString();

            String[] rolenames = new String[5];
            String rolename;

            rolenames = Roles.GetRolesForUser(username);//gets the roles for that particular logged in user
            rolename = (String)rolenames.GetValue(0);//gets the first role in rolenames

            if (!RoleCampusCheck.CheckPageRole(rolename))
            {
                gvUnlock.Columns[6].Visible = false;
                Button btnSwitchRole = gvUnlock.FindControl("btnSwitchRole") as Button;
                btnSwitchRole.Enabled = false;
            }

            TabContainer1.Tabs[0].Visible = true;
            TabContainer1.Tabs[1].Visible = false;
            TabContainer1.ActiveTabIndex = 0;
            Panel1.Visible = false;
        }
    }

    private void PopulateRole()
    {
        try
        {
            ddlRole.Items.Clear();
            ddlRole.Items.Add("Select Role");
            string role = "";
            string roleid = "";
            DataSet dsSession = ConnectDB.LoadDatasource("Select * from aspnet_Roles");
            if (dsSession != null)
            {
                if (dsSession.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsSession.Tables[0].Rows.Count; i++)
                    {
                        role = Convert.ToString(dsSession.Tables[0].Rows[i]["RoleName"]);
                        roleid = Convert.ToString(dsSession.Tables[0].Rows[i]["RoleId"]);
                        ddlRole.Items.Add(new ListItem(role, roleid));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblError2.Text = "Error : " + ex.Message;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string username = txtbUserName.Text;
            SqlDataSourcegvUnlock.SelectParameters["UserName"].DefaultValue = username;

            gvUnlock.DataBind();
            Panel1.Visible = true;
        }
        catch (Exception ex)
        {

            lblError.Text = ex.Message + " Contact Admin!";
        }
    }

    protected void gvUnlock_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Unlock")
        {
            
            string UserId = e.CommandArgument.ToString();
            UpdateLockStatus(UserId);
            UpdateApproveStatus(UserId);
            lblStatus.Text = "User Unlocked!";

            gvUnlock.DataBind();
        }

        if (e.CommandName == "SwitchRole")
        {
            TabContainer1.Tabs[0].Visible = false;
            TabContainer1.Tabs[1].Visible = true;
            TabContainer1.ActiveTabIndex = 1;
            btnUpdate.Visible = true;
            string UserId = e.CommandArgument.ToString();
            loadUserData(UserId);


        }
    }

    private void loadUserData(string UserId)
    {
        try
        {
            DataSet dsData = ConnectDB.LoadDatasource("Select * from vw_users_details where UserId ='" + UserId + "'");
            if (dsData != null)
            {
                if (dsData.Tables[0].Rows.Count > 0)
                {


                    lblUserID.Text = Convert.ToString(dsData.Tables[0].Rows[0]["UserId"]);
                    lblUserName.Text = Convert.ToString(dsData.Tables[0].Rows[0]["UserName"]);
                    lblPassword.Text = Convert.ToString(dsData.Tables[0].Rows[0]["Password"]);

                    PopulateRole();

                    DataSet dsUserInRole = ConnectDB.LoadDatasource("Select * from aspnet_UsersInRoles where UserId ='" + UserId + "'");
                    if (dsUserInRole != null)
                    {
                        if (dsUserInRole.Tables[0].Rows.Count > 0)
                        {


                            ddlRole.SelectedValue =  Convert.ToString(dsUserInRole.Tables[0].Rows[0]["RoleId"]);

                        }

                        
                    }

                    
                }


            }
        }
        catch (Exception ex)
        {
            lblError2.Text = "Error : " + ex.Message + " please contact the administrator.";

        }
    }

    
    public static bool UpdateDatasource(string querystring)
    {

        try
        {
            string constring = ConfigurationManager.AppSettings["MIC1"];
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand(querystring, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
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

    private void UpdateLockStatus(string userID)
    {
        try
        {
            UpdateDatasource("update aspnet_Membership set IsLockedOut = 'False' where UserId = '" + userID + "'");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    private void UpdateApproveStatus(string userID)
    {
        try
        {
            UpdateDatasource("update aspnet_Membership set IsApproved = 'True' where UserId = '"+userID+"'");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void lnkbtnBack_Click(object sender, EventArgs e)
    {
        TabContainer1.Tabs[0].Visible = true;
        TabContainer1.Tabs[1].Visible = false;

        Panel1.Visible = false;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string UserId = lblUserID.Text;
            string roleId = ddlRole.SelectedValue;
            UpdateDatasource("update aspnet_UsersInRoles set RoleId = '"+roleId+"' where UserId = '"+UserId+"'");

            lblNotif2.Text = "Update Successful!";
            RadNotification2.Show();
            btnUpdate.Visible = false;

        }
        catch (Exception ex)
        {
            
            lblError2.Text = "Error : " + ex.Message + " please contact the administrator.";
           
        }
    }
}