using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace SearchSchMgr.Modules
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (lblTableName.Text=="ADMISSION_LIST")
            {
                RadSearchBox1.DataSource = AdmissionDataSource;
                RadSearchBox1.DataTextField = "fullname";
                RadSearchBox1.DataValueField = "fullname";
            }
            else if (lblTableName.Text=="STUDENT_RECORD")
            {
                RadSearchBox1.DataSource = StudentDataSource;
                RadSearchBox1.DataTextField = "fullname";
                RadSearchBox1.DataValueField = "fullname";
            }
            else if (lblTableName.Text == "Fees resolution")
            {
                RadSearchBox1.DataSource = FeesDataSource;
                RadSearchBox1.DataTextField = "fullname";
                RadSearchBox1.DataValueField = "fullname";
            }
        }       
        
        protected void RadSearchBox1_Search(object sender, Telerik.Web.UI.SearchBoxEventArgs e)
        {
            try
            {               
                RadSearchBox1.EmptyMessage = e.Text;
                string result = e.Text;
                string[] names = e.Text.Split(' ');
                string surname = names[0];
                string firstname = names[1];
                string othernames = names[2];
                Label2.Text = names[4];
                if (lblTableName.Text != "Fees resolution")
                {
                    DataSet dsData = ConnectDB.LoadDatasource("SELECT [SURNAME],[FIRSTNAME],[OTHERNAMES],[REGNO],[DEPARTMENT_ID]as Department FROM " + lblTableName.Text + " WHERE SURNAME = '" + surname + "'AND FIRSTNAME ='" + firstname + "' AND OTHERNAMES ='" + othernames + "'");
                    if (dsData != null)
                    {
                        if (dsData.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = dsData;
                            GridView1.DataBind();
                        }
                    }
                }
                else
                {
                    GridView1.DataSource = FeesGridDataSource;
                    GridView1.DataBind();
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        private string ReturnSelectedValue()
        {            
            if (RadioButtonList1.SelectedValue == "Search Admission List")
            {
                return "ADMISSION_LIST";                
            }
            else if (RadioButtonList1.SelectedValue == "Search Student's Profile")
            {
                return "STUDENT_RECORD";
            }
            else if (RadioButtonList1.SelectedValue == "Fees resolution")
            {
                return "Fees resolution";
            }
            else
            {
                return "";
            }
        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTableName.Text = ReturnSelectedValue();
        }                 
    }
}