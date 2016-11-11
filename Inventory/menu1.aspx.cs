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
using Telerik.Web.UI;
using System.Web.Services;


public partial class menu1 : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //AuthenticationFilter.validateSession(Session, Response);
        try
        {
            RadPanelBar1.Items.Clear();
            //tvMenu.Nodes.Clear();
            string username = HttpContext.Current.User.Identity.Name.ToString();
            string Roleid = ConnectDB.GetASPNetRoleId(username);
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

                        RadPanelItem radPanelItem1 = new RadPanelItem();
                        //TreeNode tn = new TreeNode();
                        
                        radPanelItem1.Text = MAIN_MENU;
                        radPanelItem1.Value = MAIN_MENU;
                        //tn.Text = MAIN_MENU;
                        //tn.Value = MAIN_MENU;

                        DataSet dsSubMenu = ConnectDB.LoadDatasource("Select * from vw_main_menu WHERE Roleid ='" + Roleid + "' and MAIN_MENU ='" + MAIN_MENU + "' order by 1");
                        if (dsSubMenu != null)
                        {
                            if (dsSubMenu.Tables[0].Rows.Count > 0)
                            {
                                for (int j = 0; j < dsSubMenu.Tables[0].Rows.Count; j++)
                                {
                                    Submenuname = Convert.ToString(dsSubMenu.Tables[0].Rows[j]["MenuTitle"]);
                                    url = Convert.ToString(dsSubMenu.Tables[0].Rows[j]["URL"]);

                                    //TreeNode child = new TreeNode();
                                    RadPanelItem radPanelItem2 = new RadPanelItem();
                                    radPanelItem2.Text = Submenuname;
                                    radPanelItem2.NavigateUrl = url;
                                    //child.Target = "mainFrame";
                                    radPanelItem2.Target = "iframeSub";

                                    radPanelItem1.Items.Add(radPanelItem2);
                                    radPanelItem1.Font.Bold = true;
                                    //tn.ChildNodes.Add(child);
                                }
                            }
                        }
                        RadPanelBar1.Items.Add(radPanelItem1);
                        //tvMenu.Nodes.Add(tn);
                    }
                }
            }            
            RadPanelBar1.CollapseAllItems();
            //tvMenu.CollapseAll();
        }
        catch (Exception ex)
        {
            Response.Redirect("Logout.aspx");
        }
    }
}