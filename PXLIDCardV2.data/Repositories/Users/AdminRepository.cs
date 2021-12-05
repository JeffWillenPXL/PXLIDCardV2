using Microsoft.EntityFrameworkCore;
using PXLIDCardV2.data.Contracts.Users;
using PXLIDCardV2.domain.Users;
using System.Threading.Tasks;

namespace PXLIDCardV2.data.Repositories.Users
{
    class AdminRepository : IAdminRepository
    {
        private readonly Context _context;

        public AdminRepository(Context context)
        {
            _context = context;
        }
        public async Task<Admin> RetrieveAdminByEmail(string email)
        {
            return await _context.Admins.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<Admin> RetrieveAdminById(int id)
        {
            return await _context.Admins.FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
