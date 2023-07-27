using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
	AppDbContext _context;
	
	public OrdersController(AppDbContext context)
	{
		_context = context;
	}
	
	
	[HttpGet]
	public IActionResult Get()
	{
		var orders = _context.Orders.ToList();
		return Ok(orders);
	}
	
	
	[HttpGet("{id}")]
	public IActionResult Get(int id)
	{
		var order = _context.Orders.FirstOrDefault(o=>o.Id == id);
		if(order == null)
		{
			return NotFound();
		}
		return Ok(order);
	}
	
	
	[HttpPost]
	public IActionResult Post([FromBody] Order order)
	{
		if(!ModelState.IsValid)
		{
			return BadRequest();
		}
		_context.Orders.Add(order);
		_context.SaveChanges();
		return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
	}
	
	
	[HttpPut("{id}")]
	public IActionResult Put(int id, [FromBody] Order order)
	{
		if(id != order.Id)
		{
			return BadRequest();
		}
		_context.Orders.Update(order);
		_context.SaveChanges();
		return NoContent();
	}
	
	
	[HttpDelete("{id}")]
	public IActionResult Delete(int id)
	{
		var order = _context.Orders.FirstOrDefault(o=>o.Id == id);
		if(order == null)
		{
			return NotFound();
		}
		_context.Orders.Remove(order);
		_context.SaveChanges();
		return NoContent();
	}
}
