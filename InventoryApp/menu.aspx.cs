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
using System.Data.SqlClient;

public partial class menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //AuthenticationFilter.validateSession(Session, Response);

        try
        {

            tvMenu.Nodes.Clear();
            string username = HttpContext.Current.User.Identity.Name.ToString();
            string Roleid = ConnectDB.GetASPNetRoleId(username); ;
            string MAIN_MENU = "";
            string url = "";
            string Submenuname = "";
            DataSet dsRole = ConnectDB.LoadDatasource("Select distinct MAIN_MENU,PRIORITY from vw_main_menu WHERE Roleid ='" + Roleid + "' order by PRIORITY");
            if (dsRole != null)
            {
                if (dsRole.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsRole.Tables[0].Rows.Count; i++)
                    {
                        MAIN_MENU = Convert.ToString(dsRole.Tables[0].Rows[i]["MAIN_MENU"]);
                        TreeNode tn = new TreeNode();
                        tn.Text = MAIN_MENU;
                        tn.Value = MAIN_MENU;

                        DataSet dsSubMenu = ConnectDB.LoadDatasource("Select * from vw_main_menu WHERE Roleid ='" + Roleid + "' and MAIN_MENU ='" + MAIN_MENU + "' order by 1");
                        if (dsSubMenu != null)
                        {
                            if (dsSubMenu.Tables[0].Rows.Count > 0)
                            {
                                for (int j = 0; j < dsSubMenu.Tables[0].Rows.Count; j++)
                                {
                                    Submenuname = Convert.ToString(dsSubMenu.Tables[0].Rows[j]["MenuTitle"]);
                                    url = Convert.ToString(dsSubMenu.Tables[0].Rows[j]["URL"]);

                                    TreeNode child = new TreeNode();
                                    child.Text = Submenuname;
                                    child.NavigateUrl = url;
                                    child.Target = "mainFrame";
                                    tn.ChildNodes.Add(child);
                                }
                            }
                        }

                        tvMenu.Nodes.Add(tn);
                    }
                }
            }
            tvMenu.CollapseAll();
        }
        catch (Exception ex)
        {

            Response.Redirect("Logout.aspx");
        }
    }



    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
}
