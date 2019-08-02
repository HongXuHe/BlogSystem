using System;
using System.Blog.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace System.Blog.IDAL
{
    public interface IBaseDal<T> where T:BaseEntity
    {
        Task AddAsync(T t,EntityDbContext context);
        Task UpdateAsync(string id, EntityDbContext context);
        Task UpdateAsync(T t, EntityDbContext context);
        Task DeleteAsync(string id, EntityDbContext context);
        Task DeleteAsync(T t, EntityDbContext context);
        Task<bool> SaveToDBAsync(EntityDbContext context);
        IQueryable<T> GetAllList(EntityDbContext context);
        IQueryable<T> GetPagedList(int pageIndex, int pageSize, EntityDbContext context);        
    } 
    
}
