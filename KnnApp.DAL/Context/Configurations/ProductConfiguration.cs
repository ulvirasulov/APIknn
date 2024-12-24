using KnnApp.Core.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnApp.DAL.Context.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();

        builder.Property(x => x.ProductName)
               .IsRequired()
               .HasMaxLength(50); 

        builder.Property(x => x.Description)
               .HasMaxLength(500); 

        builder.Property(x => x.Price)
               .IsRequired(); 

        builder.Property(x => x.OldPrice)
               .IsRequired(false); 

        builder.Property(x => x.CategoryId)
               .IsRequired(); 
        
        builder.HasOne(x => x.Category)
               .WithMany(x => x.Products)
               .HasForeignKey(x => x.CategoryId) 
               .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Products");

    }
}
