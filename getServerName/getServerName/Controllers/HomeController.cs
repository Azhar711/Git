using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace getServerName.Controllers
{
    public class HomeController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));
        public ActionResult Index()
        {
            //return View();
            
            string Name = System.Environment.MachineName;
            ViewBag.message="The Server Name is : "+ Name;
            logger.Info(string.Format("The Server Name is : "+ Name),null);
            return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}