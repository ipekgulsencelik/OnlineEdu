using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    public class SocialMediaRepository : GenericRepository<SocialMedia>, ISocialMediaRepository
    {
        public SocialMediaRepository(OnlineEduContext context) : base(context)
        {
        }

        public void DontShowOnHome(int id)
        {
            var value = _context.SocialMedias.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

        public List<SocialMedia> GetLast4SocialMedias()
        {
            return _context.SocialMedias.Where(x => x.IsShown).OrderByDescending(x => x.SocialMediaID).Take(4).ToList();
        }

        public void ShowOnHome(int id)
        {
            var value = _context.SocialMedias.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }
    }
}