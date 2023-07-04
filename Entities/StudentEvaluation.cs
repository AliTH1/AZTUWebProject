using Entities.Account;
using Entities.Koica.SubjectMaterials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class StudentEvaluation
    {
        public int StudentInfoId { get; set; }
        public int EvaluationId { get; set; }

        public byte? Grade { get; set; }


        public Evaluation Evaluation { get; set; }
    }
}
