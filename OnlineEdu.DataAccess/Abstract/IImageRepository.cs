using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IImageRepository : IRepository<Image>
    {
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
    }
}