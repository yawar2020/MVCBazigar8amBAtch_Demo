using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBazigar8amBatchDemo1.Models
{
    public class EmployeeModel
    {
        public int Empid { get; set; }
       [Display(Name ="Employee Name")]
        public string Empname { get; set; }
        public int EmpSalary { get; set; }
    }
    public class DepartmentModel
    {
        public int Deptid { get; set; }
        public string  DeptName { get; set; }
    }

    public class EmpDept
    {
        public List<EmployeeModel> Employee { get; set; }
        public DepartmentModel Department { get; set; }
    }


}