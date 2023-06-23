namespace Entities.Koica.SubjectMaterials
{
    public class Forum
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public int NumOfApplications { get; set; } = 0;
        public string? FilePath { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

    }
}
