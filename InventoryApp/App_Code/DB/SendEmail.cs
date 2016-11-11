using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

/// <summary>
/// Summary description for SendEmail
/// </summary>
public class SendEmail
{
	public SendEmail()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static bool SendEmailAlert(System.Collections.ArrayList ArrayTo,  string MsgHeader, string msgbody, System.Collections.ArrayList ArrayAttachmenturl)
    {
        try
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("noreply@esutportal.net", MsgHeader );
            for (int i = 0; i < ArrayTo.Count; i++)
            {
                msg.To.Add(new MailAddress(ArrayTo[i].ToString()));
            }
            msg.IsBodyHtml = true;
            msg.Body = msgbody;

            if (ArrayAttachmenturl.Count >0)
            {
                for (int j = 0; j < ArrayAttachmenturl.Count; j++)
                {
                    msg.Attachments.Add(new Attachment(HttpContext.Current.Server.MapPath(ArrayAttachmenturl[j].ToString())));
                }
            }

            SmtpClient mSmtpClient = new SmtpClient();
            mSmtpClient.EnableSsl = false;
            mSmtpClient.Send(msg);

            return true;

        }
        catch (Exception emsg)
        {
            throw emsg;
        }
        return false;


    }
}