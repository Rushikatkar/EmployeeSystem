using DAL.Entities;

namespace DAL.Repositories
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetPositionsAsync();
    }
}
