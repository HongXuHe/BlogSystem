using System;
using System.Blog.Entities;
using System.Blog.IBLL;
using System.Blog.IDAL;
using System.Linq;
using System.Threading.Tasks;

namespace System.Blog.Bll
{
    public class BaseBll<T> : IBaseBll<T> where T : BaseEntity
    {
        private readonly IBaseDal<T> _baseDal;
        private readonly EntityDbContext _context;
        public BaseBll(IBaseDal<T> baseDal, EntityDbContext context)
        {
            _baseDal = baseDal;
            _context = context;
        }
        public async Task AddAsync(T t)
        {
            await _baseDal.AddAsync(t, _context);            
        }

        public async Task DeleteAsync(string id)
        {
              await _baseDal.DeleteAsync(id, _context);
        }

        public async Task DeleteAsync(T t)
        {
            await _baseDal.DeleteAsync(t, _context);
        }

        public IQueryable<T> GetAllList()
        {
           return _baseDal.GetAllList(_context);
        }

        public IQueryable<T> GetPagedList(int pageIndex, int pageSize)
        {
            return _baseDal.GetPagedList(pageIndex, pageSize, _context);
        }

      

        public async Task UpdateAsync(string id)
        {
            await _baseDal.UpdateAsync(id, _context);
        }

        public async Task UpdateAsync(T t)
        {
            await _baseDal.UpdateAsync(t, _context);
        }
        public async Task<bool> SaveToDBAsync()
        {
            return await _baseDal.SaveToDBAsync(_context);
        }
    }
}
