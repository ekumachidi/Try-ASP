<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu1.aspx.cs" Inherits="menu1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="vertical-align: top; text-align: left">
    
        <telerik:RadPanelBar ID="RadPanelBar1" runat="server" Width="190px" 
            Skin="Default" ExpandMode="SingleExpandedItem" >
            

            <ExpandAnimation Type="Linear" Duration="100"></ExpandAnimation>
            <CollapseAnimation Type="Linear" Duration="100"></CollapseAnimation>
        </telerik:RadPanelBar>
    </div>
    </form>
</body>
</html>
