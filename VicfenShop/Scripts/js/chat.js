var windowFocus = true;
var username;
var sendername;
var chatHeartbeatCount = 0;
var minChatHeartbeat = 1000;
var maxChatHeartbeat = 33000;
var chatHeartbeatTime = minChatHeartbeat;
var originalTitle;
var blinkOrder = 0;
var chatboxFocus = new Array();
var newMessages = new Array();
var newMessagesWin = new Array();
var chatBoxes = new Array();

$(document).ready(function(){
	originalTitle = document.title;
	startChatSession();

	$([window, document]).blur(function(){
		windowFocus = false;
	}).focus(function(){
		windowFocus = true;
		document.title = originalTitle;
	});
});

function restructureChatBoxes() {
	align = 0;
	for (x in chatBoxes) {
		chatboxtitle = chatBoxes[x];

		if ($("#chatbox_"+chatboxtitle).css('display') != 'none') {
			if (align == 0) {
				$("#chatbox_"+chatboxtitle).css('right', '20px');
			} else {
				width = (align)*(232+7)+20;
				$("#chatbox_"+chatboxtitle).css('right', width+'px');
			}
			align++;
		}
	}
}


function chatWith(chatuser,sender) {
	
	createChatBox(chatuser,sender);
	$("#chatbox_"+chatuser+" .chatboxtextarea").focus();
}

function createChatBox(chatboxtitle,s,minimizeChatBox) {
	if ($("#chatbox_"+chatboxtitle).length > 0) {
		if ($("#chatbox_"+chatboxtitle).css('display') == 'none') {
			$("#chatbox_"+chatboxtitle).css('display','block');
			restructureChatBoxes();
		}
		$("#chatbox_"+chatboxtitle+" .chatboxtextarea").focus();
		return;
	}

	$(" <div />" ).attr("id","chatbox_"+chatboxtitle)
	.addClass("chatbox")
	.html('<div class="chatboxhead" onclick="javascript:toggleChatBoxGrowth(\''+chatboxtitle+'\')"><div class="chatboxtitle" id="'+chatboxtitle+'">'+s+'</div><div class="chatboxoptions"><a href="javascript:void(0)" onclick="javascript:toggleChatBoxGrowth(\''+chatboxtitle+'\')">-</a> <a href="javascript:void(0)" onclick="javascript:closeChatBox(\''+chatboxtitle+'\')">X</a></div><br clear="all"/></div><div class="chatboxcontent"></div><div class="chatboxinfo"><span></span></div><div class="chatboxtools"><span><a href="javascript:void(0)" onclick="javascript:closeChatBox(\''+chatboxtitle+'\')">Smileys</a></span>|<span><a href="javascript:void(0)" onclick="javascript:closeChatBox(\''+chatboxtitle+'\')">Send File</a></span>|<span><a href="javascript:void(0)" onclick="javascript:closeChatBox(\''+chatboxtitle+'\')">E-mail Chat.</a></span>|<span><a href="javascript:void(0)" onclick="javascript:closeChatBox(\''+chatboxtitle+'\')">Info.</a></span></div><div class="chatboxinput"><textarea class="chatboxtextarea" onkeydown="javascript:return checkChatBoxInputKey(event,this,\''+chatboxtitle+'\');" onfocus="javascript:return updateMsgStatus(\''+chatboxtitle+'\');" onkeyup="javascript:return NotifyMsgInitialization(\''+chatboxtitle+'\');"></textarea></div>')
	.appendTo($( "body" ));
	$("#chatbox_"+chatboxtitle).css('bottom', '0px');
	$.post("chat.php?action=getname", { cname: chatboxtitle} , function(data){	
	$("#"+chatboxtitle).html(data.titlepic+'&nbsp;&nbsp;'+data.titlename);																
	});
	
	chatBoxeslength = 0;

	for (x in chatBoxes) {
		if ($("#chatbox_"+chatBoxes[x]).css('display') != 'none') {
			chatBoxeslength++;
		}
	}

	if (chatBoxeslength == 0) {
		$("#chatbox_"+chatboxtitle).css('right', '20px');
	} else {
		width = (chatBoxeslength)*(232+7)+20;
		$("#chatbox_"+chatboxtitle).css('right', width+'px');
	}
	
	chatBoxes.push(chatboxtitle);

	if (minimizeChatBox == 1) {
		minimizedChatBoxes = new Array();

		if ($.cookie('chatbox_minimized')) {
			minimizedChatBoxes = $.cookie('chatbox_minimized').split(/\|/);
		}
		minimize = 0;
		for (j=0;j<minimizedChatBoxes.length;j++) {
			if (minimizedChatBoxes[j] == chatboxtitle) {
				minimize = 1;
			}
		}

		if (minimize == 1) {
			$('#chatbox_'+chatboxtitle+' .chatboxcontent').css('display','none');
			$('#chatbox_'+chatboxtitle+' .chatboxinput').css('display','none');
			$('#chatbox_'+chatboxtitle+' .chatboxtools').css('display','none');
		}
	}

	chatboxFocus[chatboxtitle] = false;

	$("#chatbox_"+chatboxtitle+" .chatboxtextarea").blur(function(){
		chatboxFocus[chatboxtitle] = false;
		$("#chatbox_"+chatboxtitle+" .chatboxtextarea").removeClass('chatboxtextareaselected');
	}).focus(function(){
		chatboxFocus[chatboxtitle] = true;
		newMessages[chatboxtitle] = false;
		$('#chatbox_'+chatboxtitle+' .chatboxhead').removeClass('chatboxblink');
		$("#chatbox_"+chatboxtitle+" .chatboxtextarea").addClass('chatboxtextareaselected');
	});

	$("#chatbox_"+chatboxtitle).click(function() {
		if ($('#chatbox_'+chatboxtitle+' .chatboxcontent').css('display') != 'none') {
			$("#chatbox_"+chatboxtitle+" .chatboxtextarea").focus();
		}
	});

	$("#chatbox_"+chatboxtitle).show();
}


