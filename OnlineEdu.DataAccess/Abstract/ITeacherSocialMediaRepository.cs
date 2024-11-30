using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ITeacherSocialMediaRepository : IRepository<TeacherSocialMedia>
    {
        List<TeacherSocialMedia> GetLast3SocialMediasByTeacherID(int id);
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
    }
}