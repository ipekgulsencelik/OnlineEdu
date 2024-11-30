using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IAboutRepository : IRepository<About>
    {
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
        About GetLastAbout();
    }
}