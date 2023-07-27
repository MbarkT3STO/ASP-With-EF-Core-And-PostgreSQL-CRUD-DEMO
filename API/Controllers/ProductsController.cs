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
public class ProductsController : ControllerBase
{
	AppDbContext _context;
	
	public ProductsController(AppDbContext context)
	{
		_context = context;
	}
	
	
	[HttpGet]
	public IActionResult Get()
	{
		var products = _context.Products.ToList();
		return Ok(products);
	}
	
	
	[HttpGet("{id}")]
	public IActionResult Get(string id)
	{
		var product = _context.Products.FirstOrDefault(p=>p.Id == id);
		if(product == null)
		{
			return NotFound();
		}
		return Ok(product);
	}
	
	
	[HttpPost]
	public IActionResult Post([FromBody] Product product)
	{
		if(!ModelState.IsValid)
		{
			return BadRequest();
		}
		_context.Products.Add(product);
		_context.SaveChanges();
		return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
	}
	
	
	[HttpPut("{id}")]
	public IActionResult Put(string id, [FromBody] Product product)
	{
		if(id != product.Id)
		{
			return BadRequest();
		}
		_context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		_context.SaveChanges();
		return NoContent();
	}
	
	
	[HttpDelete("{id}")]
	public IActionResult Delete(string id)
	{
		var product = _context.Products.FirstOrDefault(p=>p.Id == id);
		if(product == null)
		{
			return NotFound();
		}
		_context.Products.Remove(product);
		_context.SaveChanges();
		return NoContent();
	}
}
