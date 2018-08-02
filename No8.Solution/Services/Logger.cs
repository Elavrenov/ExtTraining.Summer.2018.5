using System;
using System.IO;
using System.Text;

namespace No8.Solution.Services
{
    public static class Logger
    {
        private const string Filename = "log.txt";
        public static void WriteLog(string action)
        {
            var logText=($"{DateTime.Now:dd.MM.yyyy HH:mm:ss.fff} Action: {action}");

            using (var streamWriter = new StreamWriter(Filename, true, Encoding.UTF8))
            {
                streamWriter.AutoFlush = true;
                streamWriter.WriteLine(logText);
            }
        }
    }
}
