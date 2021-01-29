using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        int AddEmployee(Employee enployee);
        int UpdateEmployee(Employee enployee);
        int DeleteEmployee(Guid employeeId);
        Employee GetEmployeeById(Guid employeeId);
        string GetMaxEmployeeCode();
        IEnumerable<EmployeeInfo> GetEmployeeInfos();
        int GetNumberOfEmployee();
        IEnumerable<EmployeeInfo> GetEmployeeByPage(int positionStart);
        void DeleteMultiesEmployee(Guid[] employeeId);
    }
}
