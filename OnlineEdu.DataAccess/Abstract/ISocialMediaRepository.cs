using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ISocialMediaRepository : IRepository<SocialMedia>
    {
        List<SocialMedia> GetLast4SocialMedias();
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
    }
}