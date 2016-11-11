<%@ Page Language="C#" AutoEventWireup="true" CodeFile="welcome_home.aspx.cs" Inherits="welcome_home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <link rel="shortcut icon" href="images/favicon.ico">
 <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content=""/>
    <meta name="author" content=""/>

  
    <%--  <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.0/jquery.min.js" type="text/javascript"></script>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.8.0/jquery.min.js" type="text/javascript"></script>--%>
<title>Welcome <% Response.Write(User.Identity.Name); %></title>
<%--<script type="text/javascript"> 
var lefttime=5; 
var interval; 
interval = setInterval('change()',10); 
 
 
function change() 
{ 
   lefttime--; 
   if(lefttime<=2) alert("the session will be off, left time is "+lefttime+" second!") 
} 
</script>--%>
</head>

<frameset style="background-color:#FFFFFF" rows="*,10%" id="parent" frameborder="no" border="1" framespacing="0">
    <frameset rows="1" frameborder="no" border="1" framespacing="0">
    
      
      <frameset cols="*" frameborder="1" border="1" framespacing="0">
       
        <frame src="welcome.aspx" name="mainFrame" id="mainFrame" title="Content" />
      </frameset>
    </frameset>
  <frame src="default_footer.aspx" name="bottomFrame" scrolling="No" noresize="noresize" id="bottomFrame" title="Footer" />
</frameset>
	
<noframes>
	<body rightmargin="1" style="border-left-width: 1px; border-right-style: solid; border-right-width: 1px; border-top-width: 1px; border-bottom-width: 1px">

	<p>This page uses frames, but your browser doesn't support them.</p>

	</body>
</noframes>

</html>
