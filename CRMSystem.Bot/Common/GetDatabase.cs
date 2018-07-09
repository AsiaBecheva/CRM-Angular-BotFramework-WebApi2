using System.Configuration;
using CRMSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace CRMSystem.Bot.Common
{
    public static class GetDatabase
    {
        public static CRMDbContext GetContext()
        {
            DbContextOptionsBuilder<CRMDbContext> optionsBuilder =
            new DbContextOptionsBuilder<CRMDbContext>().UseSqlServer(
                ConfigurationManager.ConnectionStrings["CRMSystem"].ConnectionString);


            CRMDbContext db = new CRMDbContext(optionsBuilder.Options);

            return db;
        }
    }
}