namespace OnlineEdu.API.Mappings
{
    public class CourseRegisterMapping : Profile
    {
        public CourseRegisterMapping()
        {
            CreateMap<CourseRegister, ResultCourseRegisterDTO>().ReverseMap();
            CreateMap<CourseRegister, CreateCourseRegisterDTO>().ReverseMap();
            CreateMap<CourseRegister, UpdateCourseRegisterDTO>().ReverseMap();
        }
    }
}