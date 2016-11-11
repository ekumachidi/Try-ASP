<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SearchSchMgr.Modules.Search" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
            width: 143px;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="ScriptManager1" runat="server" 
        EnableTheming="True">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.Core.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQuery.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQueryInclude.js">
            </asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <table style="width:100%;">
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem>Search Admission List</asp:ListItem>
                <asp:ListItem>Search Student's Profile</asp:ListItem>
                <asp:ListItem>Fees resolution</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label1" runat="server" Text="Student Name"></asp:Label>
        </td>
        <td>
            <telerik:RadSearchBox ID="RadSearchBox1" runat="server" DataTextField="fullname" 
                DataValueField="fullname" EmptyMessage="start typing a name or reg no" 
                Height="22px" MaxResultCount="10" Width="304px" 
                onsearch="RadSearchBox1_Search">
            </telerik:RadSearchBox>
            <asp:SqlDataSource ID="FeesDataSource" runat="server" 
                ConnectionString="<%$ ConnectionStrings:SchMgrDb_EBSUConnectionString %>" SelectCommand="SELECT (SURNAME +' '+ FIRSTNAME+' ' + MIDDLENAME+' - '+MATRIC_NO) AS fullname
 FROM [VW_SCHOOL_FEES_PAYMENT_LOG]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="StudentDataSource" runat="server" 
                ConnectionString="<%$ ConnectionStrings:SchMgrDb_EBSUConnectionString %>" SelectCommand="SELECT (SURNAME +' '+ FIRSTNAME+' ' + OTHERNAMES+' - '+REGNO) AS fullname
FROM [STUDENT_RECORD]"></asp:SqlDataSource>
            <asp:Label ID="lblTableName" runat="server" Visible="False"></asp:Label>
            <asp:SqlDataSource ID="AdmissionDataSource" runat="server" 
                ConnectionString="<%$ ConnectionStrings:SchMgrDb_EBSUConnectionString %>" 
                
                SelectCommand="SELECT (SURNAME +' '+ FIRSTNAME+' ' + OTHERNAMES+' - '+REGNO) AS fullname
FROM ADMISSION_LIST">
            </asp:SqlDataSource>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
            <asp:SqlDataSource ID="FeesGridDataSource" runat="server" 
                ConnectionString="<%$ ConnectionStrings:SchMgrDb_EBSUConnectionString %>" 
                
                SelectCommand="SELECT PAYMENT_PIN, SURNAME, FIRSTNAME, MIDDLENAME, MATRIC_NO, DEPARTMENT_NAME FROM VW_SCHOOL_FEES_PAYMENT_LOG WHERE (MATRIC_NO = @MATRIC_NO)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Label2" Name="MATRIC_NO" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="GridDataSource" runat="server" 
                ConnectionString="<%$ ConnectionStrings:SchMgrDb_EBSUConnectionString %>" 
                SelectCommand="SELECT [STUDENTNAME],[STATE_NAME], [LOCAL_GOVERNMENT_NAME],[SEX], [MATRIC_NO], [FACULTY_NAME], [DEPARTMENT_NAME] FROM [WV_STUDENT_PERSONAL_DETAILS] WHERE ([STUDENTNAME] = @STUDENTNAME)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="@RESULT" Name="STUDENTNAME" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
