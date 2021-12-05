using PXLIDCardV2.domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXLIDCardV2.domain.Evaluations
{
    public class Evaluation
    {
        public Evaluation()
        {
            StudentEvaluations = new List<StudentEvaluation>();
        }

        public int Id { get; set; }
        public EvaluationType EvaluationType { get; set; }
        public int CourseId { get; set; }
        public int LectorId { get; set; }
        public List<StudentEvaluation> StudentEvaluations { get; set; }


    }
}
