﻿using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class CourseManager : GenericManager<Course>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseManager(IRepository<Course> _repository, ICourseRepository courseRepository) : base(_repository)
        {
            _courseRepository = courseRepository;
        }

        public void TDontShowOnHome(int id)
        {
            _courseRepository.DontShowOnHome(id);
        }

        public List<Course> TGetAllCoursesWithCategories()
        {
            return _courseRepository.GetAllCoursesWithCategories();
        }

        public List<Course> TGetCoursesByTeacherID(int id)
        {
            return _courseRepository.GetCoursesByTeacherID(id);
        }

        public void TShowOnHome(int id)
        {
            _courseRepository.ShowOnHome(id);
        }
    }
}