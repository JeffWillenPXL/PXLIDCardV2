using PXLIDCardV2.business.Contracts;
using PXLIDCardV2.data.Contracts;
using PXLIDCardV2.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXLIDCardV2.business.Services
{
    class StudentService : IStudentService
    {
        private readonly IStudentEvaluationRepository _studenEvaluationRepository;

        public StudentService(IStudentEvaluationRepository studentEvaluationRepository)
        {
            _studenEvaluationRepository = studentEvaluationRepository;
        }
        public async Task<IList<StudentEvaluationAttendence>> GetEvaluationsForStudent(int studentId)
        {
            return await _studenEvaluationRepository.RetrieveStudentEvaluationAttendencesByStudentId(studentId);
        }
    }
}
