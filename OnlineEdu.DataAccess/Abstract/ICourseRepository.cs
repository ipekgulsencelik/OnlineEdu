using OnlineEdu.Entity.Entities;
using System.Linq.Expressions;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ICourseRepository : IRepository<Course>
    {
        List<Course> GetAllCoursesWithCategories();
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
        List<Course> GetAllCoursesWithCategories(Expression<Func<Course, bool>> filter = null);
        List<Course> GetCoursesByTeacherID(int id);
    }
}