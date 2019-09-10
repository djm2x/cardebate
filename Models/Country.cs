using System;
using System.Collections.Generic;

namespace mvc
{
    public partial class Country
    {
        public Country()
        {
            Marques = new HashSet<Marque>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Marque> Marques { get; set; }
    }
}
