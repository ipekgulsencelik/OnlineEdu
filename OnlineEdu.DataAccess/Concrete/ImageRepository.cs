﻿using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    internal class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(OnlineEduContext _context) : base(_context)
        {
        }

        public void DontShowOnHome(int id)
        {
            var value = _context.Images.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

        public void ShowOnHome(int id)
        {
            var value = _context.Images.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }
    }
}