using System;
using System.Collections.Generic;

namespace mvc
{
    public partial class Marque
    {
        public Marque()
        {
            Models = new HashSet<Model>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int IdCountry { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Model> Models { get; set; }
    }
}
