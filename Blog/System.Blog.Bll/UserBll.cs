using System;
using System.Blog.Entities;
using System.Blog.IBLL;
using System.Blog.IDAL;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.Blog.Bll
{
    public class UserBll : BaseBll<UserEntity>, IUserBll
    {
        private readonly IUserDal _userDal;
        private readonly EntityDbContext _context;
        public UserBll(IUserDal userDal, EntityDbContext context):base(userDal,context)
        {
            _userDal = userDal;
            _context = context;
        }
        public async Task<bool> Login(string userName, string password)
        {
           return await _userDal.Login(userName, password);
        }
    }
}
