using Microsoft.VisualStudio.TestTools.UnitTesting;
using SenRevue.Areas.Admin.Controllers;
using SenRevue.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SenRevue.Tests.Helper
{
    [TestClass]
    public class MailHelperTest
    {
        [TestMethod]
        public void SendMailOK()
        {
            AccountController controller = new AccountController();
            //controller.DeleteUser("fallsaliou23@gmail.com");
            //MailHelper.SendMail1();
            //bool result = MailHelper.SendMail("saliou.fall@senrevue.com", null, "test envoi mail", "test envoie mail");
            //Assert.IsTrue(result);
        }
    }
}
