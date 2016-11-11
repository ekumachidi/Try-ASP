<%@ Page Language="c#" %>
<script runat="server">
protected void Page_Load( object sender,  System.EventArgs e)  
{
    string version = System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion();
    if (version[1] != '4')
    {
        lblMessage.Text = "Your project was built for .NET Framework 2.0 while website is running under .NET Framework  " + version +
                          "<br>You need to delete all files from the output directory, swtich to .NET Framework " + version + " and rebuild your project. Framework version can be selected at step 12 (output directory) of ASPRunner.NET wizard.";
                              
    }
    else
    {
        Response.Redirect("menu.aspx");
    }
}    
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Default.aspx</title>
</head>
<body>
    <form id="frmDefault" runat="server">
    <div>
<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
    </div>
    </form>
</body>
</html>
