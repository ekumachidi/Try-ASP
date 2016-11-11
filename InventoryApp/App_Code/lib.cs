#region "using"
using System;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using SubSonic;
using System.Data.Common;
using System.Net.Mail;
#endregion
public class func 
{

public static DateTime str2date(String sDate, string sFormat)
{
  if (sDate == string.Empty) return DateTime.MinValue;
    if (sFormat == "CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern")
        sFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
  sDate = sDate.Trim(); 
    if (sFormat.IndexOfAny("ms:".ToCharArray()) >= 0 && sDate.Length < 19)
    {
        if (sDate.Split(" ".ToCharArray()).Length > 1 && sDate.Length == 16)
        {
            sDate += ":00";
        }
        else sDate += " 00:00:00";
    } 
    return System.Xml.XmlConvert.ToDateTime(sDate, sFormat);
}

public static String date2str(DateTime dtDate, string sFormat)
{
  if (dtDate == DateTime.MinValue) return string.Empty;
    if (sFormat == "CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern")
       sFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
    return System.Xml.XmlConvert.ToString(dtDate, sFormat);
}

    public static string GetDateFormat(bool time)
    {
		string dateFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
		if (time) dateFormat += " HH:mm:ss";
        return dateFormat;
    }
public static void GetMenu(DropDownList ddlQuickJump, string sCaption) 
{
    ddlQuickJump.Items.Clear();
    ddlQuickJump.Items.Add(new ListItem("Back to menu", "menu.aspx"));
    ddlQuickJump.Items.Add(new ListItem("dbo.Institution_Programme_Courses", "Institution_Programme_Courses_list.aspx"));
    ddlQuickJump.Items.Add(new ListItem("dbo.Institution_Programme", "Institution_Programme_list.aspx"));
    if (ddlQuickJump.Items.FindByText(sCaption) == null ) 
    {
        ddlQuickJump.Items.Add(new ListItem("", ""));
        ddlQuickJump.Items.FindByText("").Selected = true;
    } 
    else ddlQuickJump.Items.FindByText(sCaption).Selected = true;
}
public static DbDataReader GetSqlDataSource(string sSQLSelect)
{
    QueryCommand cmd = new QueryCommand(sSQLSelect);
    
    DbDataReader reader = (DbDataReader)DataService.GetReader(cmd);
    return reader;
}

public static string BuildParameterName(string sFieldName)
{
    string sReturn = "";
    for (int i = 0; i < sFieldName.Length; ++i)
    {
        if (sFieldName[i] == '[' || sFieldName[i] == ']') continue;
        if ((sFieldName[i] >= 'A' && sFieldName[i] <= 'Z') ||
             (sFieldName[i] >= 'a' && sFieldName[i] <= 'z') ||
             (sFieldName[i] >= '0' && sFieldName[i] <= '9') ||
              sFieldName[i] == '_')
            sReturn += sFieldName[i];
        else
            sReturn += "_";
    }
    return sReturn;
}

public static string SqlBuilder(string sSQL, string sAddString)
{
    if (sAddString == string.Empty) return sSQL.Trim();

    int iPos = sSQL.ToLower().IndexOf(" where ");
    if (iPos < 0)
    {
        sAddString = " where " + sAddString + " ";
        int groupByPos = sSQL.ToLower().IndexOf(" group by ");
        if (groupByPos > 0)
        {
            sSQL = sSQL.Insert(groupByPos, sAddString);
        }
        else
        {
            int orderByPos = sSQL.ToLower().IndexOf(" order by ");
            if (orderByPos < 0)
                sSQL += sAddString;
            else
                sSQL = sSQL.Insert(orderByPos, sAddString);
        }
    }
    else
    {
        iPos += 7;
        if (sSQL.Length > iPos) sAddString += " And ";
        sSQL = sSQL.Insert(iPos, sAddString);
    }

    return sSQL.Trim();
}

public static string WhereBuilder(string sWhere, string sAdd)
{
    return WhereBuilder(sWhere, sAdd, "And");
}
public static string WhereBuilder(string sWhere, string sAdd, string sLogicalOperator)
{
    if (sAdd == string.Empty) return sWhere.Trim();
    if (sWhere == string.Empty) return sAdd;
    string sReturn = "";    
    if (sWhere.Trim().EndsWith(sLogicalOperator, StringComparison.OrdinalIgnoreCase))
        sReturn = sWhere.Trim() + " " + sAdd;
    else
        sReturn = sWhere.Trim() + " " + sLogicalOperator + " " + sAdd;
    return sReturn;        
}

public static void AddGlyph(GridView grid, GridViewRow item)
{
    Label glyph = new Label();
    glyph.Text = "&nbsp" + (grid.SortDirection == SortDirection.Ascending? "<IMG src=\"Images/down.gif\" border=0/>": "<IMG src=\"Images/up.gif\" border=0/>");

    for(int i=0;i<grid.Columns.Count;i++)
    {
        string colExpr = grid.Columns[i].SortExpression;
        if (colExpr != String.Empty && colExpr == grid.SortExpression) item.Cells[i].Controls.Add(glyph);
    if (item.Cells[i].Controls.Count > 0 && item.Cells[i].Controls[0] is LinkButton)
      ((LinkButton)(item.Cells[i].Controls[0])).CssClass = grid.HeaderStyle.CssClass;
        else item.Cells[i].CssClass = grid.HeaderStyle.CssClass;
    }
}

  //Date as ddl
public static void DateToDropDownList( DateTime dt, ref System.Web.UI.WebControls.DropDownList ddlDay, ref System.Web.UI.WebControls.DropDownList ddlMonth, ref System.Web.UI.WebControls.DropDownList ddlYear)
{
  for (int i = (dt.Year == 1?DateTime.Now.Year:dt.Year) - 50 ; i <= (dt.Year == 1?DateTime.Now.Year:dt.Year) + 50; i++)
    ddlYear.Items.Add(new System.Web.UI.WebControls.ListItem(i.ToString(), i.ToString()));

  if ( dt == DateTime.MinValue ) return;

  ddlDay.SelectedValue = dt.Day.ToString();
  ddlMonth.SelectedValue = dt.Month.ToString();
  ddlYear.SelectedValue = System.Convert.ToString(dt.Year == 1?DateTime.Now.Year:dt.Year);
}

public static string DropDownListToDate(ref System.Web.UI.WebControls.DropDownList ddlDay, ref System.Web.UI.WebControls.DropDownList ddlMonth, ref System.Web.UI.WebControls.DropDownList ddlYear) 
{
  string sDayRequiredDate, sMonthdtRequiredDate, sYeardtRequiredDate;

  sDayRequiredDate = ddlDay.SelectedValue;
  sMonthdtRequiredDate = ddlMonth.SelectedValue;
  sYeardtRequiredDate = ddlYear.SelectedValue;

  if ( sDayRequiredDate == "" && sMonthdtRequiredDate == "" && sYeardtRequiredDate == "" ) return null;
  else if ( sDayRequiredDate == "" || sMonthdtRequiredDate == "" || sYeardtRequiredDate == "" ) 
      throw new System.Exception("Invalid Datetime format");

  if ( sDayRequiredDate.Length < 2 ) sDayRequiredDate = "0" + sDayRequiredDate;
  if ( sMonthdtRequiredDate.Length < 2 ) sMonthdtRequiredDate = "0" + sMonthdtRequiredDate;

//return System.Xml.XmlConvert.ToDateTime(sDayRequiredDate + "/" + sMonthdtRequiredDate + "/" + sYeardtRequiredDate, "dd/MM/yyyy");
  return string.Format("{0}-{1}-{2}", sYeardtRequiredDate, sMonthdtRequiredDate, sDayRequiredDate);      
}

  //lookup column as ddl
public  static void LoadDataToLookUp(ref DropDownList ddlLookUp,  string  sSQLSelect,  string  sCurrentValue) 
{
    ddlLookUp.Items.Clear();
	ddlLookUp.Items.Insert(0, "");
	
    ddlLookUp.DataSource = GetSqlDataSource(sSQLSelect);
    ddlLookUp.DataBind();
    
    ddlLookUp.SelectedValue = null;    
    if (ddlLookUp.Items.FindByValue(sCurrentValue) != null) ddlLookUp.SelectedValue = sCurrentValue;
    else ddlLookUp.SelectedIndex = 0;
}

//lookup column as rbl
public  static void LoadDataToLookUp(ref System.Web.UI.WebControls.RadioButtonList ddlLookUp,  string  sSQLSelect,  string  sCurrentValue) 
{
    ddlLookUp.Items.Clear();
	ddlLookUp.Items.Insert(0, "");
	
    ddlLookUp.DataSource = GetSqlDataSource(sSQLSelect);
    ddlLookUp.DataBind();
    
    ddlLookUp.SelectedValue = null;    
    if (ddlLookUp.Items.FindByValue(sCurrentValue) != null) ddlLookUp.SelectedValue = sCurrentValue;
    else ddlLookUp.SelectedIndex = 0;
}

public  static void LoadDataToLookUp(ref System.Web.UI.WebControls.ListBox ddlLookUp,  string  sSQLSelect,  string  sCurrentValue) 
{
    ddlLookUp.Items.Clear();
	ddlLookUp.Items.Insert(0, "");
	
    ddlLookUp.DataSource = GetSqlDataSource(sSQLSelect);
    ddlLookUp.DataBind();
    
    ddlLookUp.SelectedValue = null;    
    foreach (string s in sCurrentValue.Split(','))
    {
        if ( ddlLookUp.Items.FindByValue(s) != null ) ddlLookUp.Items.FindByValue(s).Selected = true;
    }
    if (String.IsNullOrEmpty(ddlLookUp.SelectedValue)) ddlLookUp.SelectedIndex = 0;    
}

public static string  GetLookupValue( string  sDisplayField,  string  sLinkField,  string  sTable,  string  sValue,  TypeCode TType)
{
    return GetLookupValue(sDisplayField, sLinkField, sTable, sValue, TType, false);
}
public static string  GetLookupValue( string  sDisplayField,  string  sLinkField,  string  sTable,  string  sValue,  TypeCode TType, bool isMultiline)
{
    string sGetLookupValue = "";
    
    string sqlSelect = "SELECT " + sDisplayField + " FROM " + sTable + " WHERE ";
    try
    {
        QueryCommand cmd = new QueryCommand(sqlSelect);
        if (isMultiline)
        {
            int i = 0;
            foreach (string s in sValue.Split(','))
            {
                string paramName = "param" + i.ToString();
                cmd.CommandSql += sLinkField + "=@" + paramName + " Or ";
                cmd.AddParameter(paramName, s);
                i += 1;
            }
           if (cmd.CommandSql.Length > 2) cmd.CommandSql = cmd.CommandSql.Remove(cmd.CommandSql.Length - 3);
        }
        else
        {
            cmd.CommandSql += sLinkField + "= @LinkField";
            cmd.AddParameter("LinkField", sValue);
        }
        
        System.Data.Common.DbDataReader dbDr = (System.Data.Common.DbDataReader)DataService.GetReader(cmd);
        if (dbDr.HasRows) 
        {
            if (isMultiline)
            {
                while (dbDr.Read()) {sGetLookupValue += dbDr[0].ToString() + ","; }               
                sGetLookupValue = sGetLookupValue.Trim(",".ToCharArray());
            }
            else if (dbDr.Read()) sGetLookupValue = dbDr[0].ToString();
        }    
    dbDr.Dispose();
    }    
    finally
    {
    }
    return sGetLookupValue;
}

//Upload binary file
public static object GetBinary(ref FileUpload _InputFile) 
{
  if (_InputFile.PostedFile != null )
  {
    int iImageSize = _InputFile.PostedFile.ContentLength;
        if ( iImageSize == 0 ) throw new System.Exception(" File '" + _InputFile.PostedFile.FileName + "' not found<br>");
        
    System.IO.Stream ImageStream = _InputFile.PostedFile.InputStream;
        byte[] ImageContent = new byte[iImageSize];
        ImageStream.Read(ImageContent, 0, iImageSize);
        return ImageContent;
  }
  else return DBNull.Value;
}

public static void DeleteFile( string  sFileName) 
{
  System.IO.FileInfo fiDescription = new System.IO.FileInfo(sFileName);
    if ( fiDescription.Exists ) fiDescription.Delete();
}    
 
public static string  GetNavigateUrl( string  sValue,  string  sLinkType) 
{
  return (sValue.StartsWith(sLinkType)?sValue:sLinkType + sValue);
}

public static string ProcessLargeText( string  sValue,  int iNumberOfChars, string tableName, string param) 
{
    string sProcessLargeText = "";
    if ( sValue.TrimStart().StartsWith("<a href")  || sValue == "" || sValue == "&nbsp;" ) return sValue;
    if ( iNumberOfChars > 0 ) 
    {
        if ( sValue.Length > iNumberOfChars && !sValue.TrimStart().StartsWith("<a href") ) 
        {
                sProcessLargeText = sValue.Substring(0, iNumberOfChars).Replace("'","\'")
                + " <a href=\"#\" onClick=\"javascript: pwin = window.open('',null,'height=300,width=400,status=yes,resizable=yes,toolbar=no,menubar=no,location=no,left=150,top=200,scrollbars=yes'); "
                + "pwin.location='" + tableName + "_fulltext.aspx?" + HttpUtility.HtmlEncode(param) + "';"
                + "return false;\">" + "More" + "&nbsp;...</a>";
        }
    }
    return sProcessLargeText; 
}

public static void SendMail( string  mailTo,  string  subj,  string  body) 
{
    string mailSender = ConfigurationManager.AppSettings["MailSender"];
    string mailSmtpServer = ConfigurationManager.AppSettings["MailSmtpServer"];
    string mailSmtpPort = ConfigurationManager.AppSettings["MailSmtpPort"];
    string mailSMTPUser = ConfigurationManager.AppSettings["MailSMTPUser"];
    string mailSMTPPassword = ConfigurationManager.AppSettings["MailSMTPPassword"];

    if (string.IsNullOrEmpty(mailSender) || string.IsNullOrEmpty(mailTo)) return;
    MailMessage mail = new MailMessage(mailSender, mailTo, subj, body);

    //send the message
    SmtpClient smtp = new SmtpClient(mailSmtpServer);
    smtp.Port = Convert.ToInt32(mailSmtpPort);

    if (mailSMTPUser != null && mailSMTPUser != "")
    {
        //to authenticate we set the username and password properites on the SmtpClient
        smtp.Credentials = new System.Net.NetworkCredential(mailSMTPUser, mailSMTPPassword);
    }
    smtp.Send(mail);
}

public static bool IsDate(object dt)
{
  try
    {
        System.DateTime.Parse(dt.ToString());
        return true;
      }
      catch
      {
        return false;
      }
}
public static bool IsNumeric(object oValue)
{
  try
    {
        double.Parse(oValue.ToString());
        return true;
      }
      catch
      {
        return false;
      }
}
        public static IDataReader FetchReaderForAddNewItem(string sLinkField, string sDisplayField, string sTable, string value)
    {
        string sSQL = "select  [" + sLinkField + "], [" + sDisplayField + "] from " + sTable + " where [" + sDisplayField + "] = @Value";
        QueryCommand cmd = new QueryCommand(sSQL);
        cmd.AddParameter("Value", value, DbType.String);
        return DataService.GetReader(cmd);
    }

    public static void InsertNewItem(string sDisplayField, string sTable, string value)
    {
        string sSQL = "insert into " + sTable + " ([" + sDisplayField + "]) values (@Value)";
        QueryCommand cmd = new QueryCommand(sSQL);
        cmd.AddParameter("Value", value, DbType.String);
        DataService.ExecuteScalar(cmd);
    }

    public static DataSet FetchReaderForFile(string sFileName, string sDataFieldName, string sTableName, string sKeyFields)
    {
        string sql = "select " + (sFileName == String.Empty ? "" : "[" + sFileName + "],") + "[" + sDataFieldName + "] from " + sTableName + " where 2=2 ";
        QueryCommand cmd = new QueryCommand(sql);
        foreach (string s in sKeyFields.Split(";".ToCharArray()))
        {
            if (s.Split('=').Length != 2) continue;
            string sFieldName = s.Split('=')[0];
            cmd.CommandSql += " And [" + sFieldName + "]=@" + func.BuildParameterName(sFieldName);
            cmd.AddParameter(func.BuildParameterName(sFieldName), s.Split('=')[1]);
        }

                return DataService.GetDataSet(cmd);
    }
    public static DataSet FetchReaderForImage(string sImgFieldName, string sTableName, string sKeyFields)
    {
        string sql = "select [" + sImgFieldName + "] from " + sTableName + " where 2=2 ";
        QueryCommand cmd = new QueryCommand(sql);
                foreach (string s in sKeyFields.Split(";".ToCharArray()))
        {
            if (s.Split('=').Length != 2) continue;
            string sFieldName = s.Split('=')[0];
            cmd.CommandSql += " And [" + sFieldName + "]=@" + func.BuildParameterName(sFieldName);
            cmd.AddParameter(func.BuildParameterName(sFieldName), s.Split('=')[1]);
        }

        return DataService.GetDataSet(cmd);
    }
}//class func
public class UserClass {

    private Guid _id;
    private string  _userName;
    private string  _password;


public Guid ID
{
    get {return _id;}
    set {_id = value;}
}

public string  UserName
{
  get {return _userName;}
    set {_userName = value;}
}

public string Password
{
  get {return _password;}
  set {_password = value;}
}

public UserClass Login( string  txtUser,  string  txtPassword)
{
    
    UserClass  UserLogin = new UserClass();

    string  sLoginFrom = ConfigurationManager.AppSettings["LoginFrom"];
    if ( sLoginFrom == "DB" ) 
    { // User Name and Password from DB
        string  sTable = ConfigurationManager.AppSettings["UserListTable"];
        string  sLogin = ConfigurationManager.AppSettings["FieldUserLogin"];
        string  sLoginType = ConfigurationManager.AppSettings["FieldUserLoginType"];
        string  sPwd = ConfigurationManager.AppSettings["FieldUserPwd"];
        string  sPwdType = ConfigurationManager.AppSettings["FieldUserPwdType"];
    
        if ( sTable == "" || sLogin == "" || sPwd == "" )  return null;   
        string sSQL = "select [" + sLogin + "],[" + sPwd +"]";
    sSQL += " from " + sTable + " where [" + sLogin + "] = @Login and [" + sPwd + "] = @Password ";

        QueryCommand query = new QueryCommand(sSQL);
        
        try
        {
            query.AddParameter("Login", txtUser);
            query.AddParameter("Password", txtPassword);

            DbDataReader dbDr = (DbDataReader) DataService.GetReader(query);
            
            if (dbDr.HasRows && dbDr.Read())
            {
                if ( dbDr[sLogin].ToString() == txtUser && dbDr[sPwd].ToString() == txtPassword ) 
                {
                    UserLogin.ID = Guid.NewGuid();
                }
            }
            dbDr.Dispose();
        }
        finally
        {
        }
    }        
    else 
    { // hardcoded
        if ( txtUser == ConfigurationManager.AppSettings["UserLogin"] && txtPassword == ConfigurationManager.AppSettings["UserPassword"] ) 
            UserLogin.ID = Guid.NewGuid();
    }
            

  if ( UserLogin.ID == Guid.Empty ) return null;
  else 
  {
    UserLogin.UserName = txtUser;
    return UserLogin;
  }

}

public static void CheckLogin( System.Web.UI.Page Page) 
{
    if ( string.IsNullOrEmpty(ConfigurationManager.AppSettings["LoginMethod"]) || (ConfigurationManager.AppSettings["LoginMethod"]).ToUpper()  == "WITHOUTLOGIN" ) return;
//    Page.Response.CacheControl = "no-cache";
//    Page.Response.AddHeader("Pragma", "no-cache");
//    Page.Response.Expires = -1;
    if ( Page.Session["User"] == null ) Page.Response.Redirect(ConfigurationManager.AppSettings["LoginFile"] + "?url=" + Page.Request.RawUrl);
    if ( ((UserClass)Page.Session["User"]).ID == Guid.Empty) Page.Response.Redirect(ConfigurationManager.AppSettings["LoginFile"] + "?url=" + Page.Request.RawUrl);
}
    }
