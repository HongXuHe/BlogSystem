using System;
using System.Blog.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Blog.IBLL
{
    public interface IPostBll : IBaseBll<PostEntity>
    {
        Task<IEnumerable<CategoryEntity>> GetCategoryList();
    }
}
