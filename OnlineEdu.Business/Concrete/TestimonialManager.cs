using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class TestimonialManager : GenericManager<Testimonial>, ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialManager(IRepository<Testimonial> _repository, ITestimonialRepository testimonialRepository) : base(_repository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public void TDontShowOnHome(int id)
        {
            _testimonialRepository.DontShowOnHome(id);
        }

        public void TShowOnHome(int id)
        {
            _testimonialRepository.ShowOnHome(id);
        }
    }
}