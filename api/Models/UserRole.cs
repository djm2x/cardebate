namespace mvc
{
    public class UserRole
    {
        public int IdUser { get; set; }
        public int IdRole { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}