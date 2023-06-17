namespace Entities.Account
{
    public class TeacherInfo
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Profession { get; set; }
        public string Degree { get; set; }
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
