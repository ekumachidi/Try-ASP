<%@ Page Language="C#" AutoEventWireup="true" CodeFile="welcome.aspx.cs" Inherits="welcome" %>
<%@ Register assembly="Infragistics4.WebUI.WebResizingExtender.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI" tagprefix="igui" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>Welcome <% Response.Write(User.Identity.Name); %></title>
  <meta content="IE=edge,chrome=1" http-equiv="X-UA-Compatible"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta name="description" content="">
    <meta name="author" content="">
    
    <link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.css">
    
    <link rel="stylesheet" type="text/css" href="stylesheets/theme.css">
    <link rel="stylesheet" href="lib/font-awesome/css/font-awesome.css">
    `
    <script src="lib/jquery-1.7.2.min.js" type="text/javascript"></script>

   <style type="text/css">
        #line-chart {
            height:300px;
            width:800px;
            margin: 0px auto;
            margin-top: 1em;
        }
        .brand { font-family: georgia, serif; }
        .brand .first {
            color: #ccc;
            font-style: italic;
        }
        .brand .second {
            color: #fff;
            font-weight: bold;
        }
    </style>
</head>
<body >
<div class="navbar" style=" margin-top:20px;" >
        <div class="navbar-inner">
          <img src="images/logo.png"  alt="Logo"/>
                <ul class="nav pull-right">
                    
                   
                    <li><a href="welcome.aspx?" class="hidden-phone visible-tablet visible-desktop" role="button">Notification</a></li>
                    <li><a href="#" class="hidden-phone visible-tablet visible-desktop" role="button">Settings</a></li>
                    <li><a href="logout.aspx?" class="hidden-phone visible-tablet visible-desktop" role="button">Logout</a></li>
                    <li id="fat-menu" class="dropdown">
                        <a href="#" role="button" class="dropdown-toggle" data-toggle="dropdown">
                            <i ><asp:Image ID="Image1" runat="server"  Height="60px" Width="60px" /></i>   <asp:Label ID="Label1" runat="server" Text=""><% Response.Write(User.Identity.Name); %></asp:Label></font>
                            <i class="icon-caret-down"></i>
                        </a>

                        <ul class="dropdown-menu">
                            <li><a tabindex="-1" href="#">My Account</a></li>
                            <li class="divider"></li>
                            <li><a tabindex="-1" class="visible-phone" href="#">Settings</a></li>
                            <li class="divider visible-phone"></li>
                            <li><a tabindex="-1" href="sign-in.html">Logout</a></li>
                        </ul>
                    </li>
                    
                   
                    <li><a href="welcome.aspx?" class="hidden-phone visible-tablet visible-desktop" role="button">Home</a></li>
                    
                </ul>
              
        </div>
    </div>
  <div class="sidebar-nav">
        <a href="#dashboard-menu" class="nav-header" data-toggle="collapse">User Menu</a>
        <ul id="dashboard-menu" class="nav nav-list collapse in">
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
    
     
    </form>
            
        </ul>
        </div>

<div class="content" >
       
        <div class="header">
            <div class="stats">
    <p class="stat"><span class="number">53</span>tickets</p>
    <p class="stat"><span class="number">27</span>tasks</p>
    <p class="stat"><span class="number">15</span>waiting</p>
</div>

            <h1 class="page-title">Dashboard</h1>
        </div>
        <iframe name="main" id="main" src="Home.aspx" style="width:100%; height:800px;border:0"></iframe>
                

        
    </div>
 

      <script src="lib/bootstrap/js/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $('.demo-cancel-click').click(function () { return false; });
        });
    </script>
   </body>
   </html>


