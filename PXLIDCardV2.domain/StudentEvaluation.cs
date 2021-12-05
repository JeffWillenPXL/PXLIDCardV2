using PXLIDCardV2.domain.Evaluations;
using PXLIDCardV2.domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXLIDCardV2.domain
{
    public class StudentEvaluation
    {
        public int StudentId { get; set; }
        public int EvaluationId { get; set; }
        public Student Student { get; set; }
        public Evaluation Evaluation { get; set; }
        public bool HasAttended { get; set; }
    }
}
