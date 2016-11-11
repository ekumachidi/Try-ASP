using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Viewproducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

            myConnection.Open();
            SqlCommand sql = new SqlCommand("SELECT* FROM VW_PRODUCTS", myConnection);
            SqlDataAdapter sqlda = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            sqlda.Fill(ds, "PRODUCTS");
            GridView2.DataSource = ds.Tables["PRODUCTS"];
            GridView2.DataBind();
            myConnection.Close();



        }

        catch
        {
            Response.Write("No Record Found!");
         
           

        }
    }

}