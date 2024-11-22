using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IAboutRepository : IRepository<About>
    {
        List<About> GetAboutWithFeatures();
        List<About> GetAboutWithLast2Images();
    }
}