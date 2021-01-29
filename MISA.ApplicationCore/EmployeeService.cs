using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using MISA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #region Method
        //Lấy danh sách
        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }
        //Lấy thông tin theo mã
        //public Employee GetEmployeeById(string employeeId)
        //{
        //    var employeeContext = new EmployeeContext();
        //    return employeeContext.GetEmployeeById(employeeId);
        //}
        //Thêm mới
        public int AddEmployee(Employee employee)
        {
            //validate

            //thêm
            int rowAffect = _employeeRepository.AddEmployee(employee);
            return rowAffect;
        }
        //Sửa thông tin
        public int UpdateEmployee(Employee employee)
        {
            int rowAffect = _employeeRepository.UpdateEmployee(employee);
            return rowAffect;
        }
        public int DeleteEmployee(Guid employeeId)
        {
            int res = _employeeRepository.DeleteEmployee(employeeId);
            return res;
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            var employee = _employeeRepository.GetEmployeeById(employeeId);
            return employee;
        }

        public string GetMaxEmployeeCode()
        {
            var maxEmployeeCode = _employeeRepository.GetMaxEmployeeCode();
            return maxEmployeeCode;
        }

        public IEnumerable<EmployeeInfo> GetEmployeeInfos()
        {
            return _employeeRepository.GetEmployeeInfos();
        }

        public int GetNumberOfEmployee()
        {
            return _employeeRepository.GetNumberOfEmployee();
        }

        public IEnumerable<EmployeeInfo> GetEmployeeByPage(int positionStart)
        {
            return _employeeRepository.GetEmployeeByPage(positionStart);
        }

        #endregion
    }
}
