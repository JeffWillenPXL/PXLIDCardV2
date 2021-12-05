using PXLIDCardV2.business.Contracts;
using PXLIDCardV2.data.Contracts;
using PXLIDCardV2.data.Contracts.Users;
using PXLIDCardV2.domain;
using PXLIDCardV2.domain.Evaluations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PXLIDCardV2.business.Services
{
    class LectorService : ILectorService
    {
        private readonly ILectorRepository _lectorRepository;
        private readonly IStudentEvaluationRepository _studentEvaluationRepository;

        public LectorService(ILectorRepository lectorRepository, IStudentEvaluationRepository studentEvaluationRepository)
        {
            _lectorRepository = lectorRepository;
            _studentEvaluationRepository = studentEvaluationRepository;

        }
        public async Task<IList<Evaluation>> GetLectorEvaluations(int lectorId)
        {
            var lector = await _lectorRepository.RetrieveLectorById(lectorId);
            return lector.LectorEvaluations;
        }

        public async Task<IList<StudentEvaluationAttendence>> GetStudentsForEvaluation(int evaluationId)
        {
            return await _studentEvaluationRepository.RetrieveStudentEvaluationAttendencesByEvaluationId(evaluationId);
        }

        public async Task RegisterStudent(StudentEvaluation studentEvaluation)
        {
            await _studentEvaluationRepository.UpdateStudentEvaluation(studentEvaluation);
        }
    }
}
