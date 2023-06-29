namespace WebApplication1.Areas.Koica.ViewModels
{
    public class CreateSubjectVM
    {
        public int SubjectId { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public int RouteId { get; set; }
        public IFormFile? File { get; set; }
    }
}