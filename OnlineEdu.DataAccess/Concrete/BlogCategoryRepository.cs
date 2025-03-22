using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DataAccess.Concrete
{
    public interface IBlogCategoryRepository : IRepository<BlogCategory>
    {
        List<BlogCategory> GetCategoriesWithBlogs();
    }
}
