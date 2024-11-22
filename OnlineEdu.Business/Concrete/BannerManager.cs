using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class BannerManager : GenericManager<Banner>, IBannerService
    {
        private readonly IBannerRepository _bannerRepository;

        public BannerManager(IRepository<Banner> _repository, IBannerRepository bannerRepository) : base(_repository)
        {
            _bannerRepository = bannerRepository;
        }

        public void TDontShowOnHome(int id)
        {
            _bannerRepository.DontShowOnHome(id);
        }

        public void TShowOnHome(int id)
        {
            _bannerRepository.ShowOnHome(id);
        }
    }
}