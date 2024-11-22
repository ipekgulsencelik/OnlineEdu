using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface IImageService : IGenericService<Image>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
    }
}