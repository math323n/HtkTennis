using System;
using System.IO;
using System.Net.Http;
using System.Configuration;
using System.Threading.Tasks;

namespace HtkTennis
{
    /// <summary>
    /// Logger is useful for debugging code & discovering errors.
    /// </summary>
    public static class Logger
    {
        #region Fields
        private static string logFilePath;
        private static string logFolderPath;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for Logger, purpose is to configure the logger
        /// </summary>
        static Logger()
        {
            Configure();
        }
        #endregion

        #region Synchronous Methods
        /// <summary>
        /// Configure the filepath.
        /// </summary>
        public static void Configure()
        {
            logFolderPath = ConfigurationManager.AppSettings["LogFolderPath"].ToString();
            // Create folder if it doesn't exist, to store logs in.
            if(!Directory.Exists(logFolderPath))
            {
                // Create folder "Log"
                Directory.CreateDirectory(logFolderPath);
            }
            // Assign location for .txt document
            logFilePath = ConfigurationManager.AppSettings["LogFilePath"].ToString();
        }

        /// <summary>
        /// Method for handling message Logs
        /// </summary>
        /// <param name="message"></param>
        public static void Log(string message)
        {
            WriteLog(message);
        }

        /// <summary>
        /// Method for handling exception Logs
        /// </summary>
        /// <param name="ex"></param>
        public static void Log(Exception ex)
        {
            // a line of dashes to seperate logs
            string line = new string('-', 170);
            // The string to be written to a log
            string message =
                $"Date: {DateTime.Now}\n" +
                $"Message: {ex.Message}\n" +
                $"Source: {ex.Source}\n" +
                $"InnerException: {ex.InnerException}\n" +
                $"StackTrace: {ex.StackTrace}\n" +
                $"{line}";
            // Send message to be written
            WriteLog(message);
        }

        /// <summary>
        /// Write log to the log file .txt document
        /// </summary>
        /// <param name="message"></param>
        private static void WriteLog(string message)
        {
            using StreamWriter writer = new StreamWriter(logFilePath, true);
            // Write...
            writer.WriteLine(message);
        }
        #endregion



        #region Async Methods
        /// <summary>
        /// asynchronous method for handling exception Logs
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static async Task LogAsync(Exception ex)
        {
            // a line of dashes to seperate logs
            string line = new string('-', 170);
            // The string to be written to a log
            string message =
                $"Date: {DateTime.Now}\n" +
                $"Message: {ex.Message}\n" +
                $"Source: {ex.Source}\n" +
                $"InnerException: {ex.InnerException}\n" +
                $"StackTrace: {ex.StackTrace}\n" +
                $"{line}";
            // Send message to be written
            await WriteLogAsync(message);
        }

        /// <summary>
        /// Write log asynchronous to the log file .txt document
        /// </summary>
        /// <param name="message"></param>
        private static async Task WriteLogAsync(string message)
        {
            await using StreamWriter writer = new StreamWriter(logFilePath, true);
            // Write...
            writer.WriteLine(message);
        }
        #endregion
    }
}