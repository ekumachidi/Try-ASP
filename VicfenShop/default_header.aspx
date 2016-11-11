<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default_header.aspx.cs" Inherits="default_header" %>
<html>
<head>
<title>School Manager</title>
<style type="text/css">
html { padding:0; margin:0;}
body {margin:0; padding:0; background:#fff url(images/bk.jpg) repeat-x; width:1300px; font-family:Arial, Verdana;  overflow-y:hidden;}
.logo {background:url(images/logo.png) no-repeat; width:350px; height:94px; margin-top:11px;}
.w{width:100%}
table{ background:none;}
table font{font-family: Arial, Verdana; color:#505050; text-decoration:none; font-size: 16px; font-weight:bold; }
table a {font-family: Arial, Verdana; color:#b30c0c; text-decoration:none; font-size: 13px; }

img{border:0}
.flo_r {float: right; }
.cc{border: 1px solid #868686;}
</style>
</head>
<body>
		<div class="logo w">
					<table width="450" border="0" class="flo_r">
						  <tr>
							<td width="68">
                                <asp:Image ID="Image1" runat="server"  Height="80px" Width="100px" />
                             </td>
							<td width="320">
							<font>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></font><br>
							<a href="welcome.aspx?" target="mainFrame"><img src="images/home.png">Home</a> <span class="cc1">|</span> 
							<a href="welcome.aspx?" target="mainFrame"><img src="images/notify.png">Notification</a> <span class="cc1">|</span>  
							<a href="logout.aspx" target="_parent"><img src="images/lock.png">Logout</a>							</td>
						    <td width="98"><span class="logo w"><a href="#"><img src="images/help.png" class="flo_r"></a></span></td>
						  </tr>
                          
					</table>
		</div>
</body>
</html>
