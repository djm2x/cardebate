using System;
using Microsoft.EntityFrameworkCore;
using mvc;


// dotnet ef dbcontext scaffold "data source=DESKTOP-3550K4L\HARMONY;database=rfid;user id=sa; password=123" Microsoft.EntityFrameworkCore.SqlServer -o Model -c "RfidContext"
namespace seed
{
    public static class DataSeeding
    {
        public static void AddRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role[]{
                new Role {Id = 1, Name = "users"},
                new Role {Id = 2, Name = "sa"},
                new Role {Id = 3, Name = "admins"},
            });
        }

        public static void AddSA(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]{
                new User
                {
                    Id = 1,
                    FullName = "sa",
                    Email = "sa@angular.io",
                    Password = "123",
                },
            });
        }

        public static void AddUsersRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(new UserRole[]{
                new UserRole { IdRole = 3, IdUser = 1},
            });
        }

        public static void AddCarburant(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carburant>().HasData(new Carburant[]{
                new Carburant { Id = 1, Name = "essence"},
                new Carburant { Id = 2, Name = "gasoile"},
            });
        }

        public static void AddCountry(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country[]{
                new Country
                {
                    Id = 1,
                    Name = "maroc",
                    ImageUrl = @"https://www.picclickimg.com/d/l400/pict/332053619138_/
                    Drapeau-Flag-vlag-Maroc-Morocco-Marokko-Marocain-Moroccan.jpg"
                },
                new Country
                {
                    Id = 2,
                    Name = "france",
                    ImageUrl = @"https://upload.wikimedia.org/wikipedia/commons/thumb/3/3a/Flag_of_France_%281794%E2%80%931815%2C
                    _1830%E2%80%931958%29.svg/250px-Flag_of_France_%281794%E2%80%931815%2C_1830%E2%80%931958%29.svg.png"
                },
                new Country
                {
                    Id = 3,
                    Name = "allemand",
                    ImageUrl = @"https://i.pinimg.com/originals/1a/46/32/1a4632aa90fd07b3eb59eb0c6b8419f9.jpg"
                },
            });
        }

        public static void AddTransmission(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transmission>().HasData(new Transmission[]{
                new Transmission { Id = 1, Name = "t1"},
                new Transmission { Id = 2, Name = "t2"},
                new Transmission { Id = 3, Name = "t3"},
                new Transmission { Id = 4, Name = "t4"},
            });
        }

        public static void AddTypeVoiture(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeVoiture>().HasData(new TypeVoiture[]{
                new TypeVoiture { Id = 1, Name = "type-1"},
                new TypeVoiture { Id = 2, Name = "type-2"},
                new TypeVoiture { Id = 3, Name = "type-3"},
                new TypeVoiture { Id = 4, Name = "type-4"},
            });
        }

        public static void AddMarque(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marque>().HasData(new Marque[]{
                new Marque
                {
                    Id = 1,
                    Name = "peugeot",
                    ImageUrl = "https://i.pinimg.com/236x/63/7c/fd/637cfd3724d8e5bc3ec9b2550a723d87--peugeot-logo-peugeot-.jpg",
                    IdCountry = 1
                },
                new Marque
                {
                    Id = 2,
                    Name = "mercedes",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/61VaoHj7IbL._SX425_.jpg",
                    IdCountry = 1
                },
                new Marque
                {
                    Id = 3,
                    Name = "ford",
                    ImageUrl = "https://images-eu.ssl-images-amazon.com/images/I/31vaJEpmCRL._AC_US218_.jpg",
                    IdCountry = 2
                },
                new Marque
                {
                    Id = 4,
                    Name = "volkswagen",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51v65ntrdXL._SX425_.jpg",
                    IdCountry = 2
                },
                new Marque
                {
                    Id = 5,
                    Name = "renault",
                    ImageUrl = "http://www.lorraine-automobiles.fr/wp/wp-content/uploads/2015/07/Renault-kadjar.png",
                    IdCountry = 3
                },
                new Marque
                {
                    Id = 6,
                    Name = "dacia",
                    ImageUrl = "https://ih0.redbubble.net/image.597289352.5586/raf,360x360,075,t,fafafa:ca443f4786.jpg",
                    IdCountry = 3
                },
            });
        }

        public static void AddModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>().HasData(new Model[]{
                new Model
                {
                    Id = "model1",
                    IdMarque = 1,
                    Annee = 2010,
                    Puissance = 4,
                    Reservoir = 2,
                    BoiteVitesse = 5,
                    FreinageUrgence = 1,
                    VitesseMax = 180,
                    Poid = 500,
                    Prix = 10000,
                    Autonomie = 1,
                    ConsVille = 1,
                    ConsRoute = 1,
                    ConsAutoroute = 1,
                    Cc = 1,
                    IdCarburant = 1,
                    IdTransmission = 1,
                    IdTypeVoiture = 1,
                    IdUser = 1,
                },
                new Model
                {
                    Id = "model2",
                    IdMarque = 1,
                    Annee = 2015,
                    Puissance = 5,
                    Reservoir = 1,
                    BoiteVitesse = 5,
                    FreinageUrgence = 1,
                    VitesseMax = 190,
                    Poid = 500,
                    Prix = 12000,
                    Autonomie = 1,
                    ConsVille = 1,
                    ConsRoute = 1,
                    ConsAutoroute = 1,
                    Cc = 1,
                    IdCarburant = 2,
                    IdTransmission = 3,
                    IdTypeVoiture = 3,
                    IdUser = 1,
                },
                new Model
                {
                    Id = "model3",
                    IdMarque = 2,
                    Annee = 2005,
                    Puissance = 5,
                    Reservoir = 3,
                    BoiteVitesse = 5,
                    FreinageUrgence = 1,
                    VitesseMax = 200,
                    Poid = 550,
                    Prix = 15000,
                    Autonomie = 1,
                    ConsVille = 1,
                    ConsRoute = 1,
                    ConsAutoroute = 1,
                    Cc = 1,
                    IdCarburant = 2,
                    IdTransmission = 2,
                    IdTypeVoiture = 2,
                    IdUser = 1,
                },
                new Model
                {
                    Id = "model4",
                    IdMarque = 2,
                    Annee = 1995,
                    Puissance = 5,
                    Reservoir = 3,
                    BoiteVitesse = 5,
                    FreinageUrgence = 1,
                    VitesseMax = 150,
                    Poid = 550,
                    Prix = 15000,
                    Autonomie = 1,
                    ConsVille = 1,
                    ConsRoute = 1,
                    ConsAutoroute = 1,
                    Cc = 1,
                    IdCarburant = 2,
                    IdTransmission = 2,
                    IdTypeVoiture = 2,
                    IdUser = 1,
                },
                new Model
                {
                    Id = "model5",
                    IdMarque = 3,
                    Annee = 2018,
                    Puissance = 7,
                    Reservoir = 4,
                    BoiteVitesse = 5,
                    FreinageUrgence = 1,
                    VitesseMax = 250,
                    Poid = 550,
                    Prix = 20000,
                    Autonomie = 1,
                    ConsVille = 1,
                    ConsRoute = 1,
                    ConsAutoroute = 1,
                    Cc = 1,
                    IdCarburant = 1,
                    IdTransmission = 2,
                    IdTypeVoiture = 2,
                    IdUser = 1,
                },
                new Model
                {
                    Id = "model6",
                    IdMarque = 3,
                    Annee = 2008,
                    Puissance = 5,
                    Reservoir = 4,
                    BoiteVitesse = 5,
                    FreinageUrgence = 1,
                    VitesseMax = 250,
                    Poid = 450,
                    Prix = 18000,
                    Autonomie = 1,
                    ConsVille = 1,
                    ConsRoute = 1,
                    ConsAutoroute = 1,
                    Cc = 1,
                    IdCarburant = 1,
                    IdTransmission = 2,
                    IdTypeVoiture = 2,
                    IdUser = 1,
                },
                new Model
                {
                    Id = "model7",
                    IdMarque = 4,
                    Annee = 2013,
                    Puissance = 5,
                    Reservoir = 4,
                    BoiteVitesse = 5,
                    FreinageUrgence = 1,
                    VitesseMax = 280,
                    Poid = 750,
                    Prix = 28000,
                    Autonomie = 1,
                    ConsVille = 1,
                    ConsRoute = 1,
                    ConsAutoroute = 1,
                    Cc = 1,
                    IdCarburant = 2,
                    IdTransmission = 4,
                    IdTypeVoiture = 2,
                    IdUser = 1,
                },
                new Model
                {
                    Id = "model8",
                    IdMarque = 4,
                    Annee = 2015,
                    Puissance = 5,
                    Reservoir = 4,
                    BoiteVitesse = 5,
                    FreinageUrgence = 1,
                    VitesseMax = 200,
                    Poid = 550,
                    Prix = 22000,
                    Autonomie = 1,
                    ConsVille = 1,
                    ConsRoute = 1,
                    ConsAutoroute = 1,
                    Cc = 1,
                    IdCarburant = 1,
                    IdTransmission = 4,
                    IdTypeVoiture = 3,
                    IdUser = 1,
                },
                new Model
                {
                    Id = "model9",
                    IdMarque = 5,
                    Annee = 2011,
                    Puissance = 5,
                    Reservoir = 4,
                    BoiteVitesse = 5,
                    FreinageUrgence = 1,
                    VitesseMax = 200,
                    Poid = 500,
                    Prix = 18000,
                    Autonomie = 1,
                    ConsVille = 1,
                    ConsRoute = 1,
                    ConsAutoroute = 1,
                    Cc = 1,
                    IdCarburant = 2,
                    IdTransmission = 4,
                    IdTypeVoiture = 3,
                    IdUser = 1,
                },
                new Model
                {
                    Id = "model10",
                    IdMarque = 5,
                    Annee = 2014,
                    Puissance = 5,
                    Reservoir = 4,
                    BoiteVitesse = 5,
                    FreinageUrgence = 1,
                    VitesseMax = 230,
                    Poid = 520,
                    Prix = 21000,
                    Autonomie = 1,
                    ConsVille = 1,
                    ConsRoute = 1,
                    ConsAutoroute = 1,
                    Cc = 1,
                    IdCarburant = 2,
                    IdTransmission = 4,
                    IdTypeVoiture = 3,
                    IdUser = 1,
                },
                new Model
                {
                    Id = "model11",
                    IdMarque = 6,
                    Annee = 2019,
                    Puissance = 9,
                    Reservoir = 8,
                    BoiteVitesse = 8,
                    FreinageUrgence = 3,
                    VitesseMax = 400,
                    Poid = 620,
                    Prix = 40000,
                    Autonomie = 1,
                    ConsVille = 1,
                    ConsRoute = 1,
                    ConsAutoroute = 1,
                    Cc = 1,
                    IdCarburant = 2,
                    IdTransmission = 4,
                    IdTypeVoiture = 4,
                    IdUser = 1,
                },
                new Model
                {
                    Id = "model12",
                    IdMarque = 6,
                    Annee = 2017,
                    Puissance = 7,
                    Reservoir = 6,
                    BoiteVitesse = 6,
                    FreinageUrgence = 2,
                    VitesseMax = 300,
                    Poid = 560,
                    Prix = 32000,
                    Autonomie = 1,
                    ConsVille = 1,
                    ConsRoute = 1,
                    ConsAutoroute = 1,
                    Cc = 1,
                    IdCarburant = 1,
                    IdTransmission = 4,
                    IdTypeVoiture = 4,
                    IdUser = 1,
                },
            });
        }

        public static void AddModelImg(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelImg>().HasData(new ModelImg[]{
                new ModelImg 
                { 
                    Id = 1, 
                    IdModel = "model1",
                    ImageUrl = "https://media.peugeot.co.uk/image/21/6/carousel-thumbnail-1.415216.6.png?autocrop=1",
                },
                new ModelImg 
                { 
                    Id = 2, 
                    IdModel = "model1",
                    ImageUrl = "https://www.evanshalshaw.com/images/218994/1465584/1465625/all-new-peugeot-3008.jpg?view=Standard",
                },
                new ModelImg 
                { 
                    Id = 3, 
                    IdModel = "model2",
                    ImageUrl = "https://media.peugeot.co.uk/image/52/9/308-cc-past-model.141529.141529.6.jpg?autocrop=1",
                },
                new ModelImg 
                { 
                    Id = 4, 
                    IdModel = "model2",
                    ImageUrl = "http://stat.overdrive.in/wp-content/uploads/2017/07/2017-Peugeot-208.jpg",
                },
                //
                new ModelImg 
                { 
                    Id = 5, 
                    IdModel = "model3",
                    ImageUrl = "https://hips.hearstapps.com/amv-prod-cad-assets.s3.amazonaws.com/vdat/submodels/mercedes-benz_a-class_mercedes-benz-a-class_2019-1532641693802.jpg",
                },
                new ModelImg 
                { 
                    Id = 6, 
                    IdModel = "model3",
                    ImageUrl = "http://cdn.24.co.za/files/Cms/General/d/7694/8698760d7b4c4b0b8802ec459b520882.jpg",
                },
                new ModelImg 
                { 
                    Id = 7, 
                    IdModel = "model4",
                    ImageUrl = "https://www.cstatic-images.com/car-pictures/main/USC90MBCCC1A021001.png",
                },
                new ModelImg 
                { 
                    Id = 8, 
                    IdModel = "model4",
                    ImageUrl = "https://img.timesnownews.com/media/1537969007-Badshah_Mercedes_GL350.jpg?d=600x450",
                },
                //
                new ModelImg 
                { 
                    Id = 9, 
                    IdModel = "model5",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ0zeM9VJvumpJclkUO7YtDPqxtZimAZ4HsmbgfJxp6YTeu81ZK",
                },
                new ModelImg 
                { 
                    Id = 10, 
                    IdModel = "model5",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQDkmYO36lEpqblJOIbbzK4pQQ9uYaqm7T8GkQDyUMe9SqQ0b3y",
                },
                new ModelImg 
                { 
                    Id = 11, 
                    IdModel = "model6",
                    ImageUrl = "https://hips.hearstapps.com/amv-prod-cad-assets.s3.amazonaws.com/vdat/submodels/ford_fusion_ford-fusion_2019-1546985124643.jpg",
                },
                new ModelImg 
                { 
                    Id = 12, 
                    IdModel = "model6",
                    ImageUrl = "https://images.netdirector.co.uk/gforces-auto/image/upload/w_375,h_211,q_auto,c_fill,f_auto,fl_lossy/auto-client/d4e63030c0ae91f4791d72f4d839fb45/w9238618_ecos_cca_titan_34frntpassmtnlghtnngblue_mj.jpg",
                },
                //
                new ModelImg 
                { 
                    Id = 13, 
                    IdModel = "model7",
                    ImageUrl = "https://hips.hearstapps.com/amv-prod-cad-assets.s3.amazonaws.com/media/assets/submodel/8045.jpg",
                },
                new ModelImg 
                { 
                    Id = 14, 
                    IdModel = "model7",
                    ImageUrl = "https://www.volkswagen.co.uk/files/live/sites/vwuk/files/Used/Used_MLPs/all%20models/more%20images/passat%20estate%202015-present.png",
                },
                new ModelImg 
                { 
                    Id = 15, 
                    IdModel = "model8",
                    ImageUrl = "http://i4.aroq.com/3/2019-01-08-14-03-volkswagenpassatchinesespec_cropped_90.jpg",
                },
                new ModelImg 
                { 
                    Id = 16, 
                    IdModel = "model8",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSK25SOfav7clQLuQNJC8owhle7OoQ_C5hLTGEkrmv9UBJCsma13w",
                },
                //
                new ModelImg 
                { 
                    Id = 17, 
                    IdModel = "model9",
                    ImageUrl = "https://api.stoneacremotorgroup.co.uk/sites/default/files/renault-used-cars.png",
                },
                new ModelImg 
                { 
                    Id = 18, 
                    IdModel = "model9",
                    ImageUrl = "https://stimg.cardekho.com/images/carexteriorimages/360x240/Renault/Renault-Scala/047.jpg",
                },
                new ModelImg 
                { 
                    Id = 19, 
                    IdModel = "model10",
                    ImageUrl = "https://auto.ndtvimg.com/car-images/big/renault/captur/renault-captur.jpg?v=19",
                },
                new ModelImg 
                { 
                    Id = 20, 
                    IdModel = "model10",
                    ImageUrl = "https://auto.ndtvimg.com/car-images/big/renault/duster/renault-duster.jpg?v=27",
                },
                //
                new ModelImg 
                { 
                    Id = 21, 
                    IdModel = "model11",
                    ImageUrl = "https://d1ek71enupal89.cloudfront.net/images/blocks_png/DACIA/SANDERO/5DR/17DacSanAmb5drBluFL1_800.jpg",
                },
                new ModelImg 
                { 
                    Id = 22, 
                    IdModel = "model11",
                    ImageUrl = "https://images.netdirector.co.uk/gforces-auto/image/upload/w_200,h_113,dpr_2.0,q_auto,c_fill,f_auto,fl_lossy/auto-client/06b3f63486340a35d13fb1ef7ebd26af/sandero_2013_exterior_03.jpg",
                },
                new ModelImg 
                { 
                    Id = 23, 
                    IdModel = "model12",
                    ImageUrl = "https://imgix.ranker.com/node_img/1579/31577061/original/dacia-sandero-automobile-models-photo-1?w=650&q=50&fm=pjpg&fit=crop&crop=faces",
                },
                new ModelImg 
                { 
                    Id = 24, 
                    IdModel = "model12",
                    ImageUrl = "https://toomey.imgix.net/used-vehicle-photos/1/EO16HLR-1_20190412.jpg?fit=crop&max-w=480&max-h=320",
                },
            });
        }
    }
}