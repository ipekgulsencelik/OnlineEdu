using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IBannerRepository : IRepository<Banner>
    {
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
    }
}