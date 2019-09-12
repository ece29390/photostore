using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace PhotoStore.UtilityServices
{
    public class UpdateAppService
    {
        public static void UpdateApplication(
            string exePath,string sourcePath, string destinationPath)
        {
            
            string originalDestination = destinationPath;
            string tempFolder = string.Concat("Temp", DateTime.Now.ToString("MMddyyyyhhmmss"));
            destinationPath = string.Concat(destinationPath,@"\", tempFolder);
            DirectoryInfo destinationInfo = new DirectoryInfo(destinationPath);
            if (!destinationInfo.Exists)
            {
                destinationInfo.Create();
            }
            
            using (Process process = new Process())
            {
                process.StartInfo.FileName = exePath;
                process.StartInfo.Arguments = string.Format(
                    "-o \"{0}\" -d \"{1}\" ",
                    sourcePath, destinationPath);
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.Verb = "Open";
                process.Start();
                process.WaitForExit();
            }
            //some of the settings in winzip creates another root directory
            DirectoryInfo[] extraDirectoryCreated = destinationInfo.GetDirectories();//Directory.GetDirectories(destinationPath);
            FileInfo[] updateFiles;
            bool isExtraFolder=false;
            if (extraDirectoryCreated.Length > 0)
            {
                updateFiles = extraDirectoryCreated[0].GetFiles("*.*");//Directory.GetFiles(extraDirectoryCreated[0], "*.*");
              isExtraFolder=true;
            }
            else
            {
                updateFiles = destinationInfo.GetFiles("*.*");//Directory.GetFiles(destinationPath,"*.*");
            }

            CopyUpdateFiles(updateFiles, originalDestination, isExtraFolder);
            destinationInfo.Delete(true);
            
        }
        public static void CopyUpdateFiles(string[] updateFiles,string destinationPath,bool isExtraFolder)
        {
            FileInfo fiInfo;
            foreach (string updateFile in updateFiles)
            {
                fiInfo = new FileInfo(updateFile);
                File.Copy(updateFile
                    , string.Concat(destinationPath, @"\", fiInfo.Name),true);
                File.Delete(updateFile);
                fiInfo = null;
            }
            if (isExtraFolder)
            {
                Directory.Delete(
                    Directory.GetParent(updateFiles[0]).FullName);
            }
        }
        public static void CopyUpdateFiles(FileInfo[] updateFiles, string destinationPath, bool isExtraFolder)
        {
            //FileInfo fiInfo;
            foreach (FileInfo updateFile in updateFiles)
            {
                //fiInfo = new FileInfo(updateFile);
                updateFile.CopyTo(string.Concat(destinationPath, @"\", updateFile.Name), true);
                //File.Copy(updateFile
                //    , string.Concat(destinationPath, @"\", fiInfo.Name), true);
                updateFile.Delete();
                //File.Delete(updateFile);
                //fiInfo = null;
            }
            if (isExtraFolder)
            {
                DirectoryInfo dirInfo=Directory.GetParent(updateFiles[0].FullName);
                dirInfo.Delete(true);
               
            }
        }
        public static void BackUpApplication(
            string exePath, string sourcePath, string destinationPath)
        {
            
            using (Process process = new Process())
            {
                process.StartInfo.FileName = exePath;
                process.StartInfo.Arguments = string.Format(
                    "-r \"{0}\" \"{1}\" ",
                   sourcePath, destinationPath);
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.Verb = "Open";
                process.Start();
                process.WaitForExit();
            }
        }
    }
}
