using PXLIDCardV2.domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXLIDCardV2.data.Contracts.Users
{
    public interface IAdminRepository
    {
        Task<Admin> RetrieveAdminById(int id);
        Task<Admin> RetrieveAdminByEmail(string email);
    }
}
