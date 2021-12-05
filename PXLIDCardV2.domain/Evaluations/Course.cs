using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXLIDCardV2.domain.Evaluations
{
    public class Course
    {
        public Course()
        {
            Evaluations = new List<Evaluation>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Evaluation> Evaluations { get; set; }
    }
}
