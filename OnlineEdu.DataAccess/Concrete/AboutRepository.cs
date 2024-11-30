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

        public void DontShowOnHome(int id)
        {
            var value = _context.Abouts.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

        public About GetLastAbout()
        {
            return _context.Abouts.Where(x => x.IsShown).OrderByDescending(x => x.AboutID).FirstOrDefault();
        }

        public void ShowOnHome(int id)
        {
            var value = _context.Abouts.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }
    }
}
