using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for LogicalSecurityHandler
/// </summary>
public class LogicalSecurityHandler
{
	public LogicalSecurityHandler()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string doEncrypt(string textToEncrypt)
    {
        try
        {
            Random random = new Random();

            System.Text.StringBuilder inSb = new System.Text.StringBuilder(textToEncrypt);
            System.Text.StringBuilder outSb = new System.Text.StringBuilder(textToEncrypt.Length);
            char c;
            for (int i = 0; i < textToEncrypt.Length; i++)
            {
                c = inSb[i];
                int iValue = random.Next(4000, 5000);
                //c = (char)(c + key);
                outSb.Append(c);
                outSb.Append(iValue);
            }
            return outSb.ToString();
        }
        catch (Exception er)
        {
            return "";
        }
    }
    public static string doDecrypt(string textToEncrypt)
    {
        try
        {
            System.Text.StringBuilder inSb = new System.Text.StringBuilder(textToEncrypt);
            System.Text.StringBuilder outSb = new System.Text.StringBuilder(textToEncrypt.Length);
            char c;
            for (int i = 0; i < textToEncrypt.Length; i++)
            {
                c = inSb[i];
                i = i + 4;
                outSb.Append(c);
            }
            return outSb.ToString();
        }
        catch (Exception er)
        {
            return "";
        }
    }

    public static string Encrypt(string encrypData)
    {
        string Good = "";
        try
        {
            string   CharData ="" ;
            string ConChar = "";
            for (int i = 0; i < encrypData.Length; i++)
            {
                CharData = Convert.ToString(encrypData.Substring(i, 1));
                ConChar = char.ConvertFromUtf32(char.ConvertToUtf32(CharData, 0) + 128);
                Good = Good + ConChar;

            }

            //Response.Write(char.ConvertFromUtf32(65));
            //Response.Write(char.ConvertToUtf32("A", 0));

        }
        catch (Exception ex)
        {
            return  ex.Message;

        }
        return Good;


    }

    public static string Decrypt(string encrypData)
    {
        string Good = "";
        try
        {
            string CharData = "";
            string ConChar = "";
            for (int i = 0; i < encrypData.Length; i++)
            {
                CharData = Convert.ToString(encrypData.Substring(i, 1));
                ConChar = char.ConvertFromUtf32(char.ConvertToUtf32(CharData, 0) - 128);
                Good = Good + ConChar;

            }
           
            //Response.Write(char.ConvertFromUtf32(65));
            //Response.Write(char.ConvertToUtf32("A", 0));

        }
        catch (Exception ex)
        {
            return ex.Message;

        }
        return Good;


    }
}
