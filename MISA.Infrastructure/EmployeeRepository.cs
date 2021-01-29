using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region DECLARE
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection;
        #endregion
        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("HieuConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
        }
        public int AddEmployee(Employee employee)
        {
            IDbConnection db = new MySqlConnection("Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8");
            var parameters = MappingDbType(employee);
            var rowAffects = db.Execute("Proc_InsertEmployee", parameters, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        public int DeleteEmployee(Guid employeeId)
        {
            IDbConnection db = new MySqlConnection("Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8");
            var res = db.Execute("Proc_DeleteEmployee", new { EmployeeId = employeeId.ToString() }, commandType: CommandType.StoredProcedure);
            return res;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            //IDbConnection db = new MySqlConnection("Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8");
            var employees = _dbConnection.Query<Employee>("Proc_GetEmployee", commandType: CommandType.StoredProcedure);
            return employees;
        }

        public int UpdateEmployee(Employee employee)
        {
            IDbConnection db = new MySqlConnection("Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8");
            var parameters = MappingDbType(employee);
            var rowAffects = db.Execute("Proc_UpdateEmployee", parameters, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        public DynamicParameters MappingDbType<T>(T entity)
        {
            var properties = entity.GetType().GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }
            }
            return parameters;
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            IDbConnection db = new MySqlConnection("Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8");
            var employee = db.Query<Employee>("Proc_GetEmployeeById", new { EmployeeId = employeeId.ToString() }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return employee;
        }

        public string GetMaxEmployeeCode()
        {
            IDbConnection db = new MySqlConnection("Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8");
            var maxEmployeeCode = db.Query<string>("SELECT EmployeeCode FROM Employee e ORDER BY e.EmployeeCode DESC limit 1", commandType: CommandType.Text).FirstOrDefault();
            return maxEmployeeCode;
        }

        public IEnumerable<EmployeeInfo> GetEmployeeInfos()
        {
            IDbConnection db = new MySqlConnection("Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8");
            var employeeInfos = db.Query<EmployeeInfo>("Proc_GetAllEmployee", commandType: CommandType.StoredProcedure);
            return employeeInfos;
        }

        public int GetNumberOfEmployee()
        {
            IDbConnection db = new MySqlConnection("Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8");
            var numberOfEmployee = db.Query<int>("Proc_GetNumberOfEmployee", commandType: CommandType.Text).FirstOrDefault();
            return numberOfEmployee;
        }

        public IEnumerable<EmployeeInfo> GetEmployeeByPage(int positionStart)
        {
            IDbConnection db = new MySqlConnection("Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8");
            //var employeeInfos = db.Query<EmployeeInfo>("Proc_GetEmployeeByPage", new { PositionStart = positionStart }, commandType: CommandType.StoredProcedure);
            var employeeInfos = db.Query<EmployeeInfo>("Proc_GetEmployeeByPage", new { PositionStart = positionStart }, commandType: CommandType.StoredProcedure);

            return employeeInfos;
        }

        public void DeleteMultiesEmployee(Guid[] employeeIdStr)
        {
            IDbConnection db = new MySqlConnection("Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8");
            for(int i = 0; i<employeeIdStr.Length; i++)
            {
                db.Execute("Proc_DeleteEmployee", new { EmployeeId = employeeIdStr[i].ToString() }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
