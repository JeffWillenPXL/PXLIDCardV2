using PXLIDCardV2.domain;
using PXLIDCardV2.domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXLIDCardV2.data.Contracts.Users

{
    public interface IStudentRepository
    {
        Task<IList<Student>> RetrieveAllStudents();
        Task<Student> RetrieveStudentById(int id);
        Task<Student> RetrieveStudentByEmail(string email);
        Task<Student> UpdateStudent(Student student);
        
    }
}
