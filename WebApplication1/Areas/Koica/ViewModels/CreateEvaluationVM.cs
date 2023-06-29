using Entities.Koica;

namespace WebApplication1.Areas.Koica.ViewModels
{
    public class CreateEvaluationVM
    {
        public string TypeOfTeaching { get; set; }
        public byte EvaluationStudent { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime End { get; set; }
        public string FilePath { get; set; }
        public int SubjectId { get; set; }
        public int RouteId { get; set; }
    }
}