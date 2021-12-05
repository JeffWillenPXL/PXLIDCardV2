using PXLIDCardV2.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXLIDCardV2.business.Contracts
{
    public interface IStudentService
    {
        Task<IList<StudentEvaluationAttendence>> GetEvaluationsForStudent(int studentId);
    }
}
