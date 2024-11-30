﻿using OnlineEdu.Business.Abstract;
using OnlineEdu.Business.Concrete;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Concrete;
using OnlineEdu.DataAccess.Repositories;

namespace OnlineEdu.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServiceExtensions(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IBannerService, BannerManager>();

            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogService, BlogManager>();

            services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
            services.AddScoped<ICourseCategoryService, CourseCategoryManager>();

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseManager>();

            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();

            services.AddScoped<ITeacherSocialMediaRepository, TeacherSocialMediaRepository>();
            services.AddScoped<ITeacherSocialMediaService, TeacherSocialMediaManager>();

            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<ITestimonialService, TestimonialManager>();
        }
    }
}