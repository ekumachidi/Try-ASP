using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

public partial class micModules_Utilities_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    

    public Int64 UpdatePassword()
    {

        string constr = ConfigurationManager.AppSettings["MIC1"];
        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("STP_USER_CHANGE_PASSWORD", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();

        SqlTransaction myTran = conn.BeginTransaction();
        try
        {

            //string OldPassword = txtbxOldPassword.Text.Trim();
            string userName = Session["USER"].ToString().Trim();//LogicalSecurityHandler.Decrypt(Request.QueryString["encrypt"]);
            //string newPassword = txtbxNewPassword.Text.Trim();
            //string operation = string.Format("{0} changed password from {1} to {2}", userName,newPassword);

            //lblError.Text = "";
            cmd.Transaction = myTran;


            #region
            //@paramUSERNAME NVARCHAR(50),
            //@paramPASSWORD NVARCHAR(50)

            //SqlParameter paramUSERNAME = new SqlParameter("@paramUSERNAME", SqlDbType.VarChar, 50);
            //paramUSERNAME.Value = userName;
            //paramUSERNAME.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(paramUSERNAME);

            //SqlParameter paramOPERATION = new SqlParameter("@paramOPERATION", SqlDbType.VarChar, 1000);
            //paramOPERATION.Value = operation;
            //paramOPERATION.Direction = ParameterDirection.Input;
            //cmd.Parameters.Add(paramOPERATION);

            //SqlParameter paramNEWPASSWORD = new SqlParameter("@paramNEWPASSWORD", SqlDbType.VarChar, 50);
            //paramNEWPASSWORD.Value = newPassword;
            //paramNEWPASSWORD.Direction = ParameterDirection.Input;
            //cmd.Parameters.Add(paramNEWPASSWORD);
            #endregion


            cmd.Parameters.AddWithValue("@paramUSERNAME", userName);
            //cmd.Parameters.AddWithValue("@paramOPERATION", operation);
            //cmd.Parameters.AddWithValue("@paramNEWPASSWORD", newPassword);
            
            
            Int64 ProfileId = cmd.ExecuteNonQuery();
            
            //if success, profileID = number of rows affected  
            //Int64 ProfileId = Convert.ToInt64(cmd.Parameters["@paramUSERNAME"].Value);

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
            //lblError.Text = "Error :" + ex.Message + ". Please contact the administrator";

        }
        return 0;
    }


    private void ShowMessage(string strMsg)
    {
        string csName = "popupScript";
        Type csType = this.GetType();
        ClientScriptManager cs = Page.ClientScript;

        if (!cs.IsStartupScriptRegistered(csType, csName))
        {
            String cstext = "alert('" + strMsg + "');";
            cs.RegisterStartupScript(csType, csName, cstext, true);
        }
    }

}