using KnnApp.Core.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KnnApp.DAL.Context;
public class KnnAppDbContext : DbContext
{
    public KnnAppDbContext(DbContextOptions<KnnAppDbContext> options) : base(options){}

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

}