function chatHeartbeat(){

	var itemsfound = 0;
	
	if (windowFocus == false) {
 
		var blinkNumber = 0;
		var titleChanged = 0;
		for (x in newMessagesWin) {
			if (newMessagesWin[x] == true) {
				++blinkNumber;
				if (blinkNumber >= blinkOrder) {
					document.title = x+' says...';
					titleChanged = 1;
					break;	
				}
			}
		}
		
		if (titleChanged == 0) {
			document.title = originalTitle;
			blinkOrder = 0;
		} else {
			++blinkOrder;
		}

	} else {
		for (x in newMessagesWin) {
			newMessagesWin[x] = false;
		}
	}

	for (x in newMessages) {
		if (newMessages[x] == true) {
			if (chatboxFocus[x] == false) {
				//FIXME: add toggle all or none policy, otherwise it looks funny
				$('#chatbox_'+x+' .chatboxhead').toggleClass('chatboxblink');
			}
		}
	}
	
	$.ajax({
	  url: "chat.php?action=chatheartbeat",
	  cache: false,
	  dataType: "json",
	  success: function(data) {

		$.each(data.items, function(i,item){
			if (item)	{ // fix strange ie bug

				chatboxtitle = item.f;
				sendername = item.n;

				if ($("#chatbox_"+chatboxtitle).length <= 0) {
					createChatBox(item.f,sendername,1);
				}
				if ($("#chatbox_"+chatboxtitle).css('display') == 'none') {
					$("#chatbox_"+chatboxtitle).css('display','block');
					restructureChatBoxes();
				}
				
				if (item.s == 1) {
					item.f = username;
				    
				}

				if (item.s == 2) {
					$("#chatbox_"+chatboxtitle+" .chatboxcontent").append('<div class="chatboxmessage"><span class="chatboxinfo">'+item.m+'</span></div>');
				} else {
					newMessages[chatboxtitle] = true;
					newMessagesWin[chatboxtitle] = true;
					if(chatboxtitle==item.f)
					{
					$("#chatbox_"+chatboxtitle+" .chatboxcontent").append('<div ><table width="100%"  border="0" cellpadding="0" cellspacing="0"><tr><td  width="165" height="22" valign="top" style="background-image:url(images/chat_im_top.png);"><div align="center"></div></td><td width="25" rowspan="2" valign="top" ><div align="center">'+item.sp+'</div></td></tr><tr><td width="150" valign="top" style="background-image:url(images/chat_im_mid.png); margin-top:0px; padding-right:12px;" ><div align="right" style="width:150px; word-wrap:break-word;">'+item.m+'</div></td></tr>  <tr><td style="background-image:url(images/chat_im_buttom.png);" valign="top">&nbsp;</td><td  >&nbsp;</td></tr></table></div>');
					}
					else
					{
					$("#chatbox_"+chatboxtitle+" .chatboxcontent").append('<div ><table width="100%"  border="0" cellpadding="0" cellspacing="0"><tr><td width="25" rowspan="2" valign="top"><div align="center">'+item.sp+'</div></td><td width="165" height="22" valign="top" style="background-image:url(images/chat_im_top2.png);">&nbsp;</td></tr><tr><td width="150" valign="top" style="background-image:url(images/chat_im_mid2.png); margin-top:0px; padding-left:20px;"><div align="left" style="width:150px; word-wrap:break-word;">'+item.m+'</div></td></tr>  <tr><td>&nbsp;</td><td valign="top" style="background-image:url(images/chat_im_buttom2.png);">&nbsp;</td></tr></table></div>')
					}
				}

				$("#chatbox_"+chatboxtitle+" .chatboxcontent").scrollTop($("#chatbox_"+chatboxtitle+" .chatboxcontent")[0].scrollHeight);
				itemsfound += 1;
			}
		});

		chatHeartbeatCount++;

		if (itemsfound > 0) {
			chatHeartbeatTime = minChatHeartbeat;
			chatHeartbeatCount = 1;
		} else if (chatHeartbeatCount >= 10) {
			chatHeartbeatTime *= 2;
			chatHeartbeatCount = 1;
			if (chatHeartbeatTime > maxChatHeartbeat) {
				chatHeartbeatTime = maxChatHeartbeat;
			}
		}
		
		setTimeout('chatHeartbeat();',chatHeartbeatTime);
	}});
}

