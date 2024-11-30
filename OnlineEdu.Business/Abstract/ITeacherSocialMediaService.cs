using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface ITeacherSocialMediaService : IGenericService<TeacherSocialMedia>
    {
        List<TeacherSocialMedia> TGetLast3SocialMediasByTeacherID(int id);
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
    }
}