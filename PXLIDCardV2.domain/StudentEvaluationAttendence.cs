using PXLIDCardV2.domain.Evaluations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXLIDCardV2.domain
{
    public class StudentEvaluationAttendence
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public int EvaluationId { get; set; }
        public EvaluationType EvaluationType { get; set; }
        public bool HasAttended { get; set; }
    }
}
