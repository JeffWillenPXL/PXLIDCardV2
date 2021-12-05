using Microsoft.EntityFrameworkCore;
using PXLIDCardV2.data.Contracts.Users;
using PXLIDCardV2.domain.Users;
using System.Linq;
using System.Threading.Tasks;

namespace PXLIDCardV2.data.Repositories.Users
{
    class LectorRepository : ILectorRepository
    {
        private readonly Context _context;

        public LectorRepository(Context context)
        {
            _context = context;
        }
        public async Task<Lector> RetrieveLectorByEmail(string email)
        {
            return await _context.Lectors.FirstOrDefaultAsync(l => l.Email == email);
        }

        public async Task<Lector> RetrieveLectorById(int id)
        {
            return await _context.Lectors.Include(l => l.LectorEvaluations).FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
