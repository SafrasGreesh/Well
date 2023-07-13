using GazpromTest.Models;
using GazpromTest.Services;

namespace GazpromTest.Repo
{
    public class WellRepository : IWellRepository
    {
        private readonly ApplicationContext _context;

        public WellRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Well GetById(long id)
        {
            return _context.Wells.FirstOrDefault(w => w.Id == id);
        }

        public List<Well> GetAll()
        {
            return _context.Wells.ToList();
        }

        public void Add(Well well)
        {
            well.CreatedAt = DateTime.UtcNow;
            well.UpdatedAt = well.CreatedAt;
            _context.Wells.Add(well);
            _context.SaveChanges();
        }

        public void Update(Well well)
        {
            var existingWell = _context.Wells.Find(well.Id);
            if (existingWell != null)
            {
                existingWell.UpdatedAt = DateTime.UtcNow;
                _context.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            var well = _context.Wells.Find(id);
            if (well != null)
            {
                _context.Wells.Remove(well);
                _context.SaveChanges();
            }
        }
    }

}
