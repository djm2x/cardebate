using System;
using System.Collections.Generic;

namespace mvc
{
    public partial class TypeVoiture
    {
        public TypeVoiture()
        {
            Models = new HashSet<Model>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
