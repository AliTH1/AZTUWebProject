using Entities.Account;
using Entities.Koica.SubjectMaterials;

namespace Entities.Koica
{
    public class StudentEvaluationFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Evaluation Evaluation { get; set; }
        public int? EvaluationId { get; set; }

        public StudentInfo StudentInfo { get; set; }
        public int? StudentInfoId { get; set; }
    }
}
