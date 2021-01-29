using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<EmployeeDepartment> GetDepartments();
        string GetDepartmentById(int departmentId);
    }
}
