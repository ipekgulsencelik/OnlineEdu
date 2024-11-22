using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface IBannerService : IGenericService<Banner>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
    }
}