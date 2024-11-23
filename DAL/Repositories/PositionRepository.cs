using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly EmployeeDbContext _context;

        public PositionRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Position>> GetPositionsAsync()
        {
            return await _context.Positions.ToListAsync();
        }
    }
}
