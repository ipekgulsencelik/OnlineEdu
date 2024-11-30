using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface IFeatureService : IGenericService<Feature>
    {
        List<Feature> TGetLast4Features();
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
    }
}