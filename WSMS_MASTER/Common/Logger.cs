using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace WSMS_MASTER.Common
{
    public class Logger
    {
        private static Semaphore fileSemaphore = new Semaphore(1, 1);
        public static string LogDir { get; set; }
        public static string AppTag { get { return "WSMS"; } }

        public Logger()
        {
        }
        public static bool Log(Exception ex)
        {
            return Log(ex.Message + Environment.NewLine + ex.StackTrace);
        }


        public static bool Log(Exception ex, bool isOutputToConsole)
        {
            return Log(ex.Message + Environment.NewLine + ex.StackTrace, isOutputToConsole);
        }

        public static bool Log(string message)
        {
            return Log(message, false);
        }

        public static bool Log(string message, bool isOutputToConsole)
        {
            return Log(AppTag, message, isOutputToConsole);
        }

        public static bool Log(string message, string stacktrace)
        {
            var msg = string.Format("{0}{1}      {2}", message, Environment.NewLine, stacktrace);
            return Log(msg, false);
        }

        public static bool Log(string logName, string message, bool isOutputToConsole)
        {
            try
            {
                fileSemaphore.WaitOne();
                DateTime dt = DateTime.Now;
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (Environment.OSVersion.Version.Major >= 6)
                    path = Directory.GetParent(path).ToString();

                LogDir = Path.Combine(path, "log");
                if (!Directory.Exists(LogDir))
                    Directory.CreateDirectory(LogDir);

                string logFile = string.Format("{0}\\{1}_{2}_{3}_{4}.log", LogDir, logName, dt.Year, dt.Month.ToString("#00"), dt.Day.ToString("#00"));

                StreamWriter writer;
                if (!File.Exists(logFile))
                    writer = File.CreateText(logFile);
                else
                    writer = File.AppendText(logFile);
                string errorLog = string.Format("{0}:{1}:{2} {3}", dt.Hour.ToString("#00"), dt.Minute.ToString("#00"), dt.Second.ToString("#00"), message);
                writer.WriteLine(errorLog);
                writer.Flush();
                writer.Close();
                if (isOutputToConsole)
                {
                    Console.WriteLine(errorLog);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                fileSemaphore.Release();
            }
            return true;
        }
    }
}
