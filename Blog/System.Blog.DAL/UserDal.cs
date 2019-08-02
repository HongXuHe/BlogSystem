using System;
using System.Blog.Entities;
using System.Blog.IDAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Blog.DAL
{
    public class UserDal : BaseDal<UserEntity>, IUserDal
    {
        private readonly EntityDbContext _context;
        public UserDal(EntityDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Login(string userName, string password)
        {
            var user =await Task.Run(()=> _context.Users.Where(u => u.UserName == userName).FirstOrDefault());
            if(user != null)
            {
                if (user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
