using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabasedFirstApproach.Models;

namespace DatabasedFirstApproach.Controllers
{
    public class EmployeeController : Controller
    {
        private GaneshEntities db = new GaneshEntities();

        // GET: Employee
        public ActionResult Index()
        {
            var EmpDept = (from e in db.EmployeeModels
                           join d in db.DepartmentModels
                           on e.DeptId equals d.DeptId
                           select new EmployeeDept
                           {
                               Empid=e.Empid,
                               EmpName=e.EmpName,
                               EmpSalary=e.EmpSalary,
                               EmailId=e.EmailId,
                               DeptId=d.DeptId,
                               DeptName=d.DeptName
                           }
                         ).ToList();
            return View(EmpDept);
        }

        public ActionResult IndexStoreproc()
        {
            return View(db.sp_GetEmployee().ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModel employeeModel = db.EmployeeModels.Find(id);
            if (employeeModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeModel);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Empid,EmpName,EmpSalary,DeptId")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeModels.Add(employeeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeModel);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModel employeeModel = db.EmployeeModels.Find(id);
            if (employeeModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeModel);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Empid,EmpName,EmpSalary,DeptId")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeModel);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModel employeeModel = db.EmployeeModels.Find(id);
            if (employeeModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeModel);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeModel employeeModel = db.EmployeeModels.Find(id);
            db.EmployeeModels.Remove(employeeModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult CreateSp() {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSp(EmployeeModel emp)
        {
            db.sp_SaveEmployeeDetails(emp.EmpName, emp.EmpSalary, emp.DeptId);
            return View();
        }
    }
}
