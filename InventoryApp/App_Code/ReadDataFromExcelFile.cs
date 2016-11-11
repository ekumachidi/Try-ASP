using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Excel;
using System.IO;


/// <summary>
/// Summary description for ReadDataFromExcelFile
/// </summary>
public class ReadDataFromExcelFile
{
    private static string imagePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

	public ReadDataFromExcelFile()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static DataSet ReadExcelFile(string filePath)
    {
        System.Web.UI.WebControls.DropDownList ddlList = new System.Web.UI.WebControls.DropDownList();
        ddlList.Items.Clear();
        ddlList.Items.Add(filePath);
        FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader;
        string[] myFile = filePath.Split('.');
        string myData = myFile[myFile.GetUpperBound(0)];

       
        DataSet result = null;
       
        //1. Reading from a binary Excel file ('97-2003 format; *.xls)
        if (myData.ToString().ToUpper() == "XLS")
        {
            excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            result = excelReader.AsDataSet();
            excelReader.IsFirstRowAsColumnNames = true;
            excelReader.Close();
        }
        else if (myData.ToString().ToUpper() == "XLSx")
        {
       
          //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
             excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            result = excelReader.AsDataSet();
            excelReader.IsFirstRowAsColumnNames = true;
            excelReader.Close();
        }

        return result;
     
    }



    public static DataSet UploadExcelFile(System.Web.UI.WebControls.FileUpload fileupload)
    {
        DataSet Result = null;
        try
        {
            string passportFolder = "/Modules/ExcelProcessor/File";

            // Get the name of the file to upload.
            string fileName = fileupload.FileName;
            string passPortFolderPath = "~/" + passportFolder;

            //Append the name of the file to upload to the path.
            string passportFolderPath1 = @imagePath + passportFolder;
            string fullPath = passPortFolderPath + "/" + fileName;

            //get the file extension
            FileInfo fi = new FileInfo(fullPath);
            string fileExtension = fi.Extension;

            //update file name and file path
            string jambRegNo = "UPLOAD";
            string matricNo = jambRegNo.Replace("/", "-").Replace(@"\", "-") + "-" + DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "");
            fileName = matricNo + fileExtension;
            fullPath = passPortFolderPath + "/" + fileName;

            //if folder does not already exist then create folder
            if (!Directory.Exists(passportFolderPath1))
            {
                Directory.CreateDirectory(passportFolderPath1);
            }

            if (fileupload.HasFile)
            {
                //check the selected file format
                if (fileExtension != ".xls" && fileExtension != ".XLSX" && fileExtension != ".xlsx" && fileExtension != ".XLSX")
                {
                    throw new Exception("This is not an excel file");
                    return null;
                }


                //Call the SaveAs method to save the 
                //uploaded file to the specified path and
                //display the uploaded image
                fileupload.SaveAs(passportFolderPath1 + @"\" + fileName);


                Result = ReadDataFromExcelFile.ReadExcelFile(passportFolderPath1 + @"\" + fileName);
            }
            else
            {

                throw new Exception("No Excel file is selected");
                return null;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Result;
    }




 
}