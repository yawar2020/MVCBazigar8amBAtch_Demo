using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBasedApproach.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
      
            List<string> obj = new List<string>();
            obj.Add("pratiusha");
            obj.Add("deepti");
            obj.Add("Nagini");
            obj.Add("Anusha");
            // ViewData["Student"] = obj;
            TempData["Student"] = "hello world";
            return RedirectToAction("GetviewData");
        }
        public ActionResult GetviewData()
        {
            //var s = TempData["Student"];
            //TempData.Keep();
            var s = TempData.Peek("Student");
            ViewData["StudentDetails"] = s;
            return View();
        }
      
    }
}