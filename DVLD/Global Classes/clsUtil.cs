using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Global_Classes
{
    public class clsUtil
    {
        public static string GenerateGUID()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }


        public static bool CreateFolderIfDoesNotExist(string FilePath)
        {
            if (!Directory.Exists(FilePath))
            {

            }

            try
            {
                Directory.CreateDirectory(FilePath);
                return true;

            }

              catch (Exception ex)
                {
                MessageBox.Show("Error creating folder: " + ex.Message);
                return false;
            }

        }


        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            //??
            string FileName= sourceFile;
            FileInfo FileInfo= new FileInfo(FileName);
            string Extn= FileInfo.Extension;
            return GenerateGUID () + Extn;


            //FileInfo FileInfo = new FileInfo(sourceFile);
            //string Extn = FileInfo.Extension;
            //return GenerateGUID() + Extn;


        }


        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            string DestinationFolder = @"C:\DVLD-People-Images\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);

            try
            {
                File.Copy(sourceFile, destinationFile,true);
            }

            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            sourceFile = destinationFile;
            return true;
        }

    }
}
