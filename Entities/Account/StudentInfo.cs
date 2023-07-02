using Entities.Koica.SubjectMaterials;
using Entities.Koica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Account
{
    public class StudentInfo
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Group { get; set; }
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }


        public List<StudentEvaluationFile> StudentEvaluationFiles { get; set; }

        public List<Evaluation> Evaluations { get; set; }
        public List<StudentEvaluation> StudentEvaluations { get; set; }

    }
}
