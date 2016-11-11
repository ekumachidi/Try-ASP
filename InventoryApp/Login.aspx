<%@ Page Title="University of Nigeria Distance Learning Portal:: Login" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <style>
      .mainContainer
{
    background: url(images/Carousel5.jpg) no-repeat !important ;
	
	height:630px;
	top: 120px;
	z-index:-5;
}</style>
    <div class="container" >
    <div class="mainContainer">
        <div class="loginContainer">
      
            <form class="form-horizontal" action="#" id="loginForm" role="form" runat="server" >
                <div class="form-group">
                    <label class="col-lg-12 control-label" for="username">Username:</label>
                    <div class="col-lg-12">
                        <asp:TextBox ID="txtUsername" runat="server" class="form-control"  placeholder="Enter your username ..."></asp:TextBox>
                        
                       
                    </div>
                </div><!-- End .form-group  -->
                <div class="form-group">
                    <label class="col-lg-12 control-label" for="password">Password:</label>
                    <div class="col-lg-12">
                     <asp:TextBox ID="txtPassword" runat="server" placeholder="Enter your password..." 
                            class="form-control" TextMode="Password"></asp:TextBox>
                       
                        <span class="forgot help-block"><a href="#">Forgot your password?</a><br /><a href="StudentVerification.aspx">Verify Account</a></span>
                    </div>
                </div><!-- End .form-group  -->
                <div class="form-group">
                    <div class="col-lg-12 clearfix form-actions" style=" height:65px">
                        
                        <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-info" onclick="btnLogin_Click" style="width: 100px; height:35px"/>
                        
                    </div>
                </div><!-- End .form-group  -->
            </form>
        </div>
        </div>
    </div>
</asp:Content>

