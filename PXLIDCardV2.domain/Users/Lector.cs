using PXLIDCardV2.domain.Evaluations;
using System.Collections.Generic;

namespace PXLIDCardV2.domain.Users
{
    public class Lector : User
    {
        public Lector()
        {
            LectorEvaluations = new List<Evaluation>();
        }
        public IList<Evaluation> LectorEvaluations { get; set; }
    }
}
