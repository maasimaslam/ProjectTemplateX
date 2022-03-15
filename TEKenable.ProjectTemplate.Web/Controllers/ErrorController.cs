using System.Web.Mvc;

namespace TEKenable.ProjectTemplate.Web.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult NotFoundAjax()
        {
            return PartialView("NotFound");
        }
    }
}