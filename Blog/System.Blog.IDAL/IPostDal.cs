using System;
using System.Blog.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Blog.IDAL
{
    public interface IPostDal:IBaseDal<PostEntity>
    {
        Task<IQueryable<CategoryEntity>> GetCategoryList();
    }
}
