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
using System.Collections;

/// <summary>
/// Summary description for PrintQuestion
/// </summary>
public class PrintQuestion
{
	public PrintQuestion()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private Label LoadBlueLabel(string labelValue, bool isBold)
    {

        Label itemLabel = new Label();


        itemLabel.Font.Size = FontUnit.XXSmall;
        itemLabel.Font.Bold = isBold;
        itemLabel.Font.Name = "Verdana";

        itemLabel.ForeColor = System.Drawing.Color.DarkBlue;

        itemLabel.Text = labelValue;

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
    private Image LoadImage(string imageUrl, bool isVisible)
    {
        Image img = new Image();

        img.ImageUrl = imageUrl;
        img.Height = Unit.Pixel(100);
        img.Width = Unit.Pixel(100);
        img.Visible = isVisible;

        return img;
    }


    private Label LoadLabel(string labelValue, bool isBold)
    {
        Label itemLabel = new Label();


        itemLabel.Font.Size = FontUnit.XXSmall;
        itemLabel.Font.Bold = isBold;
        itemLabel.Font.Name = "Verdana";

        itemLabel.Text = labelValue;

        return itemLabel;

    }

    private Label LoadHidenLabel(string labelValue, string name)
    {
        Label itemLabel = new Label();

        itemLabel.ID = name;
        itemLabel.Font.Size = FontUnit.XXSmall;
        itemLabel.Font.Bold = false ;
        itemLabel.Font.Name = "Verdana";
        itemLabel.Visible = false;
        itemLabel.Text = labelValue;

        return itemLabel;

    }


    private RadioButtonList LoadDropDownList(ArrayList ArrayList, string DropDownName, int index)
    {
        RadioButtonList itemLabel = new RadioButtonList();
        
        itemLabel.ID = "RadioList" + DropDownName;
        itemLabel.Font.Size = FontUnit.XXSmall;
        itemLabel.Font.Bold = true;
        itemLabel.Font.Name = "Verdana";
      
        for (int i = 0; i < ArrayList.Count; i++)
        {
            itemLabel.Items.Add(Convert.ToString(ArrayList[i]));

        }
        if (index != -1)
        {
            itemLabel.SelectedIndex = index;
        }

        itemLabel.Enabled = false;
        return itemLabel;

    }


    private string LoadHtmlTop()
    {
        string HTML_TOP;

        HTML_TOP = "<DIV align='center' ms_positioning='FlowLayout'>";
        HTML_TOP += "<TABLE id='Table1' style='WIDTH: 528px; HEIGHT: 96px' cellSpacing='0' cellPadding='0' width='528' border='0'>";
        HTML_TOP += "<TR><TD style='WIDTH: 283px; HEIGHT: 41px' bgColor='#ccccff'><TABLE id='Table2' style='WIDTH: 530px; HEIGHT: 25px'><TR> <TD align='left'>&nbsp;";

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

    public string PrintHTMLText(ArrayList Questions, ArrayList UploadOptionA, ArrayList UploadOptionB, ArrayList UploadOptionC, ArrayList UploadOptionD, ArrayList UploadedAns)
    {
        try
        {
            ArrayList Options = new ArrayList();
            StringBuilder html = new StringBuilder();
            string QuestionUrl = "";
            string Question = "";
            string OptionA = "";
            string OptionB = "";
            string OptionC = "";
            string OptionD = "";
            string Ans = "";
            bool IsPictureAvaliable = false;
            
           
                    for (int i = 0; i < Questions.Count; i++)                    {
                        Question = Convert.ToString(Questions[i]);
                        OptionA = Convert.ToString(UploadOptionA[i]);
                        OptionB = Convert.ToString(UploadOptionB[i]);
                        OptionC = Convert.ToString(UploadOptionC[i]);
                        OptionD = Convert.ToString(UploadOptionD[i]);
                        Ans = Convert.ToString(UploadedAns[i]);

                        int Index = -1;
                        if (Ans.ToUpper().Trim() == "A")
                        {
                            Index = 0;
                        }
                        else if (Ans.ToUpper().Trim() == "B")
                        {
                            Index = 1;
                        }
                        else if (Ans.ToUpper().Trim() == "C")
                        {
                            Index = 2;
                        }
                        else if (Ans.ToUpper().Trim() == "D")
                        {
                            Index = 3;
                        }
                                IsPictureAvaliable = false;
                        

                        Options.Clear();
                        Options.Add(OptionA);
                        Options.Add(OptionB);
                        Options.Add(OptionC);
                        Options.Add(OptionD);


                        //create html element
                        html.Append(LoadTopHTML());
                        
                            Image img = new Image();
                            img = LoadImage(QuestionUrl,IsPictureAvaliable);

                            StringBuilder sb = new StringBuilder();
                            StringWriter sw = new StringWriter(sb);
                            HtmlTextWriter htw = new HtmlTextWriter(sw);
                            img.RenderControl(htw);
                            html.Append(sb.ToString());
                            sb = null;
                            sw = null;
                            htw = null;
                       int k = i + 1;
                        //create html element
                        html.Append(LoadMiddleHTML1());
                        html.Append(WriteHTMLControl("QUESTION " + k + " : ", true).ToString());

                        html.Append(LoadMiddleHTML2());
                        html.Append(WriteHTMLControl(Question, false).ToString());

                        html.Append(LoadMiddleHTML3());
                        html.Append(WriteHTMLControl("", true).ToString());

                        html.Append(LoadMiddleHTML4());
                        html.Append(WriteDropDownControl(Options, k.ToString(),Index));

                        html.Append(LoadMiddleHTML5());
                        html.Append(WriteHiddenHTMLControl(Ans, k.ToString()));

                        html.Append(LoadMiddleHTML6());
                        html.Append(WriteHTMLControl("", false).ToString());



                        html.Append(LoadBottomHTML());

                        //html.Append("<BR/>");

                        string nn = html.ToString();
                    }
                
            

            return html.ToString();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
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

    private StringBuilder WriteHiddenHTMLControl(string controlValue, string LabelName)
    {
        try
        {
            Label label = new Label();
            label = this.LoadHidenLabel(controlValue, LabelName);

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


    private StringBuilder WriteDropDownControl(ArrayList controlValue, string dropDownName,int index)
    {
        try
        {
            RadioButtonList label = new RadioButtonList();
            label = this.LoadDropDownList(controlValue, dropDownName,index);

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

}
