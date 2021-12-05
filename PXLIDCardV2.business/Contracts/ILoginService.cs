using PXLIDCardV2.domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXLIDCardV2.business.Contracts
{
    public interface ILoginService
    {
        Task<User> Login(string email, string password);
    }
}
