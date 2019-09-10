
using System.Threading.Tasks;
using mvc;

namespace Repository.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarDebateContext _context;

        public UnitOfWork(CarDebateContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Models = new ModelRepository(_context);
            UserRoles = new UserRoleRepository(_context);
            Marques = new Repository<Marque>(_context);
            Countries = new Repository<Country>(_context);
            Carburants = new Repository<Carburant>(_context);
            Roles = new Repository<Role>(_context);
            ModelImgs = new ModelImgRepository(_context);
            AdvertModelImgs = new Repository<AdvertModelImg>(_context);
            Adverts = new Repository<Advert>(_context);
            Transmissions = new Repository<Transmission>(_context);
            TypeVoitures = new Repository<TypeVoiture>(_context);
            // TypeUsers = new Repository<TypeUser>(_context);
        }
        public IUserRepository Users { get; private set; }
        // public IRepository<TypeUser> TypeUsers { get; private set; }
        public IModelRepository Models { get; private set; }
        public IUserRoleRepository UserRoles { get; private set; }
        public IRepository<Marque> Marques { get; private set; }
        public IRepository<Country> Countries { get; private set; }
        public IRepository<Carburant> Carburants { get; private set; }
        public IRepository<Role> Roles { get; private set; }
        public IModelImgRepository ModelImgs { get; private set; }
        public IRepository<AdvertModelImg> AdvertModelImgs { get; private set; }
        public IRepository<Advert> Adverts { get; private set; }
        public IRepository<Transmission> Transmissions { get; private set; }
        public IRepository<TypeVoiture> TypeVoitures { get; private set; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}