using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.interfaces
{
    public interface IPositionRepository
    {
        IEnumerable<EmployeePosition> GetPositions();
    }
}
