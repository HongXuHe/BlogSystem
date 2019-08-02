using System;
using System.Blog.Entities;
using System.BLog.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace System.Blog.IBLL
{
    public interface IBaseBll<T> where T:BaseEntity
    {
        Task AddAsync(T t);
        Task UpdateAsync(string id);
        Task UpdateAsync(T t);
        Task DeleteAsync(string id);
        Task DeleteAsync(T t);
        Task<bool> SaveToDBAsync();
        IQueryable<T> GetAllList();
        IQueryable<T> GetPagedList(int pageIndex, int pageSize);
    }
}
