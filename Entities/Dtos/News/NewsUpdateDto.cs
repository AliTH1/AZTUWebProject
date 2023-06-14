namespace Entities.Dtos.News
{
    public class NewsUpdateDto
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
