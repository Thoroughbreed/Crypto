using System;
using System.IO;

namespace Crypto.UTIL
{
    static class FileLogger
    {
        static string logName = "logs.log";

        public static void WriteToLog(string logmessage)
        {
            string writeMsg = $"{DateTime.Now} {logmessage} \n";
            File.AppendAllTextAsync(logName, writeMsg);
        }

        public static string ReadFromLog()
        {
            DirectoryInfo findLog = new DirectoryInfo(Environment.CurrentDirectory);
            foreach (FileInfo filer in findLog.GetFiles())
            {
                if (filer.Extension == ".log")
                {
                    return File.ReadAllText(filer.FullName);
                }
            }
            return "No log found??!!!";
        }
    }
}