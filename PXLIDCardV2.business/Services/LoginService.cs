using PXLIDCardV2.business.Contracts;
using PXLIDCardV2.data.Contracts.Users;
using PXLIDCardV2.domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXLIDCardV2.business.Services
{
    class LoginService : ILoginService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILectorRepository _lectorRepository;
        private readonly IAdminRepository _adminRepository;

        public LoginService(IStudentRepository studentRepository, ILectorRepository lectorRepository, IAdminRepository adminRepository)
        {
            _studentRepository = studentRepository;
            _lectorRepository = lectorRepository;
            _adminRepository = adminRepository;
        }


        public async Task<User> Login(string email, string password)
        {
            User user;
            if (email.EndsWith("@student.pxl.be"))
            {
                user =  await _studentRepository.RetrieveStudentByEmail(email);
                if (user.Password == password)
                {
                    return user;
                }
            }

            else if (email.EndsWith("@lector.pxl.be"))
            {

                user =  await _lectorRepository.RetrieveLectorByEmail(email);
                if (user.Password == password)
                {
                    return user;
                }
            }

            else if (email.EndsWith("@admin.pxl.be"))
            {
                user =  await _adminRepository.RetrieveAdminByEmail(email);
                if (user.Password == password)
                {
                    return user;
                }
            }


            return null;



        }
    }
}
