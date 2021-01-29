using Dapper;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public string GetDepartmentById(int departmentId)
        {
            IDbConnection db = new MySqlConnection("Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8");
            var DepartmentName = db.Query<string>("Proc_GetDepartmentById", new { DepartmentId = departmentId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return DepartmentName;
        }

        public IEnumerable<EmployeeDepartment> GetDepartments()
        {
            IDbConnection db = new MySqlConnection("Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8");
            var employeeDepartments = db.Query<EmployeeDepartment>("Proc_GetDepartment", commandType: CommandType.StoredProcedure);
            return employeeDepartments;
        }
    }
}
