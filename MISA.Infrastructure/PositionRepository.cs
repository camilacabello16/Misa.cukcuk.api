using Dapper;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure
{
    public class PositionRepository : IPositionRepository
    {
        public IEnumerable<EmployeePosition> GetPositions()
        {
            IDbConnection db = new MySqlConnection("Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8");
            var employeePositions = db.Query<EmployeePosition>("Proc_GetPosition", commandType: CommandType.StoredProcedure);
            return employeePositions;
        }
    }
}
