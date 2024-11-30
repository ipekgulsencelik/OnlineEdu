using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    public class TeacherSocialMediaRepository : GenericRepository<TeacherSocialMedia>, ITeacherSocialMediaRepository
    {
        public TeacherSocialMediaRepository(OnlineEduContext context) : base(context)
        {
        }

        public void DontShowOnHome(int id)
        {
            var value = _context.TeacherSocialMedias.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

        public List<TeacherSocialMedia> GetLast3SocialMediasByTeacherID(int id)
        {
            return _context.TeacherSocialMedias.Where(x => x.TeacherSocialMediaID ==  id && x.IsShown).OrderByDescending(x => x.TeacherSocialMediaID).Take(3).ToList();
        }

        public void ShowOnHome(int id)
        {
            var value = _context.TeacherSocialMedias.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }
    }
}