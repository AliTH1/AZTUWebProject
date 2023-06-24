using Entities.Koica;

namespace WebApplication1.Areas.Koica.ViewModels
{
    public class GetForumVM
    {
        public string Topic { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
    }
}