function closeChatBox(chatboxtitle) {
	$('#chatbox_'+chatboxtitle).css('display','none');
	restructureChatBoxes();

	$.post("chat.php?action=closechat", { chatbox: chatboxtitle} , function(data){	
	});

}

function updateMsgStatus(chatboxtitle) {
		$.post("chat.php?action=updatemsgstatus", { chatbox: chatboxtitle} , function(data){
																					 
	});

}

function toggleChatBoxGrowth(chatboxtitle) {
	if ($('#chatbox_'+chatboxtitle+' .chatboxcontent').css('display') == 'none') {  
		
		var minimizedChatBoxes = new Array();
		
		if ($.cookie('chatbox_minimized')) {
			minimizedChatBoxes = $.cookie('chatbox_minimized').split(/\|/);
		}

		var newCookie = '';

		for (i=0;i<minimizedChatBoxes.length;i++) {
			if (minimizedChatBoxes[i] != chatboxtitle) {
				newCookie += chatboxtitle+'|';
			}
		}

		newCookie = newCookie.slice(0, -1)


		$.cookie('chatbox_minimized', newCookie);
		$('#chatbox_'+chatboxtitle+' .chatboxcontent').css('display','block');
		$('#chatbox_'+chatboxtitle+' .chatboxinput').css('display','block');
		$('#chatbox_'+chatboxtitle+' .chatboxtools').css('display','block');
		$("#chatbox_"+chatboxtitle+" .chatboxcontent").scrollTop($("#chatbox_"+chatboxtitle+" .chatboxcontent")[0].scrollHeight);
	} else {
		
		var newCookie = chatboxtitle;

		if ($.cookie('chatbox_minimized')) {
			newCookie += '|'+$.cookie('chatbox_minimized');
		}


		$.cookie('chatbox_minimized',newCookie);
		$('#chatbox_'+chatboxtitle+' .chatboxcontent').css('display','none');
		$('#chatbox_'+chatboxtitle+' .chatboxinput').css('display','none');
		$('#chatbox_'+chatboxtitle+' .chatboxtools').css('display','none');
	}
	
}


