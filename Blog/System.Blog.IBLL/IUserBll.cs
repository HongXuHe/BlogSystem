using System;
using System.Blog.Entities;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.Blog.IBLL
{
    public interface IUserBll:IBaseBll<UserEntity>
    {
        Task<bool> Login(string userName, string password);
    }
}
