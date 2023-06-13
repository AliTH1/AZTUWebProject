namespace Entities.Dtos.Service
{
    public class ServiceUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }
    }

}
