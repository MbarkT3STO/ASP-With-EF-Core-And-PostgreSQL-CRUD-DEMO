using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configs;

public class CustomerEntityConfigs : IEntityTypeConfiguration<Customer>
{
	public void Configure(EntityTypeBuilder<Customer> builder)
	{
		builder.HasKey(c=>c.Id);
		builder.Property(c=>c.Id).ValueGeneratedOnAdd();
		
		builder.Property(c=>c.FirstName).IsRequired().HasMaxLength(50);
		builder.Property(c=>c.LastName).IsRequired().HasMaxLength(50);
	}
}