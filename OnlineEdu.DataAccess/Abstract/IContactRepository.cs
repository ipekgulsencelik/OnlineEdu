using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IContactRepository : IRepository<Contact>
    {
        Contact GetContact();
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
    }
}