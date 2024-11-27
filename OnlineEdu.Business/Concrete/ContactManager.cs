using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class ContactManager : GenericManager<Contact>, IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactManager(IRepository<Contact> _repository, IContactRepository contactRepository) : base(_repository)
        {
            _contactRepository = contactRepository;
        }

        public void TDontShowOnHome(int id)
        {
            _contactRepository.DontShowOnHome(id);
        }

        public Contact TGetContact()
        {
            return _contactRepository.GetContact();
        }

        public void TShowOnHome(int id)
        {
            _contactRepository.ShowOnHome(id);
        }
    }
}