using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Concrete;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DataAccess.Abstract
{
    public class BlogCategoryRepository : GenericRepository<BlogCategory>, IBlogCategoryRepository
    {
        public BlogCategoryRepository(OnlineEduContext context) : base(context)
        {
        }

        public List<BlogCategory> GetCategoriesWithBlogs()
        {
            return _context.BlogCategories.Include(x => x.Blogs).ToList();
        }
    }
}
