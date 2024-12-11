﻿using OnlineEdu.Entity.Entities;
using System.Linq.Expressions;

namespace OnlineEdu.Business.Abstract
{
    public interface ICourseService : IGenericService<Course>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
        List<Course> TGetAllCoursesWithCategories();
        List<Course> TGetAllCoursesWithCategories(Expression<Func<Course, bool>> filter = null);
        List<Course> TGetCoursesByTeacherID(int id);
    }
}