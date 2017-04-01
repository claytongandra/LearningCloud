using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LearningCloud.MVC.Areas.Admin.Controllers
{
    public static class UploadVideoaula
    {
        public static string UploadFileVideoaula(HttpPostedFileBase file)
        {
            string FilesPath = HttpContext.Current.Server.MapPath("~\\Content\\Images\\teste\\");


            // Check if we have a file
            if (null == file) return "";
            // Make sure the file has content
            if (!(file.ContentLength > 0)) return "";

            string fileName = DateTime.Now.Millisecond + file.FileName;
            string fileExt = Path.GetExtension(file.FileName);

            // Make sure we were able to determine a proper extension
            if (null == fileExt) return "";


            // Check if the directory we are saving to exists
            if (!Directory.Exists(FilesPath))
            {
                // If it doesn't exist, create the directory
                Directory.CreateDirectory(FilesPath);
            }

            // Set our full path for saving
            string path = FilesPath + fileName;

            // Save our file
            file.SaveAs(Path.GetFullPath(path));

            // Save our thumbnail as well
            //           ResizeImageUsuarioFotoPerfil(file, 70, 70);

            // Return the filename

            return fileName;
        }
    }
}