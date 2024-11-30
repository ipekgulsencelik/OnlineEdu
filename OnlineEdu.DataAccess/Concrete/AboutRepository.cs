using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    public class AboutRepository : GenericRepository<About>, IAboutRepository
    {
        public AboutRepository(OnlineEduContext _context) : base(_context)
        {

        }
    }
}
