using LiveCurrencyWindowsService.Models.Entities;
using System.Data.Entity;

namespace LiveCurrencyWindowsService.Models.DataContexts
{
    public class CurrencyDbContext : DbContext
    {
        public CurrencyDbContext() : base("name=cString")
        {

        }

        public DbSet<Valute> Valutes { get; set; }
        public DbSet<ValType> ValTypes { get; set; }
        public DbSet<ValCurs> ValCurs { get; set; }
    }
}
