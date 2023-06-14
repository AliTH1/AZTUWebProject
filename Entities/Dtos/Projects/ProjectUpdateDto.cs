namespace Entities.Dtos.Projects
{
    public class ProjectUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Url { get; set; }
    }
}
