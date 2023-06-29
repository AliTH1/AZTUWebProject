namespace Entities.Koica.SubjectMaterials
{
    public class Evaluation
    {
        public int Id { get; set; }
        public string TypeOfTeaching { get; set; }
        public byte EvaluationStudent { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string? FilePath { get; set; }
        public int SubjectId { get; set; }
		public Subject Subject { get; set; }
        public TeacherEvaluationFile TeacherEvaluationFile { get; set; }
        public StudentEvaluationFile StudentEvaluationFile { get; set; }
    }
}