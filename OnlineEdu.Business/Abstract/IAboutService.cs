using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface IAboutService : IGenericService<About>
    {
        List<About> TGetAboutWithFeatures();
        List<About> TGetAboutWithLast2Images();
    }
}