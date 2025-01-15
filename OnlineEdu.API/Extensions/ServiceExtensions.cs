using OnlineEdu.Business.Abstract;
using OnlineEdu.Business.Concrete;
using OnlineEdu.Business.Configurations;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Concrete;
using OnlineEdu.DataAccess.Repositories;

namespace OnlineEdu.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServiceExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IAboutService, AboutManager>();

            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IBannerService, BannerManager>();

            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogService, BlogManager>();

            services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();
            services.AddScoped<IBlogCategoryService, BlogCategoryManager>();

            services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
            services.AddScoped<ICourseCategoryService, CourseCategoryManager>();

            services.AddScoped<ICourseRegisterRepository, CourseRegisterRepository>();
            services.AddScoped<ICourseRegisterService, CourseRegisterManager>();

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseManager>();

            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IFeatureService, FeatureManager>();

            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();

            services.AddScoped<ITeacherSocialMediaRepository, TeacherSocialMediaRepository>();
            services.AddScoped<ITeacherSocialMediaService, TeacherSocialMediaManager>();

            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<ITestimonialService, TestimonialManager>();

            services.Configure<JwtTokenOptions>(configuration.GetSection("TokenOptions"));

            services.AddScoped<IJwtService, JwtService>();

            services.AddScoped<IUserService, UserService>();
        }
    }
}