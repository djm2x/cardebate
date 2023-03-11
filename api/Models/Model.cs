using System;
using System.Collections.Generic;

namespace mvc
{
    public partial class Model
    {
        public Model()
        {
            ModelImgs = new HashSet<ModelImg>();
            Adverts = new HashSet<Advert>();
        }
        public string Id { get; set; }
        public int IdMarque { get; set; }
        public int Annee { get; set; }
        public int Puissance { get; set; }
        public float Reservoir { get; set; }
        public int BoiteVitesse { get; set; }
        public float FreinageUrgence { get; set; }
        public float VitesseMax { get; set; }
        public float Poid { get; set; }
        public float Prix { get; set; }
        public int Autonomie { get; set; }
        public float ConsVille { get; set; }
        public float ConsRoute { get; set; }
        public float ConsAutoroute { get; set; }
        public int Cc { get; set; }
        public int IdCarburant { get; set; }
        public int IdTransmission { get; set; }
        public int IdTypeVoiture { get; set; }
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        public virtual Carburant Carburant { get; set; }
        public virtual Marque Marque { get; set; }
        public virtual Transmission Transmission { get; set; }
        public virtual TypeVoiture TypeVoiture { get; set; }
        public virtual ICollection<ModelImg> ModelImgs { get; set; }
        public virtual ICollection<Advert> Adverts { get; set; }
    }
}
