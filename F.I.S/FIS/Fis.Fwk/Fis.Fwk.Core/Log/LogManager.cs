using Fis.Fwk.Core.Manager;
using log4net.Core;
using log4net.Layout;
using log4net.Layout.Pattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fis.Fwk.Core.Log
{
    public class LogManager : Singleton<LogManager>
    {
        public LogManager()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        #region LogManager

        private log4net.ILog MonitoringLogger
        {
            get
            {
                return log4net.LogManager.GetLogger("LogManager");
            }
        }

        private string GetLogFromObject(object parametre)
        {
            var retour = "";
            if (parametre != null)
            {
                var prop = parametre.GetType();
                if (prop.GetInterface("IEnumerable") != null && prop.FullName != "System.String")
                {
                    var lst = ((IEnumerable)parametre).Cast<object>();
                    retour = string.Format("{0:00000} item(s)", lst.Count());
                }
                else if (prop.Namespace == "System.Data.Entity.DynamicProxies" && prop.BaseType != null)
                {
                    retour = string.Format("Proxy {0}", prop.BaseType.FullName);
                }
                else if (parametre is DateTime)
                {
                    retour = ((DateTime)parametre).ToString("s");
                }
                else
                {
                    retour = parametre.ToString();
                }
            }
            return retour;
        }
        /// <summary>
        /// A utiliser au début d'un service
        /// </summary>
        /// <param name="parametres">La liste des paramètres du service</param>
        public void Debut(params object[] parametres)
        {
            if (MonitoringLogger.IsInfoEnabled)
            {
                StringBuilder log = new StringBuilder();
                log.Append("[DEBUT]");
                if (parametres != null && parametres.Any())
                {
                    var logParametre = new List<string>();
                    foreach (var parametre in parametres)
                    {
                        logParametre.Add(GetLogFromObject(parametre));
                    }
                    log.AppendFormat(" : [{0}]", string.Join("] - [", logParametre));
                }
                Info(log.ToString());
            }
        }

        /// <summary>
        /// A utiliser à la fin d'un service
        /// </summary>
        /// <param name="retour">Le retour si c'est une fonction</param>
        public void Fin(object retour = null)
        {
            if (MonitoringLogger.IsDebugEnabled)
            {
                StringBuilder log = new StringBuilder();
                log.Append("[FIN]");
                if (retour != null)
                {
                    log.AppendFormat(" : [{0}]", GetLogFromObject(retour));
                }
                Debug(log.ToString());
            }
        }

        /// <summary>
        /// A utiliser dans les services de la couche business
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public void ErrorAndThrow(string message, Exception ex)
        {
            if (MonitoringLogger.IsErrorEnabled)
            {
                Error(message, ex);
            }
            throw ex;
        }

        public void Info(string message)
        {
            if (MonitoringLogger.IsInfoEnabled)
            {
                MonitoringLogger.Info(message);
            }
        }
        public void Info(string message, Exception ex)
        {
            if (MonitoringLogger.IsInfoEnabled)
            {
                MonitoringLogger.Info(message, ex);
            }
        }
        public void InfoFormat(string format, params object[] args)
        {
            if (MonitoringLogger.IsInfoEnabled)
            {
                MonitoringLogger.InfoFormat(format, args);
            }
        }

        public void Debug(string message)
        {
            if (MonitoringLogger.IsDebugEnabled)
            {
                MonitoringLogger.Debug(message);
            }
        }
        public void Debug(string message, Exception ex)
        {
            if (MonitoringLogger.IsDebugEnabled)
            {
                MonitoringLogger.Debug(message, ex);
            }
        }
        public void DebugFormat(string format, params object[] args)
        {
            if (MonitoringLogger.IsDebugEnabled)
            {
                MonitoringLogger.DebugFormat(format, args);
            }
        }

        public void Warn(string message)
        {
            if (MonitoringLogger.IsWarnEnabled)
            {
                MonitoringLogger.Warn(message);
            }
        }
        public void Warn(string message, Exception ex)
        {
            if (MonitoringLogger.IsWarnEnabled)
            {
                MonitoringLogger.Warn(message, ex);
            }
        }
        public void WarnFormat(string format, params object[] args)
        {
            if (MonitoringLogger.IsWarnEnabled)
            {
                MonitoringLogger.WarnFormat(format, args);
            }
        }

        public void Error(string message)
        {
            if (MonitoringLogger.IsErrorEnabled)
            {
                MonitoringLogger.Error(message);
            }
        }
        public void Error(string message, Exception ex)
        {
            if (MonitoringLogger.IsErrorEnabled)
            {
                MonitoringLogger.Error(message, ex);
            }
        }
        public void ErrorFormat(string format, params object[] args)
        {
            if (MonitoringLogger.IsErrorEnabled)
            {
                MonitoringLogger.ErrorFormat(format, args);
            }
        }

        public void Fatal(string message)
        {
            if (MonitoringLogger.IsFatalEnabled)
            {
                MonitoringLogger.Fatal(message);
            }
        }
        public void Fatal(string message, Exception ex)
        {
            if (MonitoringLogger.IsFatalEnabled)
            {
                MonitoringLogger.Fatal(message, ex);
            }
        }
        public void FatalFormat(string format, params object[] args)
        {
            if (MonitoringLogger.IsFatalEnabled)
            {
                MonitoringLogger.FatalFormat(format, args);
            }
        }

        #endregion
    }

    public class CustomPatternLayout : PatternLayout
    {
        public CustomPatternLayout() : base()
        {
            this.AddConverter("methodname", typeof(StackTraceConverter));
        }
    }

    public class StackTraceConverter : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            var stack = new StackTrace();
            var frames = stack.GetFrames();
            if (frames != null)
            {
                var frame = frames.FirstOrDefault(p => p.GetMethod().DeclaringType != null && (p.GetMethod().DeclaringType.Assembly != typeof(LogManager).Assembly
                    && p.GetMethod().DeclaringType.Assembly != typeof(log4net.LogManager).Assembly));
                if (frame != null)
                {
                    var method = frame.GetMethod();
                    writer.Write("{0}{1}",
                        method.DeclaringType != null ? method.DeclaringType.FullName + "." : "",
                        method.Name);
                }
            }
        }
    }
}
