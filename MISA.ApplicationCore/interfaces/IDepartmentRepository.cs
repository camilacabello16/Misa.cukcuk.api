using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.interfaces
{
    public interface IDepartmentRepository
    {
        IEnumerable<EmployeeDepartment> GetDepartments();
        string GetDepartmentById(int departmentId);
    }
}
