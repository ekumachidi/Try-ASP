<%@ Page Language="C#" Title="Manage Account" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Administrator_Utilities_ChangePassword" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
    <div>
        <div style=" width: 544px; font-family: candara; font-size: small;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="border-width: thick; border-color: #000000; font-family: Candara; font-size: large; font-weight: bold; text-align: center; border-bottom-style: solid;">
                                    CHANGE PASSWORD</td>
                            </tr>
                        </table>

                    </div>
        
        
        <br />
            <asp:ChangePassword ID="ChangePassword1" runat="server" BackColor="#FFFBD6" 
                BorderColor="#FFDFAD" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" 
                CancelDestinationPageUrl="~/welcomeHome/MainIframeLoading.aspx" 
                ContinueDestinationPageUrl="~/welcomeHome/MainIframeLoading.aspx" 
                Font-Names="Verdana" Font-Size="0.8em" Height="138px" Width="374px">
                <CancelButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" 
                    BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
                <ChangePasswordButtonStyle BackColor="White" BorderColor="#CC9966" 
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" 
                    ForeColor="#990000" />
                <ContinueButtonStyle BackColor="White" BorderColor="#CC9966" 
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" 
                    ForeColor="#990000" />
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <PasswordHintStyle Font-Italic="True" ForeColor="#888888" />
                <TextBoxStyle Font-Size="0.8em" />
                <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" 
                    ForeColor="White" />
            </asp:ChangePassword>
        
        
    
    </div>
    </center>
    </form>
</body>
</html>
