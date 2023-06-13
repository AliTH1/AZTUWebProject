namespace Entities.Dtos.Slider
{
    public class SliderUpdateDto
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }

}
