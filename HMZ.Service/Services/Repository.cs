using HMZ.Data.Data;
using HMZ.Service.Repository;
using Microsoft.EntityFrameworkCore;

namespace HMZ.Service.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly HMZDbContext _dbContext;
        public Repository(HMZDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<List<T>> AddRangeAsync(List<T> list)
        {
            await _dbContext.Set<T>().AddRangeAsync(list);
            return list;
        }

        public IQueryable<T> AsQueryable()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public void UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
