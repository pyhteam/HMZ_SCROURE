namespace HMZ.Service.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        IRepository<T> GetRepository<T>()
            where T : class;
    }
}
