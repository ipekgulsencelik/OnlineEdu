using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    public class AboutRepository : GenericRepository<About>, IAboutRepository
    {
        public AboutRepository(OnlineEduContext _context) : base(_context)
        {

        }

        public List<About> GetAboutWithFeatures()
        {
            return _context.Abouts.Include(x => x.Features).ToList();
        }

        public List<About> GetAboutWithLast2Images()
        {
            return _context.Abouts.Include(x => x.Images).OrderByDescending(x => x.Images).Take(2).ToList();
        }
    }
}
