using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
public partial class UpdateProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            PopulateManufacturer();
            PopulateCategory();
            try
            {
                SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

                myConnection.Open();
                SqlCommand sql = new SqlCommand("SELECT* FROM VW_PRODUCTS where ID="+id, myConnection);
                SqlDataReader reader =  sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    ProductName.Text = reader["PRODUCT_NAME"].ToString();
                    Price.Text = reader["PRICE"].ToString();
                }
                reader.Close();
                myConnection.Close();



            }

            catch
            {
                Response.Write("No Record Found!");



            }
        }

    }
    private void PopulateManufacturer()
    {
        try
        {
            ddManufacturer.Items.Clear();
            ddManufacturer.Items.Add("Select Manufacturer");
            string manufacturer = "";
            string manufacturerid = "";
            DataSet dsManufacturer = ConnectDB.LoadDatasource("Select * from MANUFACTURERS where Activated ='True' order by ID");
            if (dsManufacturer != null)
            {
                if (dsManufacturer.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsManufacturer.Tables[0].Rows.Count; i++)
                    {
                        manufacturer = Convert.ToString(dsManufacturer.Tables[0].Rows[i]["MANUFACTURER_NAME"]);
                        manufacturerid = Convert.ToString(dsManufacturer.Tables[0].Rows[i]["ID"]);
                        ddManufacturer.Items.Add(new ListItem(manufacturer, manufacturerid));

                    }


                }
            }

        }
        catch (Exception ex)
        {
            ErrorMessage.Text = "Error : " + ex.Message;
        }


    }

    private void PopulateCategory()
    {
        try
        {
            ddCategory.Items.Clear();
            ddCategory.Items.Add("Select Category");
            string category = "";
            string category_id = "";
            DataSet dsCategory = ConnectDB.LoadDatasource("Select * from CATEGORIES where Activated ='True' order by ID");
            if (dsCategory != null)
            {
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsCategory.Tables[0].Rows.Count; i++)
                    {
                        category = Convert.ToString(dsCategory.Tables[0].Rows[i]["CATEGORY_NAME"]);
                        category_id = Convert.ToString(dsCategory.Tables[0].Rows[i]["ID"]);
                        ddCategory.Items.Add(new ListItem(category, category_id));

                    }


                }
            }

        }
        catch (Exception ex)
        {
            ErrorMessage.Text = "Error : " + ex.Message;
        }


    }

    protected void btnUpdateProduct_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.AppSettings["ConnStr"];
        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("STP_UPDATE_PRODUCT", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        SqlTransaction myTran = conn.BeginTransaction();
        try
        {
            String productname = ProductName.Text;
            String price = Price.Text;
            String manufacturer = ddManufacturer.SelectedValue;
            String category = ddCategory.SelectedValue;
            ErrorMessage.Text = "";
            cmd.Transaction = myTran;

            SqlParameter paramID = new SqlParameter("@paramID", SqlDbType.Int);
            paramID.Value = Convert.ToInt32(Request.QueryString["id"]);
            paramID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramID);

            SqlParameter paramPRODUCT_NAME = new SqlParameter("@paramPRODUCT_NAME", SqlDbType.VarChar, 50);
            paramPRODUCT_NAME.Value = productname;
            paramPRODUCT_NAME.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramPRODUCT_NAME);

            SqlParameter paramMANUFACTURER_ID = new SqlParameter("@paramMANUFACTURER_ID", SqlDbType.Int);
            paramMANUFACTURER_ID.Value = manufacturer;
            paramMANUFACTURER_ID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramMANUFACTURER_ID);

            SqlParameter paramPRICE = new SqlParameter("@paramPRICE", SqlDbType.VarChar, 10);
            paramPRICE.Value = price;
            paramPRICE.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramPRICE);

            SqlParameter paramCATEGORY_ID = new SqlParameter("@paramCATEGORY_ID", SqlDbType.Int);
            paramCATEGORY_ID.Value = category;
            paramCATEGORY_ID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramCATEGORY_ID);

            SqlParameter paramADDED_BY = new SqlParameter("@paramADDED_BY", SqlDbType.VarChar, 50);
            paramADDED_BY.Value = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
            paramADDED_BY.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramADDED_BY);


            cmd.ExecuteNonQuery();
            ///////////////test data 
            
            myTran.Commit();
            conn.Close();

            PopulateManufacturer();
            PopulateCategory();
            ProductName.Text = "";
            Price.Text = "";
            ErrorMessage.Text = "Product was Updated successfully";
        }
        catch (Exception ex)
        {
            myTran.Rollback();
            conn.Close();
            ErrorMessage.Text = "Error :" + ex.Message + ". Please contact the administrator";
            return;
        }
    }
}