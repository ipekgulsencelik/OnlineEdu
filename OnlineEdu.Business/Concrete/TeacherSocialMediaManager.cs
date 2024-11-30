using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class TeacherSocialMediaManager : GenericManager<TeacherSocialMedia>, ITeacherSocialMediaService
    {
        private readonly ITeacherSocialMediaRepository _teacherSocialMediaRepository;

        public TeacherSocialMediaManager(IRepository<TeacherSocialMedia> _repository, ITeacherSocialMediaRepository teacherSocialMediaRepository) : base(_repository)
        {
            _teacherSocialMediaRepository = teacherSocialMediaRepository;
        }

        public void TDontShowOnHome(int id)
        {
            _teacherSocialMediaRepository.DontShowOnHome(id);
        }

        public List<TeacherSocialMedia> TGetLast3SocialMediasByTeacherID(int id)
        {
            return _teacherSocialMediaRepository.GetLast3SocialMediasByTeacherID(id);
        }

        public void TShowOnHome(int id)
        {
            _teacherSocialMediaRepository.ShowOnHome(id);
        }
    }
}