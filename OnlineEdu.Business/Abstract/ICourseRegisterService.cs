using OnlineEdu.Entity.Entities;
using System.Linq.Expressions;

namespace OnlineEdu.Business.Abstract
{
    public interface ICourseRegisterService : IGenericService<CourseRegister>
    {
        List<CourseRegister> TGetAllWithCourseAndCategory(Expression<Func<CourseRegister, bool>> filter);
    }
}