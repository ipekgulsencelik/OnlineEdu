using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IFeatureRepository : IRepository<Feature>
    {
        List<Feature> GetLast4Features();
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
    }
}