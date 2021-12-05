using PXLIDCardV2.domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXLIDCardV2.data.Contracts.Users
{
    public interface ILectorRepository
    {
        Task<Lector> RetrieveLectorById(int id);
        Task<Lector> RetrieveLectorByEmail(string email);
        
    }
}
