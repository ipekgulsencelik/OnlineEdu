using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface IFeatureService : IGenericService<Feature>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
    }
}