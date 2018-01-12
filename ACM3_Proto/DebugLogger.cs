using System;
using System.IO;
using System.Collections.Generic;
using CommonCore;

namespace FadingUtility.Helpers
{
    public class DebugLogger
    {
        static private DebugLogger _instance;
        private bool m_fileOpen = false;
        private FileStream m_fileStream;
        private StreamWriter m_streamWriter;

        private string m_applicationFolder;
        private string m_folder;
        const string TRACE_FILENAME = "TraceLog.txt";

        #region Properties

        static public DebugLogger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DebugLogger();
                }
                return _instance;
            }
        }

        public string TraceFilename
        {
            get
            {
                return TRACE_FILENAME;
            }
        }

        #endregion // Properties

        private DebugLogger()
        {
            m_applicationFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            m_folder = m_applicationFolder + "\\" + ProductConstant.MANUFACTURE + "\\" + ProductConstant.PRODUCT_FOLDER + "\\";
        }

        public string CloseTraceLog(bool exceptionClose)
        {
            string dumpFile = "";
            try
            {
                if (m_fileOpen == true)
                {
                    m_streamWriter.Close();
                    m_fileStream.Close();
                    m_fileOpen = false;
                }
                if (exceptionClose == true)
                {
                    dumpFile = m_folder + "ExceptionDump" + DateTime.Now.GetHashCode() + ".txt";
                    File.Copy(m_folder + TRACE_FILENAME, dumpFile);
                }
            }
            catch
            {
            }
            return dumpFile;
        }

        public void OpenTraceLog()
        {
            try
            {
                if (m_fileOpen == false)
                {
                    if (!Directory.Exists(m_folder))
                        Directory.CreateDirectory(m_folder);

                    m_fileStream = new FileStream(m_folder + TRACE_FILENAME, FileMode.Create);
                    m_streamWriter = new StreamWriter(m_fileStream);
                    m_fileOpen = true;
                }
            }
            catch
            {
            }
        }

        public void LogExceptionEvent(Exception Ex, string Location)
        {
            LogInformation("--------------------------------------------------------------");
            LogInformation(Ex, Location);
            LogInformation("--------------------------------------------------------------");
        }

        public void LogInformation(string Message)
        {
            try
            {
                if (m_fileOpen == false)
                    OpenTraceLog();

                m_streamWriter.WriteLine(DateTime.Now.ToLongTimeString() + " - " + Message);
                //Force all of the data to be written to the file 
                m_streamWriter.Flush();
                m_fileStream.Flush();
            }
            catch
            {
            }
        }

        public void LogInformation(List<string> Info)
        {
            try
            {
                int index = 0;
                foreach (string item in Info)
                {
                    LogInformation(index.ToString() + ": " + item);
                    index++;
                }
            }
            catch
            {
            }
        }



        public void LogInformation(List<int> Info)
        {
            try
            {
                int index = 0;
                foreach (int item in Info)
                {
                    LogInformation(index.ToString() + ": " + item.ToString());
                    index++;
                }
            }
            catch
            {
            }
        }

        public void LogInformation(Exception Ex, string Message)
        {
            LogInformation("---Exception: " + Message);
            LogInformation("---Message: " + Ex.Message);
            LogInformation("---Source:" + Ex.Source);
            LogInformation("---InnerException:" + Ex.InnerException);
        }
    }
}
