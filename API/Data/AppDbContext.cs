using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDbContext: DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
	{
	}
	
	public DbSet<Customer> Customers { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<Product> Products { get; set; }
}
