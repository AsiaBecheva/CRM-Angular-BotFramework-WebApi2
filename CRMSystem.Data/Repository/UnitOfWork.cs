using System;
using System.Collections.Generic;
using CRMSystem.Models;

namespace CRMSystem.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CRMDbContext cRMDbContext;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork(CRMDbContext cRMDbContext)
        {
            this.cRMDbContext = cRMDbContext;
        }

        public IRepository<Customer> Customers
        {
            get
            {
                return this.GetRepository<Customer>();
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                return this.GetRepository<Product>();
            }
        }

        public int SaveChanges()
        {
            return this.cRMDbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.cRMDbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}