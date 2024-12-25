using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    public class FeatureRepository : GenericRepository<Feature>, IFeatureRepository
    {
        public FeatureRepository(OnlineEduContext _context) : base(_context)
        {
        }

        public void DontShowOnHome(int id)
        {
            var value = _context.Features.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

        public List<Feature> GetLast4Features()
        {
            return _context.Features.Where(x => x.IsShown).OrderByDescending(x => x.FeatureID).Take(4).ToList();
        }

        public List<Feature> GetAllFeatures()
        {
            return _context.Features.Where(x => x.IsShown).OrderByDescending(x => x.FeatureID).ToList();
        }

        public void ShowOnHome(int id)
        {
            var value = _context.Features.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }
    }
}