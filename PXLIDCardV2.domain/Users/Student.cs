using System.Collections.Generic;
namespace PXLIDCardV2.domain.Users
{
    public class Student : User
    {
        public Student()
        {
            StudentEvaluations = new List<StudentEvaluation>();
        }
        public List<StudentEvaluation> StudentEvaluations { get; set; }
    }
}
