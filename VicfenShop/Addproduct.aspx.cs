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
using System.Text;
using System.Security.Cryptography;

public partial class Addproduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            
            PopulateManufacturer();
            PopulateCategory();
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

    protected void btnCreateUser_Click(object sender, EventArgs e)
    {

        string constr = ConfigurationManager.AppSettings["ConnStr"];
        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("STP_PRODUCT_SAVE", conn);
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
            paramID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramID);

            SqlParameter paramPRODUCT_NAME = new SqlParameter("@paramPRODUCT_NAME", SqlDbType.VarChar, 50);
            paramPRODUCT_NAME.Value = productname;
            paramPRODUCT_NAME.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramPRODUCT_NAME);

            SqlParameter paramMANUFACTURER_ID = new SqlParameter("@paramMANUFACTURER_ID", SqlDbType.Int);
            paramMANUFACTURER_ID.Value = manufacturer;
            paramMANUFACTURER_ID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramMANUFACTURER_ID);

            SqlParameter paramPRICE = new SqlParameter("@paramPRICE", SqlDbType.VarChar,10);
            paramPRICE.Value = price;
            paramPRICE.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramPRICE);

            SqlParameter paramCATEGORY_ID = new SqlParameter("@paramCATEGORY_ID", SqlDbType.Int);
            paramCATEGORY_ID.Value =  category;
            paramCATEGORY_ID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramCATEGORY_ID);

            SqlParameter paramADDED_BY = new SqlParameter("@paramADDED_BY", SqlDbType.VarChar, 50);
            paramADDED_BY.Value = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
            paramADDED_BY.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramADDED_BY);


            cmd.ExecuteNonQuery();
            ///////////////test data 
            Int64 ProfileId = Convert.ToInt64(cmd.Parameters["@paramID"].Value);

            if (ProfileId < 0)
            {
                myTran.Rollback();
                conn.Close();
              
            }



            myTran.Commit();
            conn.Close();

            PopulateManufacturer();
            PopulateCategory();
            ProductName.Text ="";
            Price.Text ="";
            ErrorMessage.Text = "Product was added successfully";
        }
        catch (Exception ex)
        {
            myTran.Rollback();
            conn.Close();
            ErrorMessage.Text = "Error :" + ex.Message + ". Please contact the administrator";
            return;
        }
    



    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string text =null;
            string fileExt =
               System.IO.Path.GetExtension(FileUpload1.FileName);

            if (fileExt == ".mp3" || fileExt == ".jpg" || fileExt == ".png" || fileExt == ".gif" || fileExt == ".JPG" || fileExt == ".PNG" || fileExt == ".GIF")
            {
                try
                {
                    text = FileUpload1.FileName;
                    String photo = MD5Hash(text) + fileExt;
                  FileUpload1.SaveAs(Path.Combine(Server.MapPath("~/Uploads/" + photo)));
                    Label1.Text = "<img src='" + "Uploads/" + FileUpload1.FileName + "' style='height:100px; width:120px' />";
                    LabelPhoto.Text = "<img src='" + "Uploads/" + FileUpload1.FileName + "' style='height:100px; width:120px' />";
                }
                catch (Exception ex)
                {
                    Label1.Text = "ERROR: " + ex.Message.ToString();
                }
            }
            else
            {
                Label1.Text = "Only media files are allowed!";
            }
        }
        else
        {
            Label1.Text = "You have not specified a file.";
        }
    }

    public static string MD5Hash(string text)
    {
        MD5 md5 = new MD5CryptoServiceProvider();

        //compute hash from the bytes of text
        md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

        //get hash result after compute it
        byte[] result = md5.Hash;

        StringBuilder strBuilder = new StringBuilder();
        for (int i = 0; i < result.Length; i++)
        {
            //change it into 2 hexadecimal digits
            //for each byte
            strBuilder.Append(result[i].ToString("x2"));
        }

        return strBuilder.ToString();
    }
}