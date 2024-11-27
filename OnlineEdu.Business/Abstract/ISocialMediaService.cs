using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface ISocialMediaService : IGenericService<SocialMedia>
    {
        List<SocialMedia> TGetLast4SocialMedias();
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
    }
}