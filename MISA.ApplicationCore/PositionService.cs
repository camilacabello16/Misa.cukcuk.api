using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class PositionService : IPositionService
    {
        IPositionRepository _positionRepository;
        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }
        public IEnumerable<EmployeePosition> GetPositions()
        {
            return _positionRepository.GetPositions();
        }
    }
}
