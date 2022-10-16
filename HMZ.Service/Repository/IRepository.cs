namespace HMZ.Service.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> AsQueryable();
        Task<T> AddAsync(T entity);
        void UpdateAsync(T entity);
        void Delete(T entity);
        Task<T> GetAsync(string id);
        Task<List<T>> AddRangeAsync(List<T> list);
    }
}
