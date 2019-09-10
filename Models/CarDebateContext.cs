using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using seed;

namespace mvc
{
    public partial class CarDebateContext : DbContext
    {
        public CarDebateContext()
        {
            // scafolding to db
            // dotnet ef migrations add secondMG
            // dotnet ef database update
            // dotnet ef migrations remove
            // dotnet ef database update LastGoodMigration
            // dotnet ef migrations script
        }

        public CarDebateContext(DbContextOptions<CarDebateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        // public virtual DbSet<TypeUser> TypeUsers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Advert> Adverts { get; set; }
        public virtual DbSet<AdvertModelImg> AdvertModelImgs { get; set; }
        public virtual DbSet<ModelImg> ModelImgs { get; set; }
        public virtual DbSet<Carburant> Carburants { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Marque> Marques { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Transmission> Transmissions { get; set; }
        public virtual DbSet<TypeVoiture> TypeVoitures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<User>()
                        .HasIndex(o => o.Email)
                        .IsUnique(true);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.FullName).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                // entity.Property(e => e.Tel).IsRequired();
                // entity.Property(e => e.Address).IsRequired().HasMaxLength(250);
                entity.Property(d => d.IdTypeUser).IsRequired();
                // entity.HasOne(d => d.TypeUser).WithMany(p => p.Users).HasForeignKey(d => d.IdTypeUser);
                entity.HasMany(c => c.Adverts)
                    .WithOne(e => e.User)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(c => c.UserRoles)
                    .WithOne(e => e.User)
                    .OnDelete(DeleteBehavior.Cascade);  
                entity.HasMany(c => c.Models)
                    .WithOne(e => e.User)
                    .OnDelete(DeleteBehavior.Cascade);  
            });

            // modelBuilder.Entity<TypeUser>(entity =>
            // {
            //     entity.HasKey(e => e.Id);
            //     entity.Property(e => e.Id).ValueGeneratedOnAdd();
            //     entity.Property(e => e.Name).IsRequired();
            //     entity.HasMany(c => c.Users)
            //         .WithOne(e => e.TypeUser)
            //         .OnDelete(DeleteBehavior.Cascade);
            // });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.HasMany(c => c.UserRoles)
                    .WithOne(e => e.Role)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.IdRole, e.IdUser });
                entity.HasOne(d => d.Role).WithMany(p => p.UserRoles).HasForeignKey(d => d.IdRole);
                entity.HasOne(d => d.User).WithMany(p => p.UserRoles).HasForeignKey(d => d.IdUser);
            });

            modelBuilder.Entity<Carburant>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.HasMany(c => c.Models)
                    .WithOne(e => e.Carburant)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                // entity.Property(e => e.ImageUrl).IsRequired();
                entity.HasMany(c => c.Marques)
                    .WithOne(e => e.Country)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Marque>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.ImageUrl).IsRequired();
                entity.Property(e => e.IdCountry).IsRequired();
                entity.HasOne(d => d.Country).WithMany(p => p.Marques).HasForeignKey(d => d.IdCountry);
                entity.HasMany(c => c.Models)
                    .WithOne(e => e.Marque)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ModelImg>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.ImageUrl).IsRequired();
                entity.Property(e => e.IdModel).IsRequired();
                entity.HasOne(d => d.Model).WithMany(p => p.ModelImgs).HasForeignKey(d => d.IdModel);
            });

            modelBuilder.Entity<Advert>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.IdUser).IsRequired();
                entity.Property(e => e.DateAdvert).HasDefaultValue(DateTime.Now);
                entity.Property(e => e.DateSell).HasDefaultValue(DateTime.Now);
                entity.Property(e => e.state).HasDefaultValue(false);
                entity.Property(e => e.Prix).IsRequired();
                entity.Property(e => e.Km).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.AnneModel).IsRequired();
                entity.HasOne(d => d.Model).WithMany(p => p.Adverts).HasForeignKey(d => d.IdModel);
                entity.HasOne(d => d.User).WithMany(p => p.Adverts).HasForeignKey(d => d.IdUser);
                entity.HasMany(c => c.AdvertModelImgs)
                    .WithOne(e => e.Advert)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AdvertModelImg>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.ImageUrl).IsRequired();
                entity.Property(e => e.IdAdvert).IsRequired();
                entity.HasOne(d => d.Advert).WithMany(p => p.AdvertModelImgs).HasForeignKey(d => d.IdAdvert);
            });

            modelBuilder.Entity<Transmission>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.HasMany(c => c.Models)
                    .WithOne(e => e.Transmission)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TypeVoiture>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.HasMany(c => c.Models)
                    .WithOne(e => e.TypeVoiture)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Annee).IsRequired().HasMaxLength(4);
                entity.Property(e => e.IdMarque).IsRequired();
                entity.Property(e => e.Puissance).IsRequired();
                entity.Property(e => e.Reservoir).IsRequired();
                entity.Property(e => e.BoiteVitesse).IsRequired();
                entity.Property(e => e.FreinageUrgence).IsRequired();
                entity.Property(e => e.VitesseMax).IsRequired();
                entity.Property(e => e.Poid).IsRequired();
                entity.Property(e => e.Prix).IsRequired();
                entity.Property(e => e.Autonomie).IsRequired();
                entity.Property(e => e.ConsVille).IsRequired();
                entity.Property(e => e.ConsRoute).IsRequired();
                entity.Property(e => e.ConsAutoroute).IsRequired();
                entity.Property(e => e.Cc).IsRequired();
                entity.Property(e => e.IdCarburant).IsRequired();
                entity.Property(e => e.IdTransmission).IsRequired();
                entity.Property(e => e.IdTypeVoiture).IsRequired();
                entity.Property(e => e.IdUser).HasDefaultValue(null);

                entity.HasOne(d => d.Carburant)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.IdCarburant);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.IdUser);

                entity.HasMany(c => c.ModelImgs)
                    .WithOne(e => e.Model)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Marque)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.IdMarque);

                entity.HasOne(d => d.Transmission)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.IdTransmission);

                entity.HasOne(d => d.TypeVoiture)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.IdTypeVoiture);
            });

            modelBuilder.AddRoles();
            modelBuilder.AddSA();
            modelBuilder.AddUsersRole();
            modelBuilder.AddCarburant();
            modelBuilder.AddCountry();
            modelBuilder.AddTransmission();
            modelBuilder.AddTypeVoiture();
            modelBuilder.AddMarque();
            modelBuilder.AddModel();
            modelBuilder.AddModelImg();
        }
    }
}
