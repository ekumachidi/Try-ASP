using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for UploadFile
/// </summary>
public class UploadFile
{
    private static  string imagePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

	public UploadFile()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void  LoadFile(string filePath, string filename, FileUpload fuPassport, Image iPassport, Label lblPassport)
    {
        try
        {
            //Student Passport
            string passportFolder = filePath ;

            // Get the name of the file to upload.
            string fileName = fuPassport.FileName;
            string passPortFolderPath = "~/" + passportFolder;

            //Append the name of the file to upload to the path.
            string passportFolderPath1 = @imagePath + passportFolder;
            string fullPath = passPortFolderPath + "/" + fileName;

            //get the file extension
            FileInfo fi = new FileInfo(fullPath);
            string fileExtension = fi.Extension;

            //update file name and file path
            string jambRegNo = Convert.ToString(filename);
            string matricNo = jambRegNo.Replace("/", "-").Replace(@"\", "-") + "-" + DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "");
            fileName = matricNo + fileExtension;
            fullPath = passPortFolderPath + "/" + fileName;

            //if folder does not already exist then create folder
            if (!Directory.Exists(passportFolderPath1))
            {
                Directory.CreateDirectory(passportFolderPath1);
            }

            // Before attempting to perform operations
            // on the file, verify that the FileUpload 
            // control contains a file.
            if (fuPassport.HasFile)
            {

                

                //check the selected file format
                if (fileExtension != ".jpg" && fileExtension != ".JPG" && fileExtension != ".jpeg" && fileExtension != ".JPEG" && fileExtension != ".gif" && fileExtension != ".GIF" && fileExtension != ".bmp" && fileExtension != ".BMP")
                {
                    throw new Exception ("The passport file format must be in either .gif, .jpeg, .jpg or .bmp file format!\\nPlease change the file format to the accepted file format");
                    return ;
                }


                //uploaded file to the specified path and
                //display the uploaded image
                fuPassport.SaveAs(passportFolderPath1 + @"\" + fileName);
                
                if (!IsValidImage(HttpContext.Current.Server.MapPath(fullPath)))
                {
                    System.IO.File.Delete(HttpContext.Current.Server.MapPath(fullPath));
                    throw new Exception("The file is not acceptable.");
                    return ;
                }

                //save passport full part in session and display the uploaded image
                iPassport.ImageUrl = fullPath;

                lblPassport.Text = fullPath; ;

                return ;

            }
            else
            {
                throw new Exception( "No passport file selected! Please click the browse button and select a passport file from file dialog box");
            }
        }
        catch (Exception ex)
        {
           throw new Exception ( "Error occurred! " + ex.Message + " Please contact your system administrator");
        }

        return ;
    }

   static  bool IsValidImage(string filename)
    {
        try
        {
            System.Drawing.Image newImage = System.Drawing.Image.FromFile(filename);
        }
        catch (OutOfMemoryException ex)
        {

            return false;
        }
        return true;
    }

}