using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SearchSchMgr.Modules
{
    public partial class Attendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateClass();
                PopulateSession();
                PopulateCampus();    
            }
        }
        private void PopulateSession()
        {
            try
            {
                ddlSession.Items.Clear();
                ddlSession.Items.Add("Select Session");

                string session = "";
                string sessionid = "";
                DataSet dsSession = ConnectDB.LoadDatasource("Select * from SESSION where Activated ='True' order by 1");
                if (dsSession != null)
                {
                    if (dsSession.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsSession.Tables[0].Rows.Count; i++)
                        {
                            session = Convert.ToString(dsSession.Tables[0].Rows[i]["SESSION_NAME"]);
                            sessionid = Convert.ToString(dsSession.Tables[0].Rows[i]["SESSION_ID"]);
                            ddlSession.Items.Add(new ListItem(session, sessionid));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error : " + ex.Message;
            }
        }

        private void PopulateClass()
        {
            try
            {
                string classname = "";
                string id = "";
                ddlClass.Items.Clear();
                ddlClass.Items.Add("Select Class");
                DataSet dsData = ConnectDB.LoadDatasource("Select * from CLASS_NAME WHERE ACTIVATED ='TRUE' order by CLASS_NAME");
                if (dsData != null)
                {
                    if (dsData.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsData.Tables[0].Rows.Count; i++)
                        {
                            classname = Convert.ToString(dsData.Tables[0].Rows[i]["CLASS_NAME"]);
                            id = Convert.ToString(dsData.Tables[0].Rows[i]["CLASS_ID"]);
                            ddlClass.Items.Add(new ListItem(classname, id));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error : " + ex.Message;
            }
        }
        private void PopulateCampus()
        {
            try
            {
                ddlCampus.Items.Clear();
                ddlCampus.Items.Add("Select Campus");
                string Campus = "";
                string CampusId = "";
                DataSet dsCampus = ConnectDB.LoadDatasource("Select * from CAMPUS order by 1");
                if (dsCampus != null)
                {
                    if (dsCampus.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsCampus.Tables[0].Rows.Count; i++)
                        {
                            Campus = Convert.ToString(dsCampus.Tables[0].Rows[i]["Campus_Name"]);
                            CampusId = Convert.ToString(dsCampus.Tables[0].Rows[i]["Campus_ID"]);
                            ddlCampus.Items.Add(new ListItem(Campus, CampusId));
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            lblError.Text = "";            
        }
    }
}