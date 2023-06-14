namespace Entities.Dtos.News
{
    public class NewsGetDto
    {
        public string Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsMain { get; set; }
        public string Url { get; set; }
    }
}
