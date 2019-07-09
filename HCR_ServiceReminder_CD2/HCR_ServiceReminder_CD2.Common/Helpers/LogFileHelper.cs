using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCR_ServiceReminder_CD2.Common.Helpers
{
    public class LogFileHelper
    {
        private static readonly object _syncObject = new object();
        private static readonly object _syncObjectcsv = new object();
        public void WriteToFile(string message, string path, bool isdeletelog = false)
        {
            //ConfigurationManager.AppSettings["BatchFile"];
            //string runDate = DateTime.Now.ToString("yyyy-MM-dd");

            string runDate = DateTime.Now.ToString("yyyy_MM_dd");
            string dailyRunPath = path + @"\" + runDate;
            Directory.CreateDirectory(dailyRunPath);
            string fileName = ConfigurationManager.AppSettings["LogFileName"] + runDate + ".txt";

            string logFileFullPath = dailyRunPath + @"\" + fileName;

            //Delete log if already exists
            if (isdeletelog == true && File.Exists(logFileFullPath))
            {
                File.Delete(logFileFullPath);
            }

            lock (_syncObject)
            {

                using (StreamWriter writer = new StreamWriter(logFileFullPath, true))
                {
                    if (message.Equals(Environment.NewLine))
                    {
                        writer.WriteLine(message);
                    }
                    else
                        writer.WriteLine(message + "    ,Time:" + DateTime.Now);
                }
            }
        }
    }
}
