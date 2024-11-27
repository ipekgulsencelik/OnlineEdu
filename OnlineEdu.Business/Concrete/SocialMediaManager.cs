using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class SocialMediaManager : GenericManager<SocialMedia>, ISocialMediaService
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public SocialMediaManager(IRepository<SocialMedia> _repository, ISocialMediaRepository socialMediaRepository) : base(_repository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public void TDontShowOnHome(int id)
        {
            _socialMediaRepository.DontShowOnHome(id);
        }

        public List<SocialMedia> TGetLast4SocialMedias()
        {
            return _socialMediaRepository.GetLast4SocialMedias();
        }

        public void TShowOnHome(int id)
        {
            _socialMediaRepository.ShowOnHome(id);
        }
    }
}