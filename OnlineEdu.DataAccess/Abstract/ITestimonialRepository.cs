using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ITestimonialRepository : IRepository<Testimonial>
    {
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
    }
}