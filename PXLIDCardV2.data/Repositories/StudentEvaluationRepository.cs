using Microsoft.EntityFrameworkCore;
using PXLIDCardV2.data.Contracts;
using PXLIDCardV2.domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PXLIDCardV2.data.Repositories
{
    class StudentEvaluationRepository : IStudentEvaluationRepository
    {
        private readonly Context _context;

        public StudentEvaluationRepository(Context context)
        {
            _context = context;
        }
        public async Task<IList<StudentEvaluationAttendence>> RetrieveStudentEvaluationAttendencesByEvaluationId(int evaluationId)
        {
            return  await _context.StudentEvaluations.Where(se => se.EvaluationId == evaluationId)
                            .Select(se => new StudentEvaluationAttendence
                            {
                                StudentId = se.StudentId,
                                StudentFirstName = se.Student.FirstName,
                                StudentLastName = se.Student.LastName,
                                EvaluationId = se.EvaluationId,
                                EvaluationType = se.Evaluation.EvaluationType,
                                HasAttended = se.HasAttended
                            }).ToListAsync();


        }

        public async Task<IList<StudentEvaluationAttendence>> RetrieveStudentEvaluationAttendencesByStudentId(int studentId)
        {
            return await _context.StudentEvaluations.Where(se => se.StudentId == studentId)
                            .Select(se => new StudentEvaluationAttendence
                            {
                                StudentId = se.StudentId,
                                StudentFirstName = se.Student.FirstName,
                                StudentLastName = se.Student.LastName,
                                EvaluationId = se.EvaluationId,
                                EvaluationType = se.Evaluation.EvaluationType,
                                HasAttended = se.HasAttended
                            }).ToListAsync();
        }

        public async Task<StudentEvaluation> UpdateStudentEvaluation(StudentEvaluation studentEvaluation)
        {
            _context.StudentEvaluations.Update(studentEvaluation);
            await _context.SaveChangesAsync();
            return studentEvaluation;
        }
    }
}
