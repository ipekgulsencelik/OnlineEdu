using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class AboutManager : GenericManager<About>, IAboutService
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutManager(IRepository<About> _repository, IAboutRepository aboutRepository) : base(_repository)
        {
            _aboutRepository = aboutRepository;
        }

        public void TDontShowOnHome(int id)
        {
            _aboutRepository.DontShowOnHome(id);
        }

        public About TGetLastAbout()
        {
            return _aboutRepository.GetLastAbout();
        }

        public void TShowOnHome(int id)
        {
            _aboutRepository.ShowOnHome(id);
        }
    }
}