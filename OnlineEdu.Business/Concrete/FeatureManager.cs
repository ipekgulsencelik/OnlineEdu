using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class FeatureManager : GenericManager<Feature>, IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureManager(IRepository<Feature> _repository, IFeatureRepository featureRepository) : base(_repository)
        {
            _featureRepository = featureRepository;
        }

        public void TDontShowOnHome(int id)
        {
            _featureRepository.DontShowOnHome(id);
        }

        public List<Feature> TGetAllFeatures()
        {
            return _featureRepository.GetAllFeatures();
        }

        public List<Feature> TGetLast4Features()
        {
            return _featureRepository.GetLast4Features();
        }

        public void TShowOnHome(int id)
        {
            _featureRepository.ShowOnHome(id);
        }
    }
}