using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface IContactService : IGenericService<Contact>
    {
        Contact TGetContact();
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
    }
}