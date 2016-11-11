<%@ Page Title="Login" Language="C#" MasterPageFile="~/Mytemplate.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {

            $("input[id$=Button1]").click(function () {
                var txtUser = $('input[id$=UserName]').val();
                var txtPass = $('input[id$=Password]').val();
                var ajax_response = 'Please Wait...';
                $('#StatusMessage').html(ajax_response);


            });
            $('#StatusMessage').html("Welcome!");

        });
      
  


      //    Solution 3:

     
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="row-fluid">
    <div class="dialog">
        <div class="block">
            <p class="block-heading">Sign In</p>
            <div class="block-body">
                <form  id="Form1"   runat="server">
                    <label>Username</label>
                    <asp:TextBox ID="UserName" runat="server" Cssclass="span12"></asp:TextBox>
                  
                    <label>Password</label>
                <asp:TextBox ID="Password" runat="server" CssClass="span12" TextMode="Password"></asp:TextBox>
                    
                    <label class="remember-me">Remember Me</label><asp:CheckBox ID="RememberMe" runat="server" CssClass="span12"/>
                    
<asp:button ID="Button1" text="Login"  runat="server"  Cssclass="btn btn-primary pull-right" 
                        onclick="Button1_Click"    />
<asp:label id="lblMsg" runat="server"/>
<div id="StatusMessage"></div>

                    <div class="clearfix"></div>
                </form>
            </div>
        </div>
        <p><a href="reset-password.html">Forgot your password?</a></p>
    </div>
</div>
</asp:Content>

