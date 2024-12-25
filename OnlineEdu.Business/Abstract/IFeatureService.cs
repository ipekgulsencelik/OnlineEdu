using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface IFeatureService : IGenericService<Feature>
    {
        List<Feature> TGetLast4Features();
        List<Feature> TGetAllFeatures();
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
    }
}