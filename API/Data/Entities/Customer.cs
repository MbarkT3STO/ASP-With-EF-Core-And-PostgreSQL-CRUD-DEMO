using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities;

public class Customer
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public byte Age { get; set; }
	
	public ICollection<Order> Orders { get; set; }
}
