<%@ Page Language="C#" AutoEventWireup="true" CodeFile="welcome_home.aspx.cs" Inherits="welcome_home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<frameset rows="77,*" frameborder="0" border="0" framespacing="0">
  <frame name="topNav" src="default_header.aspx" scrolling="No">
  <frameset cols="210,*" frameborder="0" border="0" framespacing="0">
	 <frame name="menu" id="menu2" src="menu2.aspx" marginheight="0" marginwidth="0" scrolling="auto" noresize>
     <frameset rows="*,30" framespacing="0">
        <frame name="mainFrame"  id="mainFrame" src="Welcome.aspx" marginheight="0" marginwidth="20" scrolling="auto" noresize>
        <frame name="footer" src="default_footer.htm" scrolling="No">
     </frameset>
  </frameset>

<noframes>
<p>This section does not support frames..</p>
</noframes>

</frameset>
</html>
