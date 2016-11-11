using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class InsertItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnInsertItem_Click(object sender, EventArgs e)
    {
        string itemName = txtItemName.Text.Trim().ToUpper();
        try
        {
            string connString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ToString();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("insert_equipment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlTransaction myTran = con.BeginTransaction();
            cmd.Transaction = myTran;
            SqlParameter paramID = new SqlParameter("@paramID", SqlDbType.Int);
            paramID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramID);
            SqlParameter paramName = new SqlParameter("@paramName", SqlDbType.VarChar);
            paramName.Value = itemName;
            //paramName.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramName);
            SqlParameter paramManufacturerId = new SqlParameter("@paramManufaturerId", SqlDbType.Int);
            paramManufacturerId.Value = ddlManufacturer.SelectedValue;
            cmd.Parameters.Add(paramManufacturerId);
            SqlParameter paramCategory_Id = new SqlParameter("@paramCategoryId", SqlDbType.Int);
            paramCategory_Id.Value = ddlCategory.SelectedValue;
            cmd.Parameters.Add(paramCategory_Id);
            SqlParameter paramSerialNo = new SqlParameter ("@paramSerialNo",SqlDbType.VarChar);
            paramSerialNo.Value = txtSerialNo.Text;
            cmd.Parameters.Add(paramSerialNo);
            SqlParameter paramConditionId = new SqlParameter("@paramConditionId", SqlDbType.Int);
            paramConditionId.Value = ddlCondition.SelectedValue;
            cmd.Parameters.Add(paramConditionId);
            SqlParameter paramDateAdded = new SqlParameter("@paramDateAdded", SqlDbType.Date);
            paramDateAdded.Value = RadDatePicker.SelectedDate;
            cmd.Parameters.Add(paramDateAdded);
            SqlParameter paramQuantity = new SqlParameter("@paramQuantity", SqlDbType.Int);
            //paramQuantity.Value = txtQuantity.text;
            cmd.Parameters.Add(paramQuantity);
            SqlParameter paramLocationId = new SqlParameter("@paramLocationId", SqlDbType.Int);
            paramLocationId.Value = ddlLocation.SelectedValue;
            cmd.Parameters.Add(paramLocationId);
            SqlParameter paramComment = new SqlParameter("@paramComment", SqlDbType.VarChar);
            paramComment.Value = txtComment.Text;
            cmd.Parameters.Add(paramComment);
            cmd.ExecuteNonQuery();
            myTran.Commit();
            con.Close();            
        }
        catch (Exception ex)
        {            
            throw;
        }
    }
}