using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinimalApiWithEntityFramework.Entities;

namespace MinimalApiWithEntityFramework.Data
{
    public class DataAppContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; } = null!;

         protected override void OnConfiguring(DbContextOptionsBuilder options)
                            => options.UseMySql("Aqui vai sua conection string", new MySqlServerVersion(new Version(8, 0, 32)),
                            options => options.EnableRetryOnFailure());        
    }
}