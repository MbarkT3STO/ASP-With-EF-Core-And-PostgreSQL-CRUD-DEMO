using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configs;

public class ProductEntityConfigs : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p=>p.Id);
        builder.Property(p=>p.Id).ValueGeneratedOnAdd();
        
        builder.Property(p=>p.Name).IsRequired().HasMaxLength(50);
        builder.Property(p=>p.Price).IsRequired().HasColumnType("decimal(18,2)");
    }
}
