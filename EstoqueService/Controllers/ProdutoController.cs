using Microsoft.AspNetCore.Mvc;
using StockService.Data;
using StockService.Models;

namespace EstoqueService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly StockDbContext _context;

    public ProductsController(StockDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts() =>
        Ok(await _context.Products.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
    }

    [HttpPut("{id}/quantity")]
    public async Task<IActionResult> UpdateQuantity(int id, [FromBody] int quantity)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound();

        product.Quantity = quantity;
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
