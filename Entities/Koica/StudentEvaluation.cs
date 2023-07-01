using Entities.Account;
using Entities.Koica.SubjectMaterials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Koica
{
    public class StudentEvaluation
    {
        public int EvaluationId { get; set; }
        public int StudentInfoId { get; set; }

        public Evaluation Evaluation { get; set; }
        public StudentInfo StudentInfo { get; set; }

        public byte? Grade { get; set; }
    }
}
