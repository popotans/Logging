﻿using System;
using System.Collections.Generic;

namespace Logging.Client
{
    /// <summary>
    /// 处理日志过程中出现的异常
    /// </summary>
    internal class LoggingClientReport
    {
        private static ILog logger = LogManager.GetLogger(typeof(LoggingClientReport));

        /// <summary>
        /// 报告异常
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="count"></param>
        public static void ReportException(Exception ex, int count)
        {
            string msg = "最近一分钟该应用内(" + Settings.AppId + ")Logging.Client发生" + count + "条异常数量";
            msg += "</br>";
            if (count > 0)
            {
                msg += "最近一条异常:" + ex.ToString();
                var tags = new Dictionary<string, string>();
                tags.Add("type", "one_minute_err");
                logger.Error("Logging_Client_Report", msg, tags);
            }
        }

        /// <summary>
        /// 报告溢出
        /// </summary>
        /// <param name="over_count"></param>
        /// <param name="currentQueneLength"></param>
        /// <param name="maxQueueLength"></param>
        public static void ReportOver(int over_count, int currentQueneLength, int maxQueueLength)
        {
            if (over_count <= 0) { return; }
            string msg = "最近一分钟该应用内(" + Settings.AppId + ")发生Logging_Client_Over溢出数量:" + over_count + " 。 建议增加 LoggingQueueLength 和配置值。";
            msg += "</br>";
            msg += "CurrentQueneLength:" + currentQueneLength + "</br>";
            msg += "</br>";
            msg += "MaxQueueLength:" + maxQueueLength + "</br>";
            var over_log_tags = new Dictionary<string, string>();
            over_log_tags.Add("type", "logging_client_over");

            logger.Error("Logging_Client_Report", msg, over_log_tags);

        }
    }
}