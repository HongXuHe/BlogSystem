using System;
using System.Blog.Entities;
using System.Blog.IDAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Blog.DAL
{
    public class PostDal : BaseDal<PostEntity>, IPostDal
    {
        private readonly EntityDbContext _context;
        public PostDal(EntityDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<CategoryEntity>> GetCategoryList()
        {
           return await Task.Factory.StartNew(()=> _context.Categories.AsQueryable());
        }
    }
}
