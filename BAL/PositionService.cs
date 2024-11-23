using DAL.Entities;
using DAL.Repositories;

namespace BAL
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<IEnumerable<Position>> GetPositionsAsync()
        {
            return await _positionRepository.GetPositionsAsync();
        }
    }
}
