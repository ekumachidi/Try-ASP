using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddManufacturer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        string manufaturerName = txtManufacturer.Text.Trim().ToUpper();
        try
        {
            string connString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ToString();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("insert_manufacturer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlTransaction myTran = con.BeginTransaction();
            cmd.Transaction = myTran;
            SqlParameter paramID = new SqlParameter("@paramID", SqlDbType.Int);
            paramID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramID);
            SqlParameter paramName = new SqlParameter("@paramName", SqlDbType.VarChar);
            paramName.Value = manufaturerName;
            //paramName.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramName);
            cmd.ExecuteNonQuery();
            myTran.Commit();
            con.Close();
            txtManufacturer.Text = "";
            grdManufacturer.DataBind();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}