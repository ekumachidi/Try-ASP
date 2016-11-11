 
#region " using "
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections;
using System.IO;
using System.Web.UI.WebControls;
#endregion

public partial class GetFile : System.Web.UI.Page
{

private void Page_Load( object sender,  System.EventArgs e)
{
    UserClass.CheckLogin(Page);

    string  sKeyFields = Request.QueryString["key"];
    string  sTableName = Request.QueryString["table"];
    string  sDataFieldName = Request.QueryString["field"];
    string  sFileName = Request.QueryString["filename"];

    if ( sKeyFields == null ) fGetFile(sFileName);
    else GetFileFromDB(sKeyFields, sTableName, sFileName, sDataFieldName);
}

private void fGetFile( string  sFileName) 
{
        if ( sFileName == "" ) return;
        try 
    {
            FileStream fStream = new FileStream(Server.MapPath(sFileName), FileMode.OpenOrCreate, FileAccess.Read);
            byte[] b = new byte[fStream.Length];
            while ((fStream.Read(b, 0, (int)fStream.Length) > 0));
            fStream.Close();
            DownloadFile(b, sFileName);
        }
    catch (Exception ex)
          {  Response.Write(ex.Message); }
}

private void GetFileFromDB( string  sKeyFields,  string  sTableName,  string  sFileName,  string  sDataFieldName) 
{
    if ( sKeyFields == "" || sTableName == "" || sFileName == "" ) return;

    string  sSQLSelect = "select " + (sFileName == String .Empty?"":"[" + sFileName+ "],") + "[" + sDataFieldName  + "] from " + sTableName + " where 2=2 ";
    
    ConnectionStringSettings cts = ConfigurationManager.ConnectionStrings["Project1ConnectionString"];
    SqlDataSource sds = new SqlDataSource();
    try
    {
        sds.ConnectionString = cts.ConnectionString;
        sds.ProviderName = cts.ProviderName;
        sds.DataSourceMode = SqlDataSourceMode.DataReader;
        sds.SelectCommand = sSQLSelect;

        foreach(string s in sKeyFields.Split(";".ToCharArray()))
        {
            if(s.Split('=').Length != 2) continue;
            string sFieldName = s.Split('=')[0];
            sds.SelectCommand +=  " And [" + sFieldName + "]=@"+func.BuildParameterName(sFieldName);
            
            sds.SelectParameters.Add(func.BuildParameterName(sFieldName), s.Split('=')[1]);
        }

        IEnumerable IDs = sds.Select(System.Web.UI.DataSourceSelectArguments.Empty);
        foreach (System.Data.Common.DbDataRecord row in IDs)
        {
            if (row[sDataFieldName] == DBNull.Value  ) return;
            if (sFileName != String .Empty && row[sFileName] != DBNull.Value ) sFileName =  Convert.ToString(row[sFileName]);
            else sFileName = "file.bin";
            
            byte[] b = (byte[])row[sDataFieldName];            
            DownloadFile(b, sFileName);
            break;
        }
    }
    catch (Exception ex)
    {
           Response.Write(ex.Message);
    }
    finally
    {
        sds.Dispose();
    }
}

private void DownloadFile(byte[] b,  string  sFileName) 
{
    if ( b.Length == 0 ) return;
    string sContentType = "application/octet-stream";
    switch (sFileName.Remove(0, sFileName.Length-4))
    {
        case ".asf":
            sContentType = "video/x-ms-asf";
      break;
        case ".avi":
            sContentType = "video/avi";
      break;
        case ".doc":
            sContentType = "application/msword";
      break;
        case ".zip":
            sContentType = "application/zip";
      break;
        case ".xls":
            sContentType = "application/vnd.ms-excel";
      break;
        case ".gif":
            sContentType = "image/gif";
      break;
        case ".jpg":
        case "jpeg":
            sContentType = "image/jpeg";
      break;
        case ".wav":
            sContentType = "audio/wav";
      break;
        case ".mp3":
            sContentType = "audio/mpeg3";
      break;
        case ".mpg":
        case "mpeg":
            sContentType = "video/mpeg";
            break;
        case ".rtf":
            sContentType = "application/rtf";
            break;
        case ".htm":
        case "html":
            sContentType = "text/html";
            break;
        case ".asp":
            sContentType = "text/asp";
            break;
        case ".pdf":
            ContentType = "application/pdf";
            break;
    }

    Response.AddHeader("Content-Disposition", "attachment;Filename=" + sFileName.Remove(0, sFileName.LastIndexOfAny("\\/".ToCharArray()) + 1));
    Response.AddHeader("Content-Length", b.Length.ToString());
    Response.ContentType = sContentType;
    Response.BinaryWrite(b);
    Response.End();
}
  
}