function startChatSession(){  
	$.ajax({
	  url: "chat.php?action=startchatsession",
	  cache: false,
	  dataType: "json",
	  success: function(data) {
 
		username = data.username;

		$.each(data.items, function(i,item){
			if (item)	{ // fix strange ie bug

				chatboxtitle = item.f;
				
				if ($("#chatbox_"+chatboxtitle).length <= 0) {
					
					createChatBox(chatboxtitle,item.f,1);
					
				}
				
				if (item.s == 1) {
					item.f = item.n;
					sendername = item.n;
				}

				if (item.s == 2) {
					$("#chatbox_"+chatboxtitle+" .chatboxcontent").append('<div class="chatboxmessage"><span class="chatboxinfo">'+item.m+'</span></div>');
				} else {
					if(chatboxtitle==item.f)
					{
					$("#chatbox_"+chatboxtitle+" .chatboxcontent").append('<div ><table width="100%"  border="0" cellpadding="0" cellspacing="0"><tr><td  width="165" height="22" valign="top" style="background-image:url(images/chat_im_top.png);"><div align="center"></div></td><td width="25" rowspan="2" valign="top" ><div align="center">'+item.sp+'</div></td></tr><tr><td width="150" valign="top" style="background-image:url(images/chat_im_mid.png); margin-top:0px; padding-right:12px;" ><div align="right" style="width:150px; word-wrap:break-word;">'+item.m+'</div></td></tr>  <tr><td style="background-image:url(images/chat_im_buttom.png);" valign="top">&nbsp;</td><td  >&nbsp;</td></tr></table></div>');
					}
					else
					{
					$("#chatbox_"+chatboxtitle+" .chatboxcontent").append('<div ><table width="100%"  border="0" cellpadding="0" cellspacing="0"><tr><td width="25" rowspan="2" valign="top"><div align="center">'+item.sp+'</div></td><td width="165" height="22" valign="top" style="background-image:url(images/chat_im_top2.png);">&nbsp;</td></tr><tr><td width="150" valign="top" style="background-image:url(images/chat_im_mid2.png); margin-top:0px; padding-left:20px;"><div align="left" style="width:150px; word-wrap:break-word;">'+item.m+'</div></td></tr>  <tr><td>&nbsp;</td><td valign="top" style="background-image:url(images/chat_im_buttom2.png);">&nbsp;</td></tr></table></div>')
					}
				
				}
			}
		});
		
		for (i=0;i<chatBoxes.length;i++) {
			chatboxtitle = chatBoxes[i];
			$("#chatbox_"+chatboxtitle+" .chatboxcontent").scrollTop($("#chatbox_"+chatboxtitle+" .chatboxcontent")[0].scrollHeight);
			setTimeout('$("#chatbox_"+chatboxtitle+" .chatboxcontent").scrollTop($("#chatbox_"+chatboxtitle+" .chatboxcontent")[0].scrollHeight);', 100); // yet another strange ie bug
		}
	
	setTimeout('chatHeartbeat();',chatHeartbeatTime);
		
	}});
}

  // DOMAIN JQUERY COOKIES COPYRIGHT 2013 SMARTKON.COM
jQuery.cookie = function(name, value, options) {
    if (typeof value != 'undefined') { // name and value given, set cookie
        options = options || {};
        if (value === null) {
            value = '';
            options.expires = -1;
        }
        var expires = '';
        if (options.expires && (typeof options.expires == 'number' || options.expires.toUTCString)) {
            var date;
            if (typeof options.expires == 'number') {
                date = new Date();
                date.setTime(date.getTime() + (options.expires * 24 * 60 * 60 * 1000));
            } else {
                date = options.expires;
            }
            expires = '; expires=' + date.toUTCString(); // use expires attribute, max-age is not supported by IE
        }
              
        var path = options.path ? '; path=' + (options.path) : '';
        var domain = options.domain ? '; domain=' + (options.domain) : '';
        var secure = options.secure ? '; secure' : '';
        document.cookie = [name, '=', encodeURIComponent(value), expires, path, domain, secure].join('');
    } else { // only name given, get cookie
        var cookieValue = null;
        if (document.cookie && document.cookie != '') {
            var cookies = document.cookie.split(';');
            for (var i = 0; i < cookies.length; i++) {
                var cookie = jQuery.trim(cookies[i]);
                // Does this cookie string begin with the name we want?
                if (cookie.substring(0, name.length + 1) == (name + '=')) {
                    cookieValue = decodeURIComponent(cookie.substring(name.length + 1));
                    break;
                }
            }
        }
        return cookieValue;
    }
};