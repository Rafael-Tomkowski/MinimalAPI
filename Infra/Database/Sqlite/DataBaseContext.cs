using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Infra.Database.Sqlite
{
    public class DataBaseContext:DbContext
    {
        public DbSet<ProductModel> products {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=Banco.db;Cache=Shared");
            base.OnConfiguring(optionsBuilder);
        }
    }
}