using System;
using System.Collections.Generic;
using System.IO;

namespace Crypto.UTIL
{
    static class FileLogger
    {
        private const string LogName = "logs.log";
        private const string PassFile = "text.txet";

        public static void WriteTo(string? logmessage, List<Password>? passwords, bool log = true)
        {
            string writeMsg = "";
            if (log)
            {
                writeMsg = $"{DateTime.Now} {logmessage} \n";
                File.AppendAllTextAsync(LogName, writeMsg);
            }
            else
            {
                File.WriteAllText(PassFile, writeMsg);
                foreach (var pw in passwords)
                {
                    writeMsg = $"{pw.hint}\t{pw.password}\n";
                    File.AppendAllTextAsync(PassFile,writeMsg);
                }
            }
        }

        public static string[] ReadFrom(bool log = true)
        {
            DirectoryInfo findFile = new(Environment.CurrentDirectory);

            foreach (FileInfo filer in findFile.GetFiles())
            {
                if (log)
                {
                    if (filer.Extension == ".log")
                    {
                        return File.ReadAllLines(filer.FullName);
                    }
                }
                else
                {
                    if (filer.Extension == ".txet")
                    {
                        return File.ReadAllLines(filer.FullName);
                    }
                }
            }
            return null;
        }
    }
}