using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBazigar8amBatchDemo1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            ViewBag.watch = "fast track watch";
            return View();
        }
        public ContentResult GetContent(int? id) {
            string ContentData = string.Empty;
            if (id == 1)
            {
                ContentData = "Welcome to the World!";
            }
            else if (id == 2)
            {
                ContentData = "<p style=color:red>Welcome to the World!</p>";

            }
            else if (id == 3)
            {
                ContentData = "<script>alert('Welcome to the World!');</script>";
            }
            else
            {
                ContentData = "No Format Availble";
            }
            return Content(ContentData);
        }
    }
}