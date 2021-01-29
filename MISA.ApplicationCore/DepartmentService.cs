using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public string GetDepartmentById(int departmentId)
        {
            return _departmentRepository.GetDepartmentById(departmentId);
        }

        public IEnumerable<EmployeeDepartment> GetDepartments()
        {
            return _departmentRepository.GetDepartments();
        }
    }
}
