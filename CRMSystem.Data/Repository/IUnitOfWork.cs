using CRMSystem.Models;

namespace CRMSystem.Data.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Customer> Customers { get; }

        IRepository<Product> Products { get; }

        int SaveChanges();
    }
}