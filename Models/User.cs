using System.Collections.Generic;

namespace mvc
{
    public class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            Adverts = new HashSet<Advert>();
            Models = new HashSet<Model>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdTypeUser { get; set; }
        // public TypeUser TypeUser { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Model> Models { get; set; }
        public virtual ICollection<Advert> Adverts { get; set; }
    }
}