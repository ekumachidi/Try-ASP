using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using UtilityTier;

/// <summary>
/// Summary description for MailGateway
/// </summary>
public class MailGateway
{
	public MailGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static void SendMail_JUSTHOST(string fullname, string campus, string session, string pin)
    {

        const string fromAddress = "support@tenece.com";
        const string toAddress = "chisom.onu@tenece.com";
        string fromPassword = "1@Password";
        string subject = "Notif@MIC_Applications";

        string body = "MIC Application\n";
        body += "===============================\n";
        body += "Fullname: " + fullname + "\n";
        body += "Campus: " + campus + "\n";
        body += "Session: " + session + "\n";
        body += "Pin: " + pin + "\n";
        body += "===============================\n";



        // smtp settings
        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = "mail.tenece.com";
            smtp.Port = 26;
            
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 20000;
        }

        // Passing values to smtp object
        smtp.Send(fromAddress, toAddress, subject, body);
    }


    public static void SendMail_GMAIL(string school,string name,string matricNo,string sessionName,string paymentpurpose, string feeType,string level, string message)
    {

        const string fromAddress = "feedback@tenece.com"; //mail address for authentication
        const string toAddress = "geoffery.mba@tenece.com";
		 const string toAddress2 = "chisom.onu@tenece.com";
		  const string toAddress3 = "william.enemali@tenece.com";
        const string fromPassword = "1@Password1";
        string subject = "Feedback@Tenece";

        string body = "Please see below the feedback from the portal;\n";
        body += "========================================================\n";
        body += "          School: " + school + "\n";
        body += "          StudentName: " + name + "\n";
        body += "          MatricNo: " + matricNo + "\n";
        body += "          Session: " + sessionName + "\n";
        body += "          PaymentPurpose: " + paymentpurpose + " ("+feeType+") \n";
        body += "          Level: " + level + "\n";
        body += "          Problem/Issue: " + message + "\n";
        body += "  Kindly give this urgent attention;" + "\n";
        body += "  escalate to the levels of support if necessary" + "\n";
        body += "  for more details, contact support@tenece.com" + "\n";
        body += "=======================================================\n";


        // smtp settings
        var smtp = new System.Net.Mail.SmtpClient();
        {

            //smtp.Host = "mail.tenece.com";
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            //smtp.Port = 26;


            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 20000;
        }

        // Passing values to smtp object
        smtp.Send(fromAddress, toAddress, subject, body);
		 smtp.Send(fromAddress, toAddress2, subject, body);
		  smtp.Send(fromAddress, toAddress3, subject, body);
    }


 }