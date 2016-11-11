// Smartkon Jquery Script
$(document).ready(function() 
{
// Update Status
$(".update_button").click(function() 
{
var updateval = $("#update").val();
var updateid = $("#uid").val();
var page = $("#page").val();
var email = $("#email").val();
var dataString = 'update='+ updateval+'&uid='+ updateid+'&page='+page+'&email='+ email;
if(updateval=='')
{
alert("Please Enter Some Text");
}
else
{
$("#flash").show();
$("#flash").fadeIn(400).html('Wait...');
$.ajax({
type: "POST",
url: "ajax_statusmessage.php",
data: dataString,
cache: false,
success: function(html)
{
$("#flash").fadeOut('slow');
 document.getElementById("stausmsg").innerHTML=html;
$("#update").val('');	
$("#update").focus();
$("#stexpand").oembed(updateval);
  }
 });
}
return false;
	});
	
//commment Submit

$('.comme').click(function() 
{

var ID = $(this).attr("id");

var comment= $("#ctextarea"+ID).val();
var dataString = 'comment='+ comment + '&post_id=' + ID;

if(comment=='')
{
alert("Please Enter Comment Text");
}
else
{
$.ajax({
type: "POST",
url: "ajax_statuscomment.php",
data: dataString,
cache: false,
success: function(html){
$("#comments"+ID).html(html);
$("#comments"+ID).val('');	
$("#comments"+ID).focus();
 }
 });
}
return false;
});

// Submit Pal Request

$('.sendpalreq').click(function() 
{
var senderid= $("#sender_id").val();
var recsid= $("#pal_id").val();
var dataString = 'sender_id='+ senderid + '&rec_id=' + recsid;

if(senderid=='')
{
alert("ERROR: Invalid Request");
}
else
{
$.ajax({
type: "POST",
url: "ajax_pal_request.php",
data: dataString,
cache: false,
success: function(html){
$("#pal_send_req").html(html);
 }
 });
}
return false;
});



// Accept Pal Request

$('.accept_pal_re').click(function() 
{
var ID = $(this).attr("id");
var dataString = 'req_id='+ID;

if(ID=='')
{
alert("ERROR: Invalid Request");
}
else
{
$("#flash_req"+ID).show();
$("#flash_req"+ID).fadeIn(500).html('Please Wait...');	
$.ajax({
type: "POST",
url: "ajax_accept_pal_request.php",
data: dataString,
cache: false,
success: function(html){
$("#flash_req"+ID).fadeOut('slow');
$("#pal_req_rec").html(html);
 }
 });
}
return false;
});



//Post Page commment Submit

$('.comment_button_post').click(function() 
{

var ID = $(this).attr("id");

var comment= $("#ctextarea"+ID).val();
var dataString = 'comment='+ comment + '&post_id=' + ID;

if(comment=='')
{
alert("Please Enter Comment Text");
}
else
{
$.ajax({
type: "POST",
url: "ajax_statuscomment.php",
data: dataString,
cache: false,
success: function(html){
$("#ctextarea"+ID).html(html);
$("#ctextarea"+ID).val('');	
$("#ctextarea"+ID).focus(); 
 }
 });
}
return false;
});



//get Notifications

$('.notify_flag').click(function() 
{
var ID = $(this).attr("id");
var dataString = ID;
$.ajax({
type: "POST",
url: "ajax_get_notifications.php",
data: dataString,
cache: false,
success: function(html){
$("#notifications").html(html);
  }
 });
return false;
});


//get Suggestions

$('.search').keyup(function() 
{
var searchval = $("#search").val();
var dataString = 'search='+ searchval;
 if(searchval=="")
 {
 document.getElementById("suggest").style.display="none";
 
 }
 else
 {
 document.getElementById("suggest").style.display="block";
 $.ajax({
type: "POST",
url: "ajax_get_suggested_search.php",
data: dataString,
cache: false,
success: function(html){
$("#suggest").html(html);
  }
 });
 }
return false;
});


//get Career Peeps By Country

$('.con').change(function() 
{
var emp_career = $("#emp_career").val();
var country = $("#con").val();
var dataString = 'career='+emp_career+'&con='+country;
 if(emp_career=="")
 {
document.getElementById("career_pps").innerHTML="Please Make a Selection";
 }
 else
 {
document.getElementById("career_pps").innerHTML="Please Wait";
 $.ajax({
type: "POST",
url: "ajax_get_career_peeps_country.php",
data: dataString,
cache: false,
success: function(html){
$("#career_pps").html(html);
  }
 });
 }
return false;
});



//get Career Peeps By State or City Name

$('.state').keyup(function() 
{
var emp_career = $("#emp_career").val();
var country = $("#con").val();
var place_wrk = $("#pow").val();
var state = $("#state").val();
var dataString = 'career='+emp_career+'&con='+country+'&state='+state+'&place_wrk='+place_wrk;
 if(emp_career=="")
 {
document.getElementById("career_pps").innerHTML="Please Make a Selection";
 }
 else
 {
document.getElementById("career_pps").innerHTML="Please Wait";
 $.ajax({
type: "POST",
url: "ajax_get_career_peeps_state.php",
data: dataString,
cache: false,
success: function(html){
$("#career_pps").html(html);
  }
 });
 }
return false;
});


//get Career Peeps By Place of Work.

$('.pow').keyup(function() 
{
var emp_career = $("#emp_career").val();
var country = $("#con").val();
var place_wrk = $("#pow").val();
var state = $("#state").val();
var dataString = 'career='+emp_career+'&con='+country+'&state='+state+'&place_wrk='+place_wrk;
 if(emp_career=="")
 {
document.getElementById("career_pps").innerHTML="Please Make a Selection";
 }
 else
 {
document.getElementById("career_pps").innerHTML="Please Wait";
 $.ajax({
type: "POST",
url: "ajax_get_career_peeps_pow.php",
data: dataString,
cache: false,
success: function(html){
$("#career_pps").html(html);
  }
 });
 }
return false;
});



//get Career Peeps

$('.emp_career').change(function() 
{
var emp_career = $("#emp_career").val();
var dataString = 'career='+ emp_career;
 if(emp_career=="")
 {
document.getElementById("career_peeps_div").innerHTML="Please Make a Selection";
 
 }
 else
 {
document.getElementById("career_peeps_div").innerHTML="Please Wait";
$("#career_div").fadeOut('slow');
 $.ajax({
type: "POST",
url: "ajax_get_career_peeps.php",
data: dataString,
cache: false,
success: function(html){
$("#career_peeps_div").html(html);
  }
 });
 }
return false;
});


// Connect User Career Page
$(".connect_button").click(function() 
{
var career_id = $("#career_id").val();
var dataString = 'career='+career_id;
if(career_id=='')
{
alert("Please Choose a career!");
}
else
{
$("#flash").show();
$("#flash").fadeIn(400).html('Wait...');
$.ajax({
type: "POST",
url: "ajax_connect_user_career.php",
data: dataString,
cache: false,
success: function(html)
{
$("#flash").fadeOut('slow');
window.location.href="career_page.php?career_id="+career_id;
  }
 });
}
return false;
	});


// Update Status Career Page
$(".career_update_button").click(function() 
{
var updateval = $("#update").val();
var userid = $("#uid").val();
var page = $("#page").val();
var email = $("#email").val();
var dataString = 'update='+ updateval+'&uid='+ userid+'&page='+page+'&email='+ email;
if(updateval=='')
{
alert("Please Enter Some Text");
}
else
{
$("#flash").show();
$("#flash").fadeIn(400).html('Wait...');
$.ajax({
type: "POST",
url: "ajax_statusmessage_career.php",
data: dataString,
cache: false,
success: function(html)
{
$("#flash").fadeOut('slow');
 document.getElementById("stausmsg").innerHTML=html;
$("#update").val('');	
$("#update").focus();
$("#stexpand").oembed(updateval);
  }
 });
}
return false;
	});
	


// Send Chat Msg 
$(".update_button").click(function() 
{
var updateval = $("#update").val();
var updateid = $("#uid").val();
var page = $("#page").val();
var email = $("#email").val();
var dataString = 'update='+ updateval+'&uid='+ updateid+'&page='+page+'&email='+ email;
if(updateval=='')
{
alert("Please Enter Some Text");
}
else
{
$("#flash").show();
$("#flash").fadeIn(400).html('Wait...');
$.ajax({
type: "POST",
url: "ajax_statusmessage.php",
data: dataString,
cache: false,
success: function(html)
{
$("#flash").fadeOut('slow');
 document.getElementById("stausmsg").innerHTML=html;
$("#update").val('');	
$("#update").focus();
$("#stexpand").oembed(updateval);
  }
 });
}
return false;
	});


// Load Post

	

// commentopen 
$('.commentopen').live("click",function() 
{
var ID = $(this).attr("id");
$("#commentbox"+ID).slideToggl('slow');
return false;
});	

// delete comment
$('.stcommentdelete').live("click",function() 
{
var ID = $(this).attr("id");
var dataString = 'com_id='+ ID;

if(confirm("Sure you want to delete this update? There is NO undo!"))
{

$.ajax({
type: "POST",
url: "delete_comment_ajax.php",
data: dataString,
cache: false,
success: function(html){
 $("#stcommentbody"+ID).slideUp();
 }
 });

}
return false;
});
	// delete update
$('.stdelete').live("click",function() 
{
var ID = $(this).attr("id");
var dataString = 'msg_id='+ ID;

if(confirm("Sure you want to delete this update? There is NO undo!"))
{

$.ajax({
type: "POST",
url: "delete_message_ajax.php",
data: dataString,
cache: false,
success: function(html){
 $("#stbody"+ID).slideUp();
 }
 });
}
return false;
});
});

