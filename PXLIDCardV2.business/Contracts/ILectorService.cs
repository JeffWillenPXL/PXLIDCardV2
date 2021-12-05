using PXLIDCardV2.domain;
using PXLIDCardV2.domain.Evaluations;
using PXLIDCardV2.domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXLIDCardV2.business.Contracts
{
    public interface ILectorService
    {
        Task<IList<Evaluation>> GetLectorEvaluations(int lectorId);
        Task<IList<StudentEvaluationAttendence>> GetStudentsForEvaluation(int evaluationId);
        Task RegisterStudent(StudentEvaluation studentevaluation);
    }
}
