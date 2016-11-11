﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class AddCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            grdCategory.DataBind();
        }
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        string categoryName = txtCategory.Text.Trim().ToUpper();
        try
        {
            string connString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ToString();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("INSERT_CATEGORY", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlTransaction myTran = con.BeginTransaction();
            cmd.Transaction = myTran;
            SqlParameter paramID = new SqlParameter("@paramID", SqlDbType.Int);
            paramID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramID);
            SqlParameter paramName = new SqlParameter("@paramName", SqlDbType.VarChar);
            paramName.Value = categoryName;
            //paramName.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramName);
            cmd.ExecuteNonQuery();
            myTran.Commit();
            con.Close();
            txtCategory.Text = "";
            grdCategory.DataBind();
        }
        catch (Exception ex)
        {            
            throw;
        }
    }
}