// Smartkon JavaScript Document
var xmlhttp;
var commpostid;
var career;
var ajax_response = '<img src="images/spin_32.gif" height="25px" width="25px" alt="Loading...">'; 

function ActivateBroacast(postid,uid)
{
document.getElementById("rebroadcast_form"+postid).style.display="block";
}



function checkCommentBoxInputKey(event,comm,postid) {
	 commpostid= postid;
	if(event.keyCode == 13 && event.shiftKey == 0)  {
		
		xmlhttp=GetXmlHttpObject();
if (xmlhttp==null)
  {
  alert ("Your browser does not support XMLHTTP!");
  return;
  }
  if(comm=="")
  {
	  return false;
  }
document.getElementById("commload"+commpostid).innerHTML=ajax_response;
var url="ajax_statuscomment.php";
url=url+"?comment="+comm+"&post_id="+postid;
url=url+"&sid="+Math.random();
xmlhttp.onreadystatechange=stateChange;
xmlhttp.open("GET",url,true);
xmlhttp.send(null);
		}
		

		return false;
	}


function postComment(comm,commid)
{
 alert (comm);
xmlhttp=GetXmlHttpObject();
if (xmlhttp==null)
  {
  alert ("Your browser does not support XMLHTTP!");
  return;
  }

var url="ajax_statuscomment.php";
url=url+"?comment="+comm+"&sid="+Math.random();
xmlhttp.onreadystatechange=stateChangenotify;
xmlhttp.open("GET",url,true);
xmlhttp.send(null);
}


function stateChange()
{
if (xmlhttp.readyState==4)
  {
	  document.getElementById("commload"+commpostid).innerHTML="";
 document.getElementById("comments"+commpostid).innerHTML=xmlhttp.responseText;
   }
   
  }
  
  
  function checkCommentCareerBoxInputKey(event,comm,postid) {
	 commpostid= postid;
	if(event.keyCode == 13 && event.shiftKey == 0)  {
		
		xmlhttp=GetXmlHttpObject();
if (xmlhttp==null)
  {
  alert ("Your browser does not support XMLHTTP!");
  return;
  }
  if(comm=="")
  {
	  return false;
  }
document.getElementById("commload"+commpostid).innerHTML=ajax_response;
var url="ajax_statuscomment_career.php";
url=url+"?comment="+comm+"&post_id="+postid;
url=url+"&sid="+Math.random();
xmlhttp.onreadystatechange=stateChangeCareer;
xmlhttp.open("GET",url,true);
xmlhttp.send(null);
		}
		

		return false;
	}

  
  function stateChangeCareer()
{
if (xmlhttp.readyState==4)
  {
	  document.getElementById("commload"+commpostid).innerHTML="";
 document.getElementById("comments"+commpostid).innerHTML=xmlhttp.responseText;
   }
   
  }
  
function ConfirmDeletePost(postid)
{
xmlhttp=GetXmlHttpObject();
if (xmlhttp==null)
  {
  alert ("Your browser does not support XMLHTTP!");
  return;
  }	
document.getElementById("confirmdel"+postid).innerHTML=ajax_response;
  var url="ajax_delete_status.php";
url=url+"?post_id="+postid;
url=url+"&sid="+Math.random();
xmlhttp.onreadystatechange=stateChangeDeletePost;
xmlhttp.open("GET",url,true);
xmlhttp.send(null);
}

function stateChangeDeletePost()
{
if (xmlhttp.readyState==4)
  {

 document.getElementById("stausmsg").innerHTML=xmlhttp.responseText;
   }
   
  }

function Rate(postid,rate)
{
commpostid= postid;
xmlhttp=GetXmlHttpObject();
if (xmlhttp==null)
  {
  alert ("Your browser does not support XMLHTTP!");
  return;
  }	
document.getElementById("rateload"+commpostid).innerHTML=ajax_response;
  var url="ajax_rate_status.php";
url=url+"?post_id="+postid+"&rate="+rate;
url=url+"&sid="+Math.random();
xmlhttp.onreadystatechange=stateChangeRatePost;
xmlhttp.open("GET",url,true);
xmlhttp.send(null);
}

function stateChangeRatePost()
{
if (xmlhttp.readyState==4)
  {

 document.getElementById("rateload"+commpostid).innerHTML="";
 document.getElementById("Rates"+commpostid).innerHTML=xmlhttp.responseText;
   }
   
  }

function Broacast_My_Wall(postid,uid,post)
{
commpostid= postid;
xmlhttp=GetXmlHttpObject();
if (xmlhttp==null)
  {
  alert ("Your browser does not support XMLHTTP!");
  return;
  }	
document.getElementById("share_status_loader"+postid).innerHTML=ajax_response;
  var url="ajax_rebroadcast_status.php";
url=url+"?post_id="+postid+"&uid="+uid+"&post="+post;
url=url+"&sid="+Math.random();
xmlhttp.onreadystatechange=stateChangeBroacastPost;
xmlhttp.open("GET",url,true);
xmlhttp.send(null);
}

function stateChangeBroacastPost()
{
if (xmlhttp.readyState==4)
  {
document.getElementById("rebroadcast_form"+commpostid).style.display="none";
 document.getElementById("share_status_loader"+commpostid).innerHTML=xmlhttp.responseText;
  
   }
   
  }


function AcceptPalRequest(requestid)
{
xmlhttp=GetXmlHttpObject();
if (xmlhttp==null)
  {
  alert ("Your browser does not support XMLHTTP!");
  return;
  }	
document.getElementById("pal_req12"+requestid).innerHTML=ajax_response;
  var url="ajax_accept_pal_request.php";
url=url+"?req_id="+requestid;
url=url+"&sid="+Math.random();
xmlhttp.onreadystatechange=stateChangeAcceptPal;
xmlhttp.open("GET",url,true);
xmlhttp.send(null);
 }


