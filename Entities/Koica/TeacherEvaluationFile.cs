using Entities.Koica.SubjectMaterials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Koica
{
    public class TeacherEvaluationFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? EvaluationId { get; set; }
        public Evaluation Evaluation { get; set; }
    }
}
