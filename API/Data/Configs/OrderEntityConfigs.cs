using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configs;

public class OrderEntityConfigs : IEntityTypeConfiguration<Order>
{
	public void Configure(EntityTypeBuilder<Order> builder)
	{
		builder.HasKey(o=>o.Id);
		
		// Id should be Identity column starting from 100 and increment by 5
		builder.Property(o=>o.Id).ValueGeneratedOnAdd().HasIdentityOptions(startValue: 100, incrementBy: 5);
		
		// OrderDate should only store date and not time
		builder.Property(o=>o.OrderDate).IsRequired().HasColumnType("date");
		
		// Configure relationship with Customer
		builder.HasOne(o=>o.Customer).WithMany(c=>c.Orders).HasForeignKey(o=>o.CustomerId);
		
		// Configure relationship with Product
		builder.HasOne(o=>o.Product).WithMany(p=>p.Orders).HasForeignKey(o=>o.ProductId);
	}
}