function stateChangeAcceptPal()
{
if (xmlhttp.readyState==4)
  {
 document.getElementById("pal_req_rec").innerHTML=xmlhttp.responseText;
 
   }
   return false;
  }
  
 function DeclinePalRequest(requestid)
{
xmlhttp=GetXmlHttpObject();
if (xmlhttp==null)
  {
  alert ("Your browser does not support XMLHTTP!");
  return;
  }	
document.getElementById("pal_req22"+requestid).innerHTML=ajax_response;
  var url="ajax_decline_pal_request.php";
url=url+"?req_id="+requestid;
url=url+"&sid="+Math.random();
xmlhttp.onreadystatechange=stateChangeDeclinePal;
xmlhttp.open("GET",url,true);
xmlhttp.send(null);
 } 
function stateChangeDeclinePal()
{
if (xmlhttp.readyState==4)
  {
 document.getElementById("pal_req_rec").innerHTML=xmlhttp.responseText;
 
   }
   return false;
  }
  
  
  function Get_Profile_Info_Career(pid)
{
commpostid= pid;
xmlhttp=GetXmlHttpObject();
if (xmlhttp==null)
  {
  alert ("Your browser does not support XMLHTTP!");
  return;
  }	
document.getElementById("photo"+commpostid).innerHTML=ajax_response;
  var url="ajax_get_career_peeps_info.php";
url=url+"?puid="+commpostid;
url=url+"&sid="+Math.random();
xmlhttp.onreadystatechange=stateChangeGet_Profile_Info_Career;
xmlhttp.open("GET",url,true);
xmlhttp.send(null);
 } 
function stateChangeGet_Profile_Info_Career()
{
if (xmlhttp.readyState==4)
  {
 document.getElementById("photo"+commpostid).innerHTML=xmlhttp.responseText;
  }
 
   return false;
 }
  
function postStatus(post)
{
xmlhttp=GetXmlHttpObject();
if (xmlhttp==null)
  {
  alert ("Your browser does not support XMLHTTP!");
  return;
  }
if(post=='')
{
alert("Post cannot be empty");
return false;
}

}
function getNotifications()
{	
document.getElementById("notifications").innerHTML=ajax_response;
xmlhttp=GetXmlHttpObject();
if (xmlhttp==null)
  {
  alert ("Your browser does not support XMLHTTP!");
  return;
  }

var url="ajax_get_notifications.php";
url=url+"?sid="+Math.random();
xmlhttp.onreadystatechange=stateChangenotify;
xmlhttp.open("GET",url,true);
xmlhttp.send(null);
}

function stateChangenotify()
{
if (xmlhttp.readyState==4)
  {
document.getElementById("notifications").innerHTML=xmlhttp.responseText;

   }
   
  }
  
function getPalRequests()
{	
document.getElementById("pal_request").innerHTML=ajax_response;
xmlhttp=GetXmlHttpObject();
if (xmlhttp==null)
  {
  alert ("Your browser does not support XMLHTTP!");
  return;
  }

var url="pal_request_received.php";
url=url+"?sid="+Math.random();
xmlhttp.onreadystatechange=stateChangepal;
xmlhttp.open("GET",url,true);
xmlhttp.send(null);
}

function stateChangepal()
{
if (xmlhttp.readyState==4)
  {
document.getElementById("pal_request").innerHTML=xmlhttp.responseText;

   }
   
  }
  
  
  
  function getNewMessages()
{	
document.getElementById("new_messages").innerHTML=ajax_response;
xmlhttp=GetXmlHttpObject();
if (xmlhttp==null)
  {
  alert ("Your browser does not support XMLHTTP!");
  return;
  }

var url="ajax_get_messages.php";
url=url+"?sid="+Math.random();
xmlhttp.onreadystatechange=stateChangeMessages;
xmlhttp.open("GET",url,true);
xmlhttp.send(null);
}

function stateChangeMessages()
{
if (xmlhttp.readyState==4)
  {
document.getElementById("new_messages").innerHTML=xmlhttp.responseText;

   }
   
  }
  
  
function get_User_Comm_Messages(pal_id,pal_name)
{	
document.getElementById("msg_contact_div").innerHTML= "Messages ---" + pal_name;
document.getElementById("messages_peeps_div").innerHTML=ajax_response;
xmlhttp=GetXmlHttpObject();
if (xmlhttp==null)
  {
  alert ("Your browser does not support XMLHTTP!");
  return;
  }

var url="ajax_get_user_communications.php";
url=url+"?pal_id="+pal_id;
url=url+"&sid="+Math.random();
xmlhttp.onreadystatechange=stateChangeUserMessages;
xmlhttp.open("GET",url,true);
xmlhttp.send(null);
}

function stateChangeUserMessages()
{
if (xmlhttp.readyState==4)
  {
document.getElementById("messages_peeps_div").innerHTML=xmlhttp.responseText;

   }
   
  }  

function stateChanged()
{
if (xmlhttp.readyState==4)
  {
 document.getElementById("stausmsg").innerHTML=xmlhttp.responseText;

   }
   
  }


function GetXmlHttpObject()
{
if (window.XMLHttpRequest)
  {  
  // code for IE7+, Firefox, Chrome, Opera, Safari
  return new XMLHttpRequest();
  }
if (window.ActiveXObject)
  {
  // code for IE6, IE5
  return new ActiveXObject("Microsoft.XMLHTTP");
  }
return null;
}

