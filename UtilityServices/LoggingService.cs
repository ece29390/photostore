using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace PhotoStore.UtilityServices
{
    public class LoggingService
    {
       
        public static  void LogFailureTask(string path, string message)
        {
            FileMode mode = FileMode.Create;
            if (File.Exists(path))
                mode = FileMode.Append;

            using (FileStream fs = new FileStream(
                path, mode))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(message);
                    sw.Close();
                }
                fs.Close();
            }
        }
    }
}
