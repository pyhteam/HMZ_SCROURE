﻿using HMZ.Data.Data;
using HMZ.Service.Repository;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HMZ.Service.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HMZDbContext dbContext;
        private readonly IServiceProvider _serviceProvider;
        private IDbContextTransaction _transaction;
        public UnitOfWork(HMZDbContext db, IServiceProvider serviceProvider)
        {
            dbContext = db;
            this._serviceProvider = serviceProvider;
        }

        public void BeginTransaction()
        {
            _transaction = dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction.Dispose();
            }
        }
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return _serviceProvider.GetService<IRepository<T>>();
        }

        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
            }
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
