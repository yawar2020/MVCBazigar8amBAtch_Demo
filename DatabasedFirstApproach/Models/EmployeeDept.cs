using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabasedFirstApproach.Models
{
    public class EmployeeDept
    {
        public int Empid { get; set; }
        public string EmpName { get; set; }
        public int EmpSalary { get; set; }
        public string EmailId { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}