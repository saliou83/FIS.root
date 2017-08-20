using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using SenRevue.Business.Manager;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Net;

namespace SenRevue.Helpers
{
    public class MailHelper
    {
        /// <summary>
        /// Envoie d'un mail
        /// </summary>
        /// <param name="recipient"></param>
        /// <param name="recipientCC"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static bool SendMail(string recipient, List<string> recipientCC, string subject, string body)
        {
            bool result = false;
            try
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

                MailMessage mail = new MailMessage(settings.Smtp.Network.UserName, recipient, subject, body) { IsBodyHtml = true }; 
                mail.From = new MailAddress(settings.Smtp.Network.UserName);
                mail.To.Add(new MailAddress(recipient));
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(settings.Smtp.Network.Host, settings.Smtp.Network.Port);
                smtp.Credentials = new NetworkCredential(settings.Smtp.Network.UserName, settings.Smtp.Network.Password);
                smtp.EnableSsl = true;

                smtp.Send(mail);
                result = true;
            }
            catch (Exception ex)
            {
                LogManager.Current.Error("Echec lors de l'envoie du mail", ex);
            }
            return result;
        }
        
    }
}