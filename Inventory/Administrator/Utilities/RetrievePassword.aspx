<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RetrievePassword.aspx.cs" Inherits="micModules_NEW_AddClasses" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="RadInput.Net2" namespace="Telerik.WebControls" tagprefix="rad" %>
<%@ Register Assembly="RadCalendar.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style6
        {
            width: 52px;
        }
        .style8
        {
            width: 127px;
        }
        .style9
        {
            width: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
    <div align="center">
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
            Width="950px" ScrollBars="Auto" AutoPostBack="True" BorderStyle="None">
            <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="RETRIEVE PASSWORD">
                <ContentTemplate>
                    <div style=" width: 544px; font-family: candara; font-size: small;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="border-width: thick; border-color: #000000; font-family: Candara; font-size: large; font-weight: bold; text-align: center; border-bottom-style: solid;">
                                    RETRIEVE PASSWORD</td>
                            </tr>
                        </table>

                    </div>

                    <table style="text-align: justify; width: 396px; font-family: candara; font-size: small;">
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style8" style="font-weight: bold">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                        <tr>
                            <td class="style6">
                                &nbsp;</td>
                            <td class="style8" style="font-weight: bold">
                                ENTER USERNAME:</td>
                            <td>
                                <asp:TextBox ID="txtbUserName" runat="server" Width="146px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtbUserName" ErrorMessage="Please enter UserName?" 
                                    ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style8" style="font-weight: bold">
                        &nbsp;</td>
                    <td>
                                &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                        <tr>
                            <td class="style6">
                                &nbsp;</td>
                            <td style="font-weight: bold" class="style8">
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" BackColor="#CCCCCC" 
                                    BorderColor="#CC0000" BorderWidth="1px" Font-Bold="False" Font-Names="Calibri" 
                                    Font-Underline="False" ForeColor="#CC0000" 
                                    OnClick="btnSubmit_Click" style="margin-left: 0px; margin-right: 0px;" 
                                    Text="Submit" ValidationGroup="a" Width="109px" />
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
            </table>
                    <table style="width: 100%;">
                        <tr>
                            <td align="center" style="font-size: small; font-family: CANDAra">
                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                <asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center"  Height="190px" 
                        Width="740px" BorderStyle="Solid" BorderWidth="1px" ScrollBars="Auto" >
                        
                        <asp:GridView ID="gvUnlock" runat="server" Width="735px" 
                            AutoGenerateColumns="False" DataKeyNames="UserId" 
                            DataSourceID="SqlDataSourcegvUnlock" onrowcommand="gvUnlock_RowCommand">

                            <Columns>
                                <asp:BoundField DataField="UserId" HeaderText="UserId" ReadOnly="True" 
                                    SortExpression="UserId" Visible="False" />
                                <asp:BoundField DataField="UserName" HeaderText="UserName" 
                                    SortExpression="UserName" />
                                <asp:BoundField DataField="Password" HeaderText="Password" 
                                    SortExpression="Password" />
                                <asp:BoundField DataField="CreateDate" HeaderText="CreateDate" 
                                    SortExpression="CreateDate" />
                                <asp:CheckBoxField DataField="IsApproved" HeaderText="IsApproved" 
                                    SortExpression="IsApproved" />
                                <asp:CheckBoxField DataField="IsLockedOut" HeaderText="IsLockedOut" 
                                    SortExpression="IsLockedOut" />
                                <asp:TemplateField HeaderText="Unlock">
                                    <ItemTemplate>
                                        <asp:Button ID="btnUnlock" runat="server" Text="Unlock" 
                                        CommandArgument='<%# Eval("UserId") %>'  CommandName="Unlock" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Manage Role">
                                    <ItemTemplate>
                                        <asp:Button ID="btnSwitchRole" runat="server" Text="Role" 
                                        CommandArgument='<%# Eval("UserId") %>'  CommandName="SwitchRole" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                        <div align="center" 
                                            style="color: #FF0000; font-weight: bold; font-family: candara;">
                                            <table style="width:100%;">
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3">
                                                        &lt;&lt;No Records Found!&gt;&gt;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </div>
                                    </EmptyDataTemplate>
                            <HeaderStyle BackColor="#CC6600" Font-Names="Candara" Font-Size="Small" 
                                ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Center" />
                        </asp:GridView>
                        
                        <asp:SqlDataSource ID="SqlDataSourcegvUnlock" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:MIC1ConnectionString %>" 
                            
                            SelectCommand="SELECT * FROM [vw_users_details] WHERE ([UserName] = @UserName)">
                            <SelectParameters>
                                <asp:Parameter Name="UserName" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        
                    </asp:Panel>
                    
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="MANAGE USER ROLE">
            <ContentTemplate>
                    <div style=" width: 544px; font-family: candara; font-size: small;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="border-width: thick; border-color: #000000; font-family: Candara; font-size: large; font-weight: bold; text-align: center; border-bottom-style: solid;">
                                    MANAGE USER ROLE</td>
                            </tr>
                        </table>

                    </div>
                    <table style="text-align: justify; width: 366px; font-family: candara; font-size: small; margin-right: 0px;">
                <tr>
                    <td class="style9">
                        </td>
                    <td class="style11" align="center" colspan="2">
                        <asp:Label ID="lblUserID" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                        </td>
                    <td>
                        </td>
                    <td class="style5">
                        </td>
                </tr>
                <tr>
                    <td class="style9">
                        &nbsp;</td>
                    <td class="style11" style="font-weight: bold" align="left">
                        &nbsp;</td>
                    <td class="style16">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                        <tr>
                            <td class="style9">
                                &nbsp;</td>
                            <td class="style11" style="font-weight: bold" align="left">
                                USERNAME:</td>
                            <td class="style16">
                                <asp:Label ID="lblUserName" runat="server"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style9">
                                &nbsp;</td>
                            <td class="style11" style="font-weight: bold" align="left">
                                Switch Role:</td>
                            <td class="style16">
                                <asp:Label ID="lblPassword" runat="server"></asp:Label>
                            </td>
                            <td>
                                </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style9">
                                &nbsp;</td>
                            <td align="left" class="style11" style="font-weight: bold">
                                PASSWORD:</td>
                            <td class="style16">
                                <asp:DropDownList ID="ddlRole" runat="server" Width="175px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                    ControlToValidate="ddlRole" ErrorMessage="Please select Role" ForeColor="Red" 
                                    InitialValue="Select Role" ValidationGroup="b">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                <tr>
                    <td class="style9">
                        &nbsp;</td>
                    <td class="style11" style="font-weight: bold">
                        </td>
                    <td class="style16">
                        &nbsp;</td>
                    <td>
                        &nbsp;&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                        <tr>
                            <td class="style9">
                                &nbsp;</td>
                            <td class="style11" style="font-weight: bold">
                                &nbsp;<asp:LinkButton ID="lnkbtnBack" runat="server" OnClick="lnkbtnBack_Click">Back</asp:LinkButton>
                            </td>
                            <td class="style16">
                                <asp:Button ID="btnUpdate" runat="server" BackColor="#CCCCCC" 
                                    BorderColor="#CC0000" BorderWidth="1px" Font-Bold="False" Font-Names="Calibri" 
                                    Font-Underline="False" ForeColor="#CC0000" OnClick="btnUpdate_Click" 
                                    style="margin-left: 0px; margin-right: 0px;" Text="UPDATE" ValidationGroup="b" 
                                    Width="71px" />
                            </td>
                            <td>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
            </table>
            <table style="width: 100%;">
                        <tr>
                            <td align="center" style="font-size: small; font-family: CANDAra">
                                <asp:Label ID="lblError2" runat="server" ForeColor="Red"></asp:Label>
                                <asp:Label ID="lblStatus2" runat="server" ForeColor="Red"></asp:Label>
                                <telerik:RadNotification ID="RadNotification2" runat="server" 
                                    EnableRoundedCorners="True" Height="150px" Position="Center" 
                                    ShowTitleMenu="True" Skin="Sunset" Title="Progress Notification!" Width="306px">
                                    <ContentTemplate>
                                        <div align="center" style="width: 263px">
                                            <img alt="" src="../../images/Notification.png" 
                                                style="height: 42px; width: 46px" /><asp:Label ID="lblNotif2" runat="server" Font-Bold="True"></asp:Label>
                                        </div>
                                    </ContentTemplate>
                                    <NotificationMenu ID="NotificationMenu1">
                                    </NotificationMenu>
                                </telerik:RadNotification>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
    
        
    <br />

    <p>
        &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Error Alert!" ShowMessageBox="True" ShowSummary="False" ValidationGroup="a" />

        <p>
        &nbsp;<asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="Error Alert!" ShowMessageBox="True" ShowSummary="False" ValidationGroup="b" />
    </div>
    </center>
    </form>
</body>
</html>
