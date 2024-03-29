﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabasedFirstApproach.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GaneshEntities : DbContext
    {
        public GaneshEntities()
            : base("name=GaneshEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EmployeeModel> EmployeeModels { get; set; }
        public virtual DbSet<DepartmentModel> DepartmentModels { get; set; }
    
        public virtual ObjectResult<sp_GetEmployee_Result> sp_GetEmployee()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetEmployee_Result>("sp_GetEmployee");
        }
    
        public virtual ObjectResult<sp_GetDepartyment_Result> sp_GetDepartyment()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetDepartyment_Result>("sp_GetDepartyment");
        }
    
        public virtual ObjectResult<int> sp_SaveEmployeeDetails(string empName, Nullable<int> empSalary, Nullable<int> deptId)
        {
            var empNameParameter = empName != null ?
                new ObjectParameter("EmpName", empName) :
                new ObjectParameter("EmpName", typeof(string));
    
            var empSalaryParameter = empSalary.HasValue ?
                new ObjectParameter("EmpSalary", empSalary) :
                new ObjectParameter("EmpSalary", typeof(int));
    
            var deptIdParameter = deptId.HasValue ?
                new ObjectParameter("DeptId", deptId) :
                new ObjectParameter("DeptId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int>("sp_SaveEmployeeDetails", empNameParameter, empSalaryParameter, deptIdParameter);
        }
    }
}
