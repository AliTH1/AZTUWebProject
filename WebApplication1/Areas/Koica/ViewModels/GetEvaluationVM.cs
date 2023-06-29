namespace WebApplication1.Areas.Koica.ViewModels
{
    public class GetEvaluationVM
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public string TypeOfTeaching { get; set; }
        public string? FilePath { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int RouteId { get; set; }
    }
}
