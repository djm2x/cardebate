using System;
using System.Collections.Generic;

namespace mvc
{
    public class Advert
    {
        public Advert()
        {
            AdvertModelImgs = new HashSet<AdvertModelImg>();
        }
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Description { get; set; }
        public double Prix { get; set; }
        public double Km { get; set; }
        public string IdModel { get; set; }
        public DateTime DateAdvert { get; set; }
        public DateTime DateSell { get; set; }
        public int AnneModel { get; set; }
        public bool state { get; set; }
        public User User { get; set; }
        public Model Model { get; set; }
        public virtual ICollection<AdvertModelImg> AdvertModelImgs { get; set; }
    }
}