using System;
using System.IO;
using System.Reflection;

namespace SMCore
{
    public static class Log
    {
        public static string WriteLog(string logText)
        {
            string currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string logName = @"\log_" + DateTime.Now.ToShortDateString() + ".txt";
            string logPath = currentPath + logName;

            if (!File.Exists(logPath))
                File.Create(logPath).Close();
            try
            {
                using (StreamWriter writer = new StreamWriter(logPath, true))
                    writer.WriteLine(DateTime.Now.ToString() + " | " + logText);
            }
            catch (Exception e)
            {
                return e.ToString();
            }

            return "";
        }
    }
}
