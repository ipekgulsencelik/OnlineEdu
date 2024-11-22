using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ICourseRepository : IRepository<Course>
    {
        List<Course> GetAllCoursesWithCategories();
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
    }
}