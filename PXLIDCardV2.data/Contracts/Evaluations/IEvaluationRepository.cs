using PXLIDCardV2.domain.Evaluations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXLIDCardV2.data.Contracts.Evaluations
{
    public interface IEvaluationRepository
    {
        Task<IList<Evaluation>> RetrieveAllEvaluations();
        Task<Evaluation> RetrieveEvaluationById(int id);
        Task<Evaluation> UpdateEvaluation(Evaluation evaluation);
    }
}
