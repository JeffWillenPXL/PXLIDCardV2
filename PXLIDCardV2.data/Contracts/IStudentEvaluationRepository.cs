using PXLIDCardV2.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXLIDCardV2.data.Contracts
{
    public interface IStudentEvaluationRepository
    {
        Task<IList<StudentEvaluationAttendence>> RetrieveStudentEvaluationAttendencesByStudentId(int studentId);
        Task<IList<StudentEvaluationAttendence>> RetrieveStudentEvaluationAttendencesByEvaluationId(int evaluationId);
        Task<StudentEvaluation> UpdateStudentEvaluation(StudentEvaluation studentEvaluation);
    }
}
