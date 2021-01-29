using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Hieu.CukCuk.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var departments = _departmentService.GetDepartments();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public string GetDepartmentById(int id)
        {
            return _departmentService.GetDepartmentById(id);
        }
    }
}
