<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu2.aspx.cs" Inherits="menu2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Styles/SiteNew.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="sidebar" style="padding-left:0; padding-right:0;">
          <div ID="MenuPanel" runat="server">
          
          </div>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            //alert("Show");
            $('#nav > li > a').click(function () {
                if ($(this).attr('class') != 'active') {
                    $('#nav li ul').slideUp();
                    $(this).next().slideToggle();
                    $('#nav li a').removeClass('active');
                    $(this).addClass('active');
                }
            });

            $('#nav > li> a').append('<span class="caret"></span>');
        });
    
    
    </script>

    <style>
    #nav {
    float: left;
    width: 170px;
}
#nav li a {
    display: block;
    padding: 10px 15px;
    background:#F5F5F5;
    text-decoration: none;
    color: #000;
}
#nav li a:hover, #nav li a.active {
    background: #5BA47F;
    color: #fff;
}
#nav li ul {
    display: none; // used to hide sub-menus
}
#nav li ul li a {
    padding: 10px 25px;
    background: #ececec;
    border-bottom: 1px dotted #ccc;
}

ul
{
    padding:0;
    margin:0;    
    
}

li
{
    list-style-type:none;
    }
    
     .caret
     {
         float: right !important;
        margin-top: 10px;
}
    </style>
</body>
</html>
