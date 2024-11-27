using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(OnlineEduContext context) : base(context)
        {
        }

        public void DontShowOnHome(int id)
        {
            var value = _context.Contacts.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

        public Contact GetContact()
        {
            return _context.Contacts.Where(x => x.IsShown).OrderByDescending(x => x.ContactID).FirstOrDefault();
        }

        public void ShowOnHome(int id)
        {
            var value = _context.Contacts.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }
    }
}