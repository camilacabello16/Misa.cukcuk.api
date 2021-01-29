using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Hieu.CukCuk.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult Get()
        {
            var employees = _employeeService.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public Employee GetById(Guid id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            return employee;
        }

        [HttpGet("/max-employee-code")]
        public string GetMaxEmployeeCode()
        {
            var maxEmployeeCode = _employeeService.GetMaxEmployeeCode();
            return maxEmployeeCode;
        }

        [HttpGet("/employee-info")]
        public IActionResult GetEmployeeInfos()
        {
            return Ok(_employeeService.GetEmployeeInfos());
        }

        [HttpGet("/number-employee")]
        public int GetNumberOfEmployee()
        {
            var numberOfEmployee = _employeeService.GetNumberOfEmployee();
            return numberOfEmployee;
        }

        [HttpGet("/test/{PositionStart}")]
        public IActionResult GetEmployeeByPage(int PositionStart)
        {
            return Ok(_employeeService.GetEmployeeByPage(PositionStart));
        }
        // GET api/<EmployeeController>/5
        //[HttpGet("{id}")]
        //public Employee Get(string id)
        //{
        //    var employeeService = new EmployeeService();
        //    return employeeService.GetEmployeeById(id);
        //}

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post(Employee employee)
        {
            _employeeService.AddEmployee(employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public void Put(Employee employee)
        {
            _employeeService.UpdateEmployee(employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _employeeService.DeleteEmployee(id);
        }
    }
}
