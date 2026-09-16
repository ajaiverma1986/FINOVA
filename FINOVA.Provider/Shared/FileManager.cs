using FINOVA.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.Provider.Shared
{
    public class FileManager
    {
        public string SaveFile(Byte[] filestream, string MobileNo = "", string FileName = "")
        {

            string FolderPath = FINOVAApplicationConfiguration.Instance.FileUploadPath + "\\PartnerDocument\\" + MobileNo.ToString();
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);
            string Filename = MobileNo.ToString() + "_Logo" + Path.GetExtension(FileName);
            MemoryStream ms = new MemoryStream(filestream);
            FileStream file = new FileStream(FolderPath + "\\" + Filename, FileMode.Create, FileAccess.Write);

            ms.WriteTo(file);
            file.Close();
            ms.Close();
            return Filename;
        }
        public string SaveKYCDocument(Byte[] filestream, string UserID = "", string FileName = "", string FullFileName = "")
        {

            string FolderPath = FINOVAApplicationConfiguration.Instance.FileUploadPath + "\\PartnerDocument\\" + UserID.ToString();
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);
            string Filename = FullFileName + Path.GetExtension(FileName);
            MemoryStream ms = new MemoryStream(filestream);
            FileStream file = new FileStream(FolderPath + "\\" + Filename, FileMode.Create, FileAccess.Write);

            ms.WriteTo(file);
            file.Close();
            ms.Close();
            return Filename;
        }
        public string SaveOtherDocument(Byte[] filestream, string FolderName = "", string filename = "", string fullFilename = "", string filevalue = "")
        {

            string FolderPath = FINOVAApplicationConfiguration.Instance.FileUploadPath + "\\" + FolderName + "\\";
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);
            string newFilename = fullFilename + "_" + filevalue + Path.GetExtension(filename);
            MemoryStream ms = new MemoryStream(filestream);
            FileStream file = new FileStream(FolderPath + "\\" + newFilename, FileMode.Create, FileAccess.Write);

            ms.WriteTo(file);
            file.Close();
            ms.Close();
            return newFilename;
        }


        public Byte[] ReadFile(string fileName, string MainFolder, string DocumentFolderName)
        {
            string FolderPath = "";
            FolderPath = FINOVAApplicationConfiguration.Instance.FileDownloadPath + "\\" + MainFolder + "\\" + DocumentFolderName.ToString();

            string FileToRead = FolderPath + "\\" + fileName;
            if (File.Exists(FileToRead))
            {
                FileStream fs = new FileStream(FileToRead, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                Int64 numBytes = new FileInfo(FileToRead).Length;
                return br.ReadBytes((Int32)numBytes);
            }

            return null;
        }
        public Byte[] ReadFileOther(string fileName, string MainFolder)
        {
            string FolderPath = "";
            FolderPath = FINOVAApplicationConfiguration.Instance.FileDownloadPath + "\\" + MainFolder.ToString();

            string FileToRead = FolderPath + "\\" + fileName;
            if (File.Exists(FileToRead))
            {
                FileStream fs = new FileStream(FileToRead, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                Int64 numBytes = new FileInfo(FileToRead).Length;
                return br.ReadBytes((Int32)numBytes);
            }

            return null;
        }
    }
}
