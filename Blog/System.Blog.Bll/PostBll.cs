using System;
using System.Blog.Entities;
using System.Blog.IBLL;
using System.Blog.IDAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Blog.Bll
{
   public class PostBll:BaseBll<PostEntity>, IPostBll
    {
        private readonly IPostDal _postDal;
        private readonly EntityDbContext _context;
        public PostBll(IPostDal postDal, EntityDbContext context) : base(postDal, context)
        {
            _postDal = postDal;
            _context = context;
        }

        public async Task<IEnumerable<CategoryEntity>> GetCategoryList()
        {
           return await _postDal.GetCategoryList();
           
        }
    }
}
