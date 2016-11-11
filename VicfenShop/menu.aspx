<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Menu</title>
    <!-- STYLE AND SCRIPT -->
    <link href="./css/styles.css" rel="stylesheet" type="text/css"/>
    <!--[if gte IE 5.5]>
    <script language="JavaScript" src="./javascript/ie.js" type="text/JavaScript"></script>
    <![endif]-->
<style type="text/css">
body {
	font-family:verdana,arial,sans-serif;
	font-size:10pt;
	margin:10px;
	background-image: url(patterns/furley_bg.png);
	color:#61605f;
	overflow-y:hidden;
	}
a {color:#fbfbfb; text-decoration: none; }

img{border:0}
.flo_r {float: right; }
	

</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;
        <asp:Panel ID="Panel1" runat="server" Width="188px">
        <asp:TreeView ID="tvMenu" runat="server" ImageSet="Simple" BorderStyle="None" Font-Names="Book Antiqua" Font-Size="12pt" ForeColor="Blue">
            <ParentNodeStyle Font-Bold="False" Font-Size="16pt" />
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" ForeColor="#5555DD" />
            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="0px"
                NodeSpacing="0px" VerticalPadding="0px" />
        </asp:TreeView>

            &nbsp; &nbsp;
        </asp:Panel>
        &nbsp;
        <br />
       
    </div>
    <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red" Font-Italic="True" Font-Size="Large"></asp:Label>
    
      <div class="sidebar-nav">
        <a href="#dashboard-menu" class="nav-header" data-toggle="collapse"><i class="icon-dashboard"></i>Dashboard</a>
        <ul id="dashboard-menu" class="nav nav-list collapse in">
            <li><a href="index.html">Home</a></li>
         
            
        </ul>
        </div>
    </form>
</body>
</html>
