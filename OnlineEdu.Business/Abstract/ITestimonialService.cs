using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface ITestimonialService : IGenericService<Testimonial>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
    }
}