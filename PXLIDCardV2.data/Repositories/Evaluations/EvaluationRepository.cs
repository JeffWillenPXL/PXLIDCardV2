using Microsoft.EntityFrameworkCore;
using PXLIDCardV2.data.Contracts.Evaluations;
using PXLIDCardV2.domain.Evaluations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PXLIDCardV2.data.Repositories.Evaluations
{
    class EvaluationRepository : IEvaluationRepository
    {
        private readonly Context _context;

        public EvaluationRepository(Context context)
        {
            _context = context;
        }
        public async Task<IList<Evaluation>> RetrieveAllEvaluations()
        {
            return await _context.Evaluations.ToListAsync();
        }

        public async Task<Evaluation> RetrieveEvaluationById(int id)
        {
            return await _context.Evaluations.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Evaluation> UpdateEvaluation(Evaluation evaluation)
        {
            _context.Evaluations.Update(evaluation);
            await _context.SaveChangesAsync();
            return evaluation;
        }
    }
}
