using PlatformService.Model;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext _context)
        {
            this._context = _context;
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform != null)
            {

            }
            else
            {
                throw new ArgumentNullException(nameof(platform));
            }
        }

        public IEnumerable<Platform> GetAllPlatform()
        {
            var platforms = _context.Platforms.ToList();
            return platforms;
        }

        public Platform GetPlatformById(int id)
        {
            var platform = _context.Platforms.FirstOrDefault(p => p.Id == id);
            return platform;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}