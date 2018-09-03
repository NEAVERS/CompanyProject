using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class LogsHelper
    {
        private static void WriteLogs(string logType, string fromType, List<string> contentLineList)
        {
            DateTime now = DateTime.Now;
            string pathName = "D://GPLog/" + logType + "/" + fromType + "/" + now.Year.ToString("D2") + "/" + now.Month.ToString("D2");
            string fileName = now.Day.ToString("D2") + ".txt";
            if (!Directory.Exists(pathName))//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(pathName);
            }
            var logFilePath = string.Format("{0}/{1}", pathName, fileName);
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(logFilePath, true, Encoding.UTF8);
                writer.WriteLine("------------------------------------------------------------------------------");
                foreach (string contentLine in contentLineList)
                {
                    writer.WriteLine(contentLine);
                }
                writer.WriteLine("------------------------------------------------------------------------------");
            }
            catch
            {
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        /// <summary>
        /// 写错误日志 如果不传入来源端 则会读取web.config配置的LogClientName名称 来创建文件夹
        /// </summary>
        /// <param name="msg">备注信息</param>
        /// <param name="ex">错误内容</param>
        /// <param name="fromType">来源</param>
        public static void WriteErrorLog(string msg, Exception ex, string fromType = "")
        {
            if (string.IsNullOrEmpty(fromType))
            {
                string clientName = "";
                if (string.IsNullOrEmpty(clientName)) fromType = "Default";
                else fromType = clientName;
            }

            List<string> contentLineList = new List<string>();
            contentLineList.Add("时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (!string.IsNullOrEmpty(msg))
            {
                contentLineList.Add("备注信息：" + msg);
            }
            contentLineList.Add("错误信息：" + ex.Message);
            contentLineList.Add("错误源：" + ex.Source);
            contentLineList.Add("堆栈信息：" + ex.StackTrace);
            WriteLogs("ErrorLogs", fromType, contentLineList);
        }

        /// <summary>
        /// 写错误日志  如果不传入来源端 则会读取web.config配置的LogClientName名称 来创建文件夹
        /// </summary>
        /// <param name="ex">系统错误类</param>
        /// <param name="fromType">错误发生端</param>
        public static void WriteErrorLog(Exception ex, string fromType = "")
        {
            WriteErrorLog(string.Empty, ex, fromType);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="fromType">来源</param>
        public static void WriteLog(string msg, string fromType)
        {
            List<string> contentLineList = new List<string>();
            contentLineList.Add("时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            contentLineList.Add("信息：" + msg);
            WriteLogs("Logs", fromType, contentLineList);
        }

        /// <summary>
        /// 写日志 此方法会读取web.config配置的LogClientName名称 来创建文件夹
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void WriteLog(string msg)
        {
            string clientName = "";
            if (string.IsNullOrEmpty(clientName)) clientName = "unknown";

            WriteLog(msg, clientName);
        }

    }
}
