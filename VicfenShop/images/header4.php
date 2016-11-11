<?php $user_logged = get_id_email($_SESSION['wokon_login']);?>
<?php $sendern = get_two_names_username($_SESSION['username']);
$senderpic = get_userchat_photo($_SESSION['username']);
?>
<script src="jquery/jquery.watermarkinput.js"></script>
<script type="text/javascript">
function checkChatBoxInputKey(event,chatboxtextarea,chatboxtitle) {
	 
	if(event.keyCode == 13 && event.shiftKey == 0)  {
		message = $(chatboxtextarea).val();
		message = message.replace(/^\s+|\s+$/g,"");

		$(chatboxtextarea).val('');
		$(chatboxtextarea).focus();
		$(chatboxtextarea).css('height','25px');
		if (message != '') {
			$.post("chat.php?action=sendchat", {to: chatboxtitle, message: message} , function(data){
				message = message.replace(/</g,"&lt;").replace(/>/g,"&gt;").replace(/\"/g,"&quot;");
				$("#chatbox_"+chatboxtitle+" .chatboxcontent").append('<div ><table width="100%"  border="0" cellpadding="0" cellspacing="0"><tr><td width="26" rowspan="2" valign="top"><div align="center"><?php echo $senderpic;?></div></td><td width="165" height="22" valign="top" style="background-image:url(images/chat_im_top2.png);">&nbsp;</td></tr><tr><td width="150" valign="top" style="background-image:url(images/chat_im_mid2.png); margin-top:0px; padding-left:20px;"><div align="left" style="width:150px; word-wrap:break-word;">'+message+'</div></td></tr>  <tr><td>&nbsp;</td><td valign="top" style="background-image:url(images/chat_im_buttom2.png);">&nbsp;</td></tr></table></div>');
				$("#chatbox_"+chatboxtitle+" .chatboxcontent").scrollTop($("#chatbox_"+chatboxtitle+" .chatboxcontent")[0].scrollHeight);
			});
		}
		chatHeartbeatTime = minChatHeartbeat;
		chatHeartbeatCount = 1;

		return false;
	}

	var adjustedHeight = chatboxtextarea.clientHeight;
	var maxHeight = 94;

	if (maxHeight > adjustedHeight) {
		adjustedHeight = Math.max(chatboxtextarea.scrollHeight, adjustedHeight);
		if (maxHeight)
			adjustedHeight = Math.min(maxHeight, adjustedHeight);
		if (adjustedHeight > chatboxtextarea.clientHeight)
			$(chatboxtextarea).css('height',adjustedHeight+8 +'px');
	} else {
		$(chatboxtextarea).css('overflow','auto');
	}
	 
}
function NotifyMsgInitialization(chatboxtitle) 
{
$.post("chat.php?action=notifyuser", {to: chatboxtitle} , function(data){
});
}
</script>
<script type="text/javascript">
	$(document).ready(function(){
		function load_status_funtion() 
		{ 
		   
           var ID=$(".mystatus_box:last").attr("id");
			$('div#last_msg_loader').html('<img src="images/spin_32.gif" height="25px" width="25px" alt="Loading...">');
			$.post("home.php?action=get&last_msg_id="+ID,
			
			function(data){
				if (data != "") {
				$(".mystatus_box:last").after(data);			
				}
				$('div#last_msg_loader').empty();
			});
		};  
		
		$(window).scroll(function(){
			if  ($(window).scrollTop() == $(document).height() - $(window).height()){
			   load_status_funtion();
			}
		}); 
		
	});
	</script>
<script type="text/javascript">
jQuery(function($){
$("#search").Watermark("Enter Your Search!");

});
var auto_refresh2 = setInterval(
function ()
{
$('#smartkon_noftify_msg').load('load_notify_msg.php').fadeIn("slow");
$('#smartkon_noftify_flag').load('load_notify_flag.php').fadeIn("slow");
$('#notify_pal').load('load_notify_pal.php').fadeIn("slow");
}, 1000); // refresh post every 1 sec
var auto_refresh2 = setInterval(
function ()
{
$('#sug_div').load('get_suggested_pals.php').fadeIn("slow");

}, 20000); // refresh suggested pals every 5 Sec

var auto_refresh = setInterval(
function ()
{
$('#chat_div').load('get_online_contacts.php').fadeIn("slow");

}, 1000); // refresh post every 5 minutes
</script>
<style type="text/css">
 .accept_pal_req {
  color: #ffffff;
  text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
  background-color: #49afcd;
  *background-color: #2f96b4;
  background-image: -moz-linear-gradient(top, #5bc0de, #2f96b4);
  background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#5bc0de), to(#2f96b4));
  background-image: -webkit-linear-gradient(top, #5bc0de, #2f96b4);
  background-image: -o-linear-gradient(top, #5bc0de, #2f96b4);
  background-image: linear-gradient(to bottom, #5bc0de, #2f96b4);
  background-repeat: repeat-x;
  border-color: #2f96b4 #2f96b4 #1f6377;
  border-color: rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.25);
  filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ff5bc0de', endColorstr='#ff2f96b4', GradientType=0);
  filter: progid:DXImageTransform.Microsoft.gradient(enabled=false);
}
.accept_pal_req:hover,
 {
  color: #ffffff;
  background-color: #2f96b4;
  *background-color: #2a85a0;
}
 .delay_pal_req {
  color: #ffffff;
  text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
  background-color: #49afcd;
  *background-color: #2f96b4;
  background-image: -moz-linear-gradient(top, #5bc0de, #2f96b4);
  background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#5bc0de), to(#2f96b4));
  background-image: -webkit-linear-gradient(top, #5bc0de, #2f96b4);
  background-image: -o-linear-gradient(top, #5bc0de, #2f96b4);
  background-image: linear-gradient(to bottom, #5bc0de, #2f96b4);
  background-repeat: repeat-x;
  border-color: #2f96b4 #2f96b4 #1f6377;
  border-color: rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.25);
  filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ff5bc0de', endColorstr='#ff2f96b4', GradientType=0);
  filter: progid:DXImageTransform.Microsoft.gradient(enabled=false);
}
.delay_pal_req:hover,
 {
  color: #ffffff;
  background-color: #2f96b4;
  *background-color: #2a85a0;
}</style>

<div id="smartkon_head">
<div class="navbar navbar-fixed-top">
	      <div class="navbar-inner">
	        <div class="container">
	         <div class="nav-collapse">
	            <ul class="nav">
	              <li><a href="" ><img src="images/smartcon_textpic_big.png" width="130" height="30"></a></li>
	              <li class="dropdown"><a href="#" onclick="getNewMessages()" class="dropdown-toggle" data-placement="right" data-toggle="dropdown"><span class="style7" id="smartkon_noftify_msg" style=" color:#FF0000;"><?php db_connect(); 
$sql_msg = mysql_query("select count(*) from  chat where profile_id= '$user_logged' and status = '0'") or die( mysql_error());
$count_msg = mysql_result($sql_msg,0,0); 
if($count_msg==0)
{?><img src="images/new_post_nil.png" width="20" height="20"><?php } else {?><strong><?php echo $count_msg;?></strong><img src="images/new_post.png" width="20" height="20"><?php }?></span></a>
<ul class="dropdown-menu">
<li><div id="new_messages"></div></li>


</ul>

</li>
				  	              <li class="dropdown"><a href="#"  onclick="getNotifications()" class="dropdown-toggle" data-placement="right" data-toggle="dropdown"><span class="style7" id="smartkon_noftify_flag" style=" color:#FF0000;"><?php db_connect(); 
$sql_notify = mysql_query("select count(*) from  notifications where rec_id= '$user_logged' and status = '0' and setting = '1'") or die( mysql_error());
$count_notify = mysql_result($sql_notify,0,0); 
if($count_notify==0)
{?><img src="images/flag_yellow_nil.png" width="20" height="20"><?php } else {?><strong><?php echo $count_notify;?></strong><img src="images/flag_yellow.png" width="20" height="20"><?php }?></span></a>
 <ul class="dropdown-menu">
<li><div id="notifications"></div></li>


</ul>

</li>
				  <li class="dropdown"><a href="" class="dropdown-toggle" data-placement="right" data-toggle="dropdown" onclick="getPalRequests()" ><span class="style7" id="notify_pal" style=" color:#FF0000;"><?php db_connect(); 
$sql_pal = mysql_query("select count(*) from  pal_request where receiver_id= '$user_logged' and status = '0' and setting = '1'") or die( mysql_error());
$count_pal = mysql_result($sql_pal,0,0); 
if($count_pal==0)
{?><img src="images/contact_nil.png" width="20" height="20"><?php } else {?><strong><?php echo $count_pal;?></strong><img src="images/contact_new.png" width="20" height="20"><?php }?></span></a>  <ul class="dropdown-menu">
<li><div id="pal_request"></div></li>


</ul>
				  </li>
				  
				 
<li  >  <form class="navbar-search pull-left" action="" >
                    <input type="text"  style="margin: 0 auto; width:400px" name="search" id="search" class="search">

                    </form>
					<div  style="border:1px solid #CCC; margin-top:35px; width:411px; background:#FFFFFF; position:absolute; display:none" id="suggest" >         
                      
                    </div>
</li>             
<li class="dropdown">
<a href="#" class="dropdown-toggle" data-toggle="dropdown" ><img src="images/finder2.png" width="22" height="22"><strong> Finder</strong> </a>
<ul class="dropdown-menu">
<li><a href="#">Find Pals</a></li>
<li><a href="career_connect.php">Career Connect</a></li>
<li><a href="#">Browse Likes</a></li>

</ul>
</li>
<li class="dropdown">
<a href="#" class="dropdown-toggle" data-toggle="dropdown"><img src="images/cabinet.png" width="22" height="22"><strong> My Cabinet </strong></a>
<ul class="dropdown-menu">
<li><a href="#">Profile Info.</a></li>
<li><a href="#">Photos</a></li>
<li><a href="#">Palspage</a></li>
<li><a href="#">Groups</a></li>
<li><a href="#">E-Books</a></li>
<li><a href="#">Notes</a></li>
<li><a href="#">Other Documents</a></li>
</ul>
</li>
<li class="dropdown">
<a href="#" class="dropdown-toggle" data-toggle="dropdown"><img src="images/connect_arrow_left.png" width="22" height="22"><strong> Connect</strong></a>
<ul class="dropdown-menu">
<li><a href="#">Social Media</a></li>
<li><a href="#">SMS</a></li>
<li><a href="#">Chat Invitation</a></li>
<li><a href="#">Send Email</a></li>
</ul>
</li>
<li class="dropdown">
<a href="#" class="dropdown-toggle" data-toggle="dropdown"><img src="images/chat_new.png" width="22" height="22"><strong> Chat Box </strong></a>
<ul class="dropdown-menu">
<li><a href="#">Chat</a></li>
<li><a href="#">Cross Chat</a></li>

</ul>
</li>

 <li><a href="home.php" id="" rel="popover" data-content="" data-original-title=""><span class="style7"><img src="images/home.png" width="23" height="23" border="0"></span></a></li>

 <li><a href="membersprofile.php?profileid=<?php $userid=get_id_email($_SESSION["wokon_login"]); echo $userid;?>&amp;name=<?php getfname($_SESSION["wokon_login"]);?>" title="<?php      getfname($_SESSION["wokon_login"]);      ?>"><strong> <?php      display_profile_pic_small($_SESSION["wokon_login"]);       ?><?php      getfname($_SESSION["wokon_login"]);      ?></strong></a></li>
<li class="dropdown ">
<a href="#" class="dropdown-toggle" data-placement="right" data-toggle="dropdown"><img src="images/settings1.png" width="22" height="22"> </a>
<ul class="dropdown-menu pull-right ">
<li class="nav-header">Settings</li>
<li><a href="#">Account Settings</a></li>
<li><a href="#">Privacy Settings</a></li>
<li class="divider"></li>
<li class="nav-header">More</li>
<li><a href="#">My Profile</a></li>
<li><a href="logout.php">Logout</a></li>
</ul>
</li>

	            </ul>
                    
                  
	           
	          </div><!--/.nav-collapse -->
	        </div>
	      </div>
	    </div></div>
		