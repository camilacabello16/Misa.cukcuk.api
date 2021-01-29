using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.interfaces
{
    public interface IPositionService
    {
        IEnumerable<EmployeePosition> GetPositions();
    }
}
