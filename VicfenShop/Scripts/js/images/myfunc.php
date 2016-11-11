<?php

function login($username, $pass)
// check username and password with db
// if yes, return true
// else return false
{
// connect to db
$conn = db_connect();
if (!$conn)
return false;
// check if username is unique
$result = mysql_query("select * from admin
where (username='$username')
and (password = '$pass')");
if (!$result)
return false;
if (mysql_num_rows($result)>0)
return true;
else
return false;
}
function check_valid_user()
// see if somebody is logged in and notify them if not
{
global $_SESSION;
if (!isset($_SESSION['login']))
{
$ms = "Please Login to continue!";
$_SESSION['mes'] = $ms;
header('Location: index.php');
}
}

function change_password($username, $old_password, $new_password)
// change password for username/old_password to new_password
// return true or false
{
// if the old password is right
// change their password to new_password and return true
// else return false
if (login($username, $old_password))
{
if (!($conn = db_connect()))
return false;
$result = mysql_query( "update register
set password = '$new_password'
where username = '$username'");
if (!$result)
return false; // not changed
else
return true; // changed successfully
}
else
return false; // old password was wrong
}
function reset_password($username)
// set password for username to a random value
// return the new password or false on failure
{
// get a random dictionary word b/w 6 and 13 chars in length
$new_password = get_random_word(6, 13);
if($new_password==false)
return false;
// add a number between 0 and 999 to it
// to make it a slightly better password
srand ((double) microtime() * 1000000);
$rand_number = rand(0, 999);
$new_password .= $rand_number;
// set user's password to this in database or return false
if (!($conn = db_connect()))
return false;
$result = mysql_query( "update register
set password = '$new_password'
where username = '$username'");
if (!$result)
return false; // not changed
else
return $new_password; // changed successfully
}
function get_random_word($min_length, $max_length)
// grab a random word from dictionary between the two lengths
// and return it
{
// generate a random word
$word = '';
//remember to change this path to suit your system
$dictionary = '/usr/dict/words'; // the ispell dictionary
$fp = fopen($dictionary, 'r');
if(!$fp)
return false;
$size = filesize($dictionary);
// go to a random location in dictionary
srand ((double) microtime() * 1000000);
$rand_location = rand(0, $size);
fseek($fp, $rand_location);
// get the next whole word of the right length in the file
while (strlen($word)< $min_length || strlen($word)>$max_length
|| strstr($word, "'"))
{
if (feof($fp))
fseek($fp, 0); // if at end, go to start
$word = fgets($fp, 80); // skip first word as it could be partial
$word = fgets($fp, 80); // the potential password
};
$word=trim($word); // trim the trailing \n from fgets
return $word;
}
function notify_password($username, $password)
// notify the user that their password has been changed
{
if (!($conn = db_connect()))
return false;
$result = mysql_query("select email from register
where username='$username'");
if (!$result)
{
return false; // not changed
}
else if (mysql_num_rows($result)==0)
{
return false; // username not in db
}
else
{
$email = mysql_result($result, 0, 'email');
$from = "From: support@phpbookmark \r\n";
$mesg = "Your PHPBookmark password has been changed to $password \r\n"
."Please change it next time you log in. \r\n";
if (mail($email, 'PHPBookmark login information', $mesg, $from))
return true;
else
return false;
}
}

function db_connect()
{
$result = mysql_pconnect('localhost', 'bccmport_vicfen', 'junior5555');
if (!$result)
return false;
if (!mysql_select_db('bccmport_cers'))
return false;
return $result;
}
function filled_out($form_vars)
{
// test that each variable has a value
foreach ($form_vars as $key => $value)
{
if (!isset($key) || ($value == ''))
return false;
}
return true;
}
function valid_email($address)
{
// check an email address is possibly valid
if (ereg('^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+$', $address))
return true;
else
return false;
}

function display_profile_pic(){
  db_connect(); 
		  $query2 = mysql_query("select `picname` from `upload` where `pic_id` = '$_SESSION[pic_id]'");
while ($query3 = mysql_fetch_array($query2)) {
$user_image = $query3["picname"];
$_SESSION['pic'] = $user_image;

}
$query4 = mysql_query("select count(*) from upload where `pic_id` = '$_SESSION[pic_id]'") or die ("Cannot Select");
$result4 = mysql_result($query4,0);
if ($result4>0)
{
  
	  echo "<img name='' src='passports/$user_image' alt='' width = '80' height = '100' />".'<br>  ';  
	
		}
	  else
	  {
	  $default_image= "54635ricemd5hty.gif";
	  echo "<img name='' src='passports/$default_image' alt='' width = '120' height = '100' />".'<br>  ';
	
	   }
	}
	
	
	function display_profile_pic3(){
  db_connect(); 
		  $query2 = mysql_query("select `picname` from `upload` where `pic_id` = '$_SESSION[pic_id]'");
while ($query3 = mysql_fetch_array($query2)) {
$user_image = $query3["picname"];
$_SESSION['pic'] = $user_image;

}
$query4 = mysql_query("select count(*) from upload where `pic_id` = '$_SESSION[pic_id]'") or die ("Cannot Select");
$result4 = mysql_result($query4,0);
if ($result4>0)
{
  
	  echo "<img name='' src='passports/$user_image' alt='' width = '50' height = '50' />".'<br>  ';  
	
		}
	  else
	  {
	  $default_image= "54635ricemd5hty.gif";
	  echo "<img name='' src='passports/$default_image' alt='' width = '50' height = '50' />".'<br>  ';
	
	   }
	}
	
	
	
	function display_profile_pic2(){
  db_connect(); 
		  $query2 = mysql_query("select `picname` from `thumbs` where `acct_no` = '$_SESSION[acc]'");
while ($query3 = mysql_fetch_array($query2)) {
$user_image = $query3["picname"];


}
$query4 = mysql_query("select count(*) from upload where `acct_no` = '$_SESSION[acc]' ") or die ("Cannot Select");
$result4 = mysql_result($query4,0);
if ($result4>0)
{
  
	  echo "<img name='' src='thumbs/$user_image' alt='' width = '120' height = '100' />".'<br>  ';  
	
		}
	  else
	  {
	  $default_image= "54635ricemd5hty.gif";
	  echo "<img name='' src='thumbs/$default_image' alt='' width = '120' height = '100' />".'<br>  ';

	   }
	}?>