using log4net;
using System.Web.Mvc;

namespace TEKenable.ProjectTemplate.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ILog _log;

        public HomeController(ILog log)
        {
            _log = log;
            _log.Debug("Home Controller initialized");
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Nidd()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult Test()
        {
            var x = 0;
            x /= x;

            return View();
        }
    }
}
