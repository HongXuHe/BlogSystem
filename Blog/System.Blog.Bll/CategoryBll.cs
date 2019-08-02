using System;
using System.Blog.Entities;
using System.Blog.IBLL;
using System.Blog.IDAL;
using System.Collections.Generic;
using System.Text;

namespace System.Blog.Bll
{
   public class CategoryBll : BaseBll<CategoryEntity>, ICategoryBll
    {
        private readonly ICategoryDal _categoryDal;
        private readonly EntityDbContext _context;
        public CategoryBll(ICategoryDal categoryDal, EntityDbContext context) : base(categoryDal, context)
        {
            _categoryDal = categoryDal;
            _context = context;
        }
    }
}
