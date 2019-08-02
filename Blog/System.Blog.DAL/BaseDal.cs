using Microsoft.EntityFrameworkCore;
using System;
using System.Blog.Entities;
using System.Blog.IDAL;
using System.Linq;
using System.Threading.Tasks;

namespace System.Blog.DAL
{
    public class BaseDal<T> : IBaseDal<T> where T : BaseEntity
    {
        #region Add
        /// <summary>
        /// Add entity to context
        /// </summary>
        /// <param name="t">entity</param>
        /// <param name="context">context</param>
        /// <returns></returns>
        public async Task AddAsync(T t, EntityDbContext context)
        {
            await context.AddAsync(t);          
        }
        #endregion

        #region Delete
        public async Task DeleteAsync(string id, EntityDbContext context)
        {
            var entity =await Task.Factory.StartNew(()=> context.Set<T>().AsQueryable<T>().FirstOrDefault(t => t.Id.ToString() == id));
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
            }
            
        }

        public async Task DeleteAsync(T t, EntityDbContext context)
        {
            await DeleteAsync(t.Id.ToString(), context);
        }
        #endregion

        #region GetList
        public IQueryable<T> GetAllList(EntityDbContext context)
        {
            return context.Set<T>();
        }

        public IQueryable<T> GetPagedList(int pageIndex, int pageSize, EntityDbContext context)
        {
            return GetAllList(context).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        #endregion

        #region Update Model

        public async Task UpdateAsync(string id, EntityDbContext context)
        {
            var model = context.Set<T>().Where(t => t.Id.ToString() == id).FirstOrDefault();
            if (model != null)
            {
                await UpdateAsync(model, context);
            }
          
        }

        public async Task UpdateAsync(T t, EntityDbContext context)
        {
            var model =await Task.Factory.StartNew(()=> context.Set<T>().Where(s => s.Id == t.Id).AsNoTracking().FirstOrDefault());
            if(model != null)
            {
                context.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            //await UpdateAsync(t.Id.ToString(), context);
        }
        #endregion

        #region SaveToDb
        public async Task<bool> SaveToDBAsync(EntityDbContext context)
        {
            return await context.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
