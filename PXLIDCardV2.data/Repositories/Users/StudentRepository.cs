using Microsoft.EntityFrameworkCore;
using PXLIDCardV2.data.Contracts.Users;
using PXLIDCardV2.domain;
using PXLIDCardV2.domain.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PXLIDCardV2.data.Repositories.Users
{
    class StudentRepository : IStudentRepository
    {
        private readonly Context _context;

        public StudentRepository(Context context)
        {
            _context = context;
        }
        public async Task<IList<Student>> RetrieveAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> RetrieveStudentByEmail(string email)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<Student> RetrieveStudentById(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
