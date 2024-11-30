using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface IAboutService : IGenericService<About>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
        About TGetLastAbout();
    }
}