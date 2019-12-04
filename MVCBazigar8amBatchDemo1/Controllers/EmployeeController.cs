using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBazigar8amBatchDemo1.Models;
namespace MVCBazigar8amBatchDemo1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        GaneshEntities db = new GaneshEntities();
        public ViewResult Index(int? id)
        {
            //    return "My Employee Id "+ id+"-"+Request.QueryString["ename"]+"-"+Request.QueryString["dept"];
            return View();
        }
        public ViewResult GetData()
        {
            List<EmployeeModel> objlist = new List<EmployeeModel>();
            EmployeeModel obj = new Models.EmployeeModel(); 
            obj.Empid = 12;
            obj.Empname = "Kaushik";
            obj.EmpSalary = 25000;

            EmployeeModel obj1 = new Models.EmployeeModel();
            obj1.Empid = 1;
            obj1.Empname = "Mounika";
            obj1.EmpSalary = 256000;

            objlist.Add(obj);
            objlist.Add(obj1);


            DepartmentModel objdept = new Models.DepartmentModel();
            objdept.Deptid = 1;
            objdept.DeptName = "IT";
            //ViewBag.Someinfo = obj;

            EmpDept objdb = new EmpDept();
            objdb.Employee = objlist;
            objdb.Department = objdept;



            return View(objdb);
        }
        public PartialViewResult mypartial()
        {

            return PartialView("MyPartialView");
        }
        public RedirectResult GotoUrl() {
            return Redirect("http://www.google.com");
        }
        public RedirectResult GotoUrl1()
        {
            return Redirect("~/Employee/GetData");
        }
        public JsonResult GetJsonData()
        {
            List<EmployeeModel> objlist = new List<EmployeeModel>();
            EmployeeModel obj = new Models.EmployeeModel();
            obj.Empid = 12;
            obj.Empname = "Kaushik";
            obj.EmpSalary = 25000;

            EmployeeModel obj1 = new Models.EmployeeModel();
            obj1.Empid = 1;
            obj1.Empname = "Mounika";
            obj1.EmpSalary = 256000;
            objlist.Add(obj);
            objlist.Add(obj1);

            return Json(objlist, JsonRequestBehavior.AllowGet);
        }

        public RedirectToRouteResult getToPage()
        {
            //  return RedirectToAction("index","Default");
            return RedirectToRoute("Default1");
        }

        public ActionResult HtmlHelperExample()
        {
            ViewBag.Country = new SelectList(db.Countries, "Id", "CountryName");
            return View();
        }
    }
}

