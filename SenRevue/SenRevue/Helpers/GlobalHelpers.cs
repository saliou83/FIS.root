using SenRevue.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.Web.Mvc;

namespace SenRevue.Helpers
{
    public class GlobalHelper
    {
        /// <summary>
        /// Verifie si un email est valide
        /// </summary>
        /// <param name="emailaddress"></param>
        /// <returns></returns>
        public static bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Tenum"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static List<SelectListItem> EnumToSelectListItem<Tenum>()
        {
            var result = new List<SelectListItem>()
            {
                {
                    new SelectListItem
                    {
                        Text = string.Format("-- {0} --",LabelHelpers.GetLabel("select_label")),
                        Value = string.Empty
                    }
                }
            };
            result.AddRange(Enum.GetValues(typeof(Tenum)).Cast<Tenum>()
                .Select(v => new SelectListItem
                {
                    Text = LabelHelpers.GetLabel(v.ToString()),
                    Value = v.ToString()
                }).ToList());

            return result.ToList();
        }
    }
}