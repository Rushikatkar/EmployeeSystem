using DAL.Entities;

namespace BAL
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> GetPositionsAsync();
    }
}
