using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.IO;
using System.Text;
using System.Data.SqlClient;
//using UtilityTier;
//using Education_CommonObject;
//using Setup_CommonObject;
//using SystemAccess_CommonObject;

/// <summary>
/// Summary description for Print
/// </summary>
public class Print
{
    private DataSet dsUserInfo = null;

    private string instruction1 = "";
    private string instruction2 = "";
    private string instruction3 = "";
    private string instruction4 = "";

    private string school = "";
    private string cardCategory = "";
    private string specificCategory = "";

    public Print()
    {
        //dsUserInfo = _dsUserInfo;
    }

        //public PrintPassword(DataSet _dsUserInfo)
        //{
        //    dsUserInfo=_dsUserInfo;
        //}

		private Label LoadBlueLabel(string labelValue, bool isBold)
		{

			Label itemLabel = new Label();


			itemLabel.Font.Size = FontUnit.XXSmall;
            itemLabel.Font.Bold = isBold;
			itemLabel.Font.Name="Verdana";

			itemLabel.ForeColor= System.Drawing.Color.DarkBlue;

			itemLabel.Text=labelValue;

			return itemLabel;

		}
    public DataSet Loaddatasource(string query)
    {
        DataSet dsV = null;
        try
        {
            string constring = ConfigurationManager.AppSettings["ConnStr"];

            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myadp = new SqlDataAdapter();
            myadp.SelectCommand = cmd;
            DataSet ds = new DataSet();
            myadp.Fill(ds);
            conn.Close();
            dsV = ds;
            return dsV;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsV;
    }
    private Image LoadImage(string imageUrl)
    {
        Image img = new Image();

        img.ImageUrl = imageUrl;
        img.Height = Unit.Pixel(100);
        img.Width = Unit.Pixel(100);

        return img;
    }


    private Label LoadLabel(string labelValue, bool isBold)
		{
			Label itemLabel = new Label();


			itemLabel.Font.Size = FontUnit.XXSmall;
            itemLabel.Font.Bold = isBold;
			itemLabel.Font.Name="Verdana";

			itemLabel.Text=labelValue;

			return itemLabel;

		}

		private string LoadHtmlTop()
		{
			string  HTML_TOP;

			HTML_TOP = "<DIV align='center' ms_positioning='FlowLayout'>";
			HTML_TOP +=   "<TABLE id='Table1' style='WIDTH: 528px; HEIGHT: 96px' cellSpacing='0' cellPadding='0' width='528' border='0'>";
			HTML_TOP +=   "<TR><TD style='WIDTH: 283px; HEIGHT: 41px' bgColor='#ccccff'><TABLE id='Table2' style='WIDTH: 530px; HEIGHT: 25px'><TR> <TD align='left'>&nbsp;";

			return HTML_TOP;
		}

		private string LoadHtmlMiddle1()
		{
			return "</TD><TD align='left'>";
		}

		private string LoadHtmlMiddle2()
		{
			return "</TD><TD align='left'>";
		}
		private string LoadHtmlMiddle3()
		{
			return "</TD></TR></TABLE></TD></TR><TR><TD style='WIDTH: 283px' bgColor='lavender'><TABLE id='Table3' style='WIDTH: 530px; HEIGHT: 25px'><TR><TD style='WIDTH: 150px'><FONT face='Verdana' size='1'><STRONG>&nbsp;&nbsp; User Name&nbsp;&nbsp;&nbsp;&nbsp; :::</STRONG></FONT></TD><TD align='center'>";
		}

		private string LoadHtmlMiddle4()
		{
			return "</TR></TABLE></TD></TR><TR><TD style='WIDTH: 283px' bgColor='lavender'><TABLE id='Table3' style='WIDTH: 530px; HEIGHT: 25px'><TR><TD style='WIDTH: 149px'><FONT face='Verdana' size='1'><STRONG>&nbsp;&nbsp; Password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :::</STRONG></FONT></TD><TD align='center'>";
		}

		private string LoadHtmlBottom()
		{
			return "</TD></TR></TABLE></TD></TR></TABLE></DIV>";
		}

    private string LoadTopHTML()
    {
        try
        {
            string HTML_TOP = "";

            HTML_TOP = "<center>";
            HTML_TOP += "<table style='width: 569px; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;'>";
            HTML_TOP += "<tr>";
            HTML_TOP += "<td style='width: 164px' align='center' valign='top'>";

            return HTML_TOP;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private string LoadMiddleHTML1()
    {
        try
        {
            string HTML_MIDDLE1 = "";

            HTML_MIDDLE1 = "<td align='left'>";
            HTML_MIDDLE1 += "<table style='width: 449px'>";
            HTML_MIDDLE1 += "<tr>";
            HTML_MIDDLE1 += "<td style='height: 18px; background-color: #edf8fe;' align='left'>";

            return HTML_MIDDLE1;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private string LoadMiddleHTML2()
    {
        return "</td><td style='height: 18px; background-color: #edf8fe;' align='left'>";
    }
    private string LoadMiddleHTML3()
    {
        return "</td></tr><tr><td style='width: 130px' align='left'>";
        
    }
    private string LoadMiddleHTML4()
    {
        return "</td><td style='width: 338px' align='left'>";
    }
    private string LoadMiddleHTML5()
    {
        return "</td></tr><tr><td style='background-color: #edf8fe;' align='left'>";
    }
    private string LoadMiddleHTML6()
    {
        return "</td><td style='background-color: #edf8fe' align='left'>";
    }
    private string LoadMiddleHTML7()
    {
        return "</td></tr><tr><td style='width: 82px' align='left'>";
    }
    private string LoadMiddleHTML8()
    {
        return "</td><td align='left'>";
    }
    private string LoadMiddleHTML9()
    {
        return "</td></tr><tr><td style='width: 82px; background-color: #edf8fe;' align='left'>";
    }
    private string LoadMiddleHTML10()
    {
        return "</td><td style='width: 82px; background-color: #edf8fe' align='left'>";
    }
    private string LoadMiddleHTML11()
    {
        return "</td></tr><tr><td style='width: 82px' align='left'>";
    }
    private string LoadMiddleHTML12()
    {
        return "</td><td align='left'>";
    }
    private string LoadBottomHTML()
    {
        return "</tr></table></td></tr></table></center>";
    }

    public string PrintHTMLText(string departmentid, string programmeid, int postUmeType)
    {
        try
        {
            StringBuilder html = new StringBuilder();
            DataSet dsApplicant = Loaddatasource("Select * from ONLINE_PUTME_FORM_APPLICANT where SCHOOL_CHOICE_ID ='" + departmentid + "' and PROGRAMME_ID ='" + programmeid + "' order by IDENTIFICATION_NO");

            if (dsApplicant != null)
            {


                string jambScore = "";
                string department = "";
                string state = "";
                string Regno = "UTME NO:";
                if (dsApplicant.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsApplicant.Tables[0].Rows.Count; i++)
                    {
                        string postUmeApplicationNo = Convert.ToString((dsApplicant.Tables[0].Rows[i]["EXAMINATION_NO"]));
                        string name = Convert.ToString((dsApplicant.Tables[0].Rows[i]["FULLNAME"]));
                        string sex = Convert.ToString((dsApplicant.Tables[0].Rows[i]["SEX"]));
                        string jambRegNo = Convert.ToString((dsApplicant.Tables[0].Rows[i]["JAMB_REG_NO"]));

                        department  = Convert.ToString((dsApplicant.Tables[0].Rows[i]["SCHOOL_CHOICE_ID"]));

                        string passportUrl = Convert.ToString((dsApplicant.Tables[0].Rows[i]["PASSPORT_URL"]));
                         jambScore = Convert.ToString((dsApplicant.Tables[0].Rows[i]["UTME_SCORE"]));

                       
                        //set jamb score to null if applicant
                        //is direct entry applicant 
                        if (postUmeType == 2)
                        {
                            jambScore = "";
                            Regno = "APP NO:";
                        }

                        if (sex == "M")
                        {
                            sex = "Male";
                        }
                        else
                        {
                            sex = "Female";
                        }

                        //create html element
                        html.Append(LoadTopHTML());

                        Image img = new Image();
                        img = LoadImage(passportUrl);

                        StringBuilder sb = new StringBuilder();
                        StringWriter sw = new StringWriter(sb);
                        HtmlTextWriter htw = new HtmlTextWriter(sw);
                        img.RenderControl(htw);
                        html.Append(sb.ToString());
                        sb = null;
                        sw = null;
                        htw = null;

                        //create html element
                        html.Append(LoadMiddleHTML1());
                        html.Append(WriteHTMLControl("EXAM NO.:", true).ToString());

                        html.Append(LoadMiddleHTML2());
                        html.Append(WriteHTMLControl(postUmeApplicationNo, false).ToString());

                        html.Append(LoadMiddleHTML3());
                        html.Append(WriteHTMLControl("NAME:", true).ToString());

                        html.Append(LoadMiddleHTML4());
                        html.Append(WriteHTMLControl(name, false).ToString());

                        html.Append(LoadMiddleHTML5());
                        html.Append(WriteHTMLControl("SEX:", true).ToString());

                        html.Append(LoadMiddleHTML6());
                        html.Append(WriteHTMLControl(sex, false).ToString());

                        html.Append(LoadMiddleHTML7());
                        html.Append(WriteHTMLControl(Regno, true).ToString());

                        html.Append(LoadMiddleHTML8());
                        html.Append(WriteHTMLControl(jambRegNo, false).ToString());

                        if (postUmeType == 1)
                        {
                            html.Append(LoadMiddleHTML9());
                            html.Append(WriteHTMLControl("UTME SCORE:", true).ToString());

                            html.Append(LoadMiddleHTML10());
                            html.Append(WriteHTMLControl(jambScore, false).ToString());
                        }
                        html.Append(LoadMiddleHTML11());
                        html.Append(WriteHTMLControl("PROGRAMME:", true).ToString());

                        html.Append(LoadMiddleHTML12());
                        html.Append(WriteHTMLControl(programmeid, false).ToString());

                        html.Append(LoadMiddleHTML9());
                        html.Append(WriteHTMLControl("DEPARTMENT:", true).ToString());

                        html.Append(LoadMiddleHTML12());
                        html.Append(WriteHTMLControl( GetDepartment( department), false).ToString());

                        html.Append(LoadBottomHTML());

                        //html.Append("<BR/>");

                        string nn = html.ToString();
                    }
                }
            }

            return html.ToString();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    private string GetDepartment(string departmentid)
    {
        string department = "";
        try
        {
            DataSet dsDepartment = Loaddatasource("Select * from DEPARTMENT where DEPARTMENT_ID ='" + departmentid + "'");
            if (dsDepartment != null)
            {
                if (dsDepartment.Tables[0].Rows.Count > 0)
                {
                    department = Convert.ToString(dsDepartment.Tables[0].Rows[0]["DEPARTMENT_NAME"]);

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return department;
    }


    private StringBuilder WriteHTMLControl(string controlValue, bool isBold)
    {
        try
        {
            Label label = new Label();
            label = this.LoadLabel(controlValue, isBold);

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            label.RenderControl(htw);
            //sb.ToString();

            return sb;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private string LoadTopPinCodeHtml()
    {
        string HTML_TOP = "";

        HTML_TOP = "<center><table style='width: 703px'><tr><td align='center'>";
        HTML_TOP += "<table style='border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;width: 190px; border-bottom: black 1px solid'>";
        HTML_TOP += "<tr><td align='center' style='font-weight: bold; font-size: 8pt;font-family: Arial'>" + school + "</td>";
        HTML_TOP += "</tr><tr><td align='center' style='font-size: 8pt; font-family: Arial'>" + cardCategory + "</td>";
        HTML_TOP += "</tr><tr><td align='center' style='font-size: 8pt'>" + specificCategory + "</td></tr><tr>";
        HTML_TOP += "<td align='center' style='font-size: 1pt; height: 4px'>&nbsp;</td></tr><tr><td align='left'>";

        return HTML_TOP;
    }
    private string LoadMiddle1PinCodeHTML()
    {
        try
        {
            return "</td></tr><tr><td align='left'>";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private string LoadMiddle2PinCodeHTML()
    {
        try
        {
            string HTML_MIDDLE2 = "";

            HTML_MIDDLE2 = "</td></tr><tr><td align='left' style='font-weight: bold; font-size: 10pt; height: 15px; text-decoration: underline'>";
            HTML_MIDDLE2 += "INSTRUCTIONS</td></tr><tr><td align='left' style='font-size: 7pt; font-family: Arial'>" + instruction1 + "</td>";
            HTML_MIDDLE2 += "</tr><tr><td align='left' style='font-size: 7pt; font-family: Arial'>" + instruction2 + "</td>";
            HTML_MIDDLE2 += "</tr><tr><td align='left' style='font-size: 7pt; font-family: Arial'>" + instruction3 + "</td>";
            HTML_MIDDLE2 += "</tr><tr><td align='left' style='font-size: 7pt; font-family: Arial'>" + instruction4 + "</td>";
            HTML_MIDDLE2 += "</tr><tr><td align='left' style='font-size: 3pt'></td></tr></table></td><td>";
            HTML_MIDDLE2 += "<table style='border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;";
            HTML_MIDDLE2 += "width: 190px; border-bottom: black 1px solid'><tr><td align='center' style='font-weight: bold; font-size: 8pt;";
            HTML_MIDDLE2 += "font-family: Arial'>" + school + "</td></tr><tr><td align='center' style='font-size: 8pt; font-family: Arial'>";
            HTML_MIDDLE2 += "" + cardCategory + "</td></tr><tr><td align='center' style='font-size: 8pt'>" + specificCategory + "</td></tr><tr>";
            HTML_MIDDLE2 += "<td align='center' style='font-size: 1pt; height: 4px'>&nbsp;</td></tr><tr><td align='left'>";

            return HTML_MIDDLE2;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private string LoadMiddle3PinCodeHTML()
    {
        try
        {
            return "</td></tr><tr><td align='left'>";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private string LoadMiddle4PinCodeHTML()
    {
        try
        {
            string HTML_MIDDLE4 = "";

            HTML_MIDDLE4 = "</td></tr><tr><td align='left' style='font-weight: bold; font-size: 10pt; height: 15px; text-decoration: underline'>";
            HTML_MIDDLE4 += "INSTRUCTIONS</td></tr><tr><td align='left' style='font-size: 7pt; font-family: Arial'>" + instruction1 + "</td>";
            HTML_MIDDLE4 += "</tr><tr><td align='left' style='font-size: 7pt; font-family: Arial'>" + instruction2 + "</td>";
            HTML_MIDDLE4 += "</tr><tr><td align='left' style='font-size: 7pt; font-family: Arial'>" + instruction3 + "</td>";
            HTML_MIDDLE4 += "</tr><tr><td align='left' style='font-size: 7pt; font-family: Arial'>" + instruction4 + "</td>";
            HTML_MIDDLE4 += "</tr><tr><td align='left' style='font-size: 3pt'></td></tr></table></td><td>";
            HTML_MIDDLE4 += "<table style='border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;";
            HTML_MIDDLE4 += "width: 190px; border-bottom: black 1px solid'><tr><td align='center' style='font-weight: bold; font-size: 8pt;";
            HTML_MIDDLE4 += "font-family: Arial'>" + school + "</td></tr><tr><td align='center' style='font-size: 8pt; font-family: Arial'>";
            HTML_MIDDLE4 += "" + cardCategory + "</td></tr><tr><td align='center' style='font-size: 8pt'>" + specificCategory + "</td>";
            HTML_MIDDLE4 += "</tr><tr><td align='center' style='font-size: 1pt; height: 4px'>&nbsp;</td></tr><tr><td align='left'>";

            return HTML_MIDDLE4;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private string LoadMiddle5PinCodeHTML()
    {
        try
        {
            return "</td></tr><tr><td align='left'>";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private string LoadMiddle6PinCodeHTML()
    {
        try
        {
            string HTML_MIDDLE6 = "";

            HTML_MIDDLE6 = "</td></tr><tr><td align='left' style='font-weight: bold; font-size: 10pt; height: 15px; text-decoration: underline'>";
            HTML_MIDDLE6 += "INSTRUCTIONS</td></tr><tr><td align='left' style='font-size: 7pt; font-family: Arial'>" + instruction1 + "</td>";
            HTML_MIDDLE6 += "</tr><tr><td align='left' style='font-size: 7pt; font-family: Arial'>" + instruction2 + "</td>";
            HTML_MIDDLE6 += "</tr><tr><td align='left' style='font-size: 7pt; font-family: Arial'>" + instruction3 + "</td>";
            HTML_MIDDLE6 += "</tr><tr><td align='left' style='font-size: 7pt; font-family: Arial'>" + instruction4 + "</td>";
            HTML_MIDDLE6 += "</tr><tr><td align='left' style='font-size: 3pt'></td></tr></table></td><td>";
            HTML_MIDDLE6 += "<table style='border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;";
            HTML_MIDDLE6 += "width: 190px; border-bottom: black 1px solid'><tr><td align='center' style='font-weight: bold; font-size: 8pt;";
            HTML_MIDDLE6 += "font-family: Arial'>" + school + "</td></tr><tr><td align='center' style='font-size: 8pt; font-family: Arial'>";
            HTML_MIDDLE6 += "" + cardCategory + "</td></tr><tr><td align='center' style='font-size: 8pt'>" + specificCategory + "</td></tr><tr>";
            HTML_MIDDLE6 += "<td align='center' style='font-size: 1pt; height: 4px'>&nbsp;</td></tr><tr><td align='left'>";

            return HTML_MIDDLE6;


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private string LoadMiddle7PinCodeHTML()
    {
        try
        {
            return "</td></tr><tr><td align='left'>";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private string LoadBottomPinCodeHtml()
    {
        try
        {
            string HTML_BOTTOM = "";

            HTML_BOTTOM = "</td></tr><tr><td align='left' style='font-weight: bold; font-size: 10pt; height: 15px; text-decoration: underline'>";
            HTML_BOTTOM += "INSTRUCTIONS</td></tr><tr><td align='left' style='font-size: 7pt; font-family: Arial'>" + instruction1 + "</td>";
            HTML_BOTTOM += "</tr><tr><td align='left' style='font-size: 7pt; font-family: Arial'>" + instruction2 + "</td></tr><tr>";
            HTML_BOTTOM += "<td align='left' style='font-size: 7pt; font-family: Arial'>" + instruction3 + "</td>";
            HTML_BOTTOM += "</tr><tr><td align='left' style='font-size: 7pt; font-family: Arial'>" + instruction4 + "</td>";
            HTML_BOTTOM += "</tr><tr><td align='left' style='font-size: 3pt'></td></tr></table></td></tr></table></center>";

            return HTML_BOTTOM;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public string PrintSchoolFeesScratchCard(DataSet dsScratchCard)
    {
        try
        {
            const int one = 1;
            const int two = 2;
            const int three = 3;

            const string pinNo = "PIN: ";
            const string sNo = "S/NO.: ";
            school = "FED POLY UNWANA";
            cardCategory = "NON JAMB APPLICANT";
            specificCategory = "";

            instruction1 = "1. Go to www.polyunwana.net";
            instruction2 = "2. Click on Applicantions";
            instruction3 = "3. Enter Reg. No. and Pin, click Login";
            instruction4 = "";
         
            StringBuilder html = new StringBuilder();
            if (dsScratchCard != null)
            {
                ////DataSet ds = dsUserInfo;
                //Utility utilObj = new Utility();
                //PinNumberCO pncObj = new PinNumberCO();

                if (dsScratchCard.Tables[0].Rows.Count > 0)
                {
                    //
                    for (int i = 0; i < dsScratchCard.Tables[0].Rows.Count; i=i + 4 )
                    {
                        string pin1 = Convert.ToString(dsScratchCard.Tables[0].Rows[i]["PIN"]);
                        string pin2 = Convert.ToString(dsScratchCard.Tables[0].Rows[i + one]["PIN"]);
                        string pin3 = Convert.ToString(dsScratchCard.Tables[0].Rows[i + two]["PIN"]);
                        string pin4 = Convert.ToString(dsScratchCard.Tables[0].Rows[i + three]["PIN"]);

                        string serialNo1 = Convert.ToString( (dsScratchCard.Tables[0].Rows[i]["SERIAL_NUMBER"]));
                        string serialNo2 = Convert.ToString( (dsScratchCard.Tables[0].Rows[i + one]["SERIAL_NUMBER"]));
                        string serialNo3 = Convert.ToString( (dsScratchCard.Tables[0].Rows[i + two]["SERIAL_NUMBER"]));
                        string serialNo4 = Convert.ToString( (dsScratchCard.Tables[0].Rows[i + three]["SERIAL_NUMBER"]));

                        //create html element
                        html.Append(LoadTopPinCodeHtml());

                        //create html element
                        html.Append(WriteHTMLControl(pinNo + pin1, true).ToString());
                        html.Append(LoadMiddle1PinCodeHTML());

                        html.Append(WriteHTMLControl(sNo + serialNo1, true).ToString());
                        html.Append(LoadMiddle2PinCodeHTML());

                        html.Append(WriteHTMLControl(pinNo + pin2, true).ToString());
                        html.Append(LoadMiddle3PinCodeHTML());

                        html.Append(WriteHTMLControl(sNo + serialNo2, true).ToString());
                        html.Append(LoadMiddle4PinCodeHTML());

                        html.Append(WriteHTMLControl(pinNo + pin3, true).ToString());
                        html.Append(LoadMiddle5PinCodeHTML());

                        html.Append(WriteHTMLControl(sNo + serialNo3, true).ToString());
                        html.Append(LoadMiddle6PinCodeHTML());

                        html.Append(WriteHTMLControl(pinNo + pin4, true).ToString());
                        html.Append(LoadMiddle7PinCodeHTML());

                        html.Append(WriteHTMLControl(sNo + serialNo4, true).ToString());
                        html.Append(LoadBottomPinCodeHtml());

                        string nn = html.ToString();
                    }
                }
            }

            return html.ToString();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    

}
