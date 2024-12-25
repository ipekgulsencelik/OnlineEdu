using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IFeatureRepository : IRepository<Feature>
    {
        List<Feature> GetLast4Features();
        List<Feature> GetAllFeatures();
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
    }
}