using Entities.Koica;

namespace WebApplication1.Areas.Koica.ViewModels
{
    public class GetSubjectVM
    {
		public int Id { get; set; }
		public string Topic { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
		public string? FilePath { get; set; }
		public DateTime Date { get; set; }
    }
}
