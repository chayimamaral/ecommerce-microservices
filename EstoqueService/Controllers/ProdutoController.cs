using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EstoqueService.Data;
using EstoqueService.Models;

namespace EstoqueService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly EstoqueDbContext _context;

    public ProductsController(EstoqueDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts() =>
        Ok(await _context.Produtos.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> CreateProduct(Produto product)
    {
        _context.Produtos.Add(product);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
    }

    [HttpPut("{id}/quantity")]
    public async Task<IActionResult> UpdateQuantity(int id, [FromBody] int quantidade)
    {
        var product = await _context.Produtos.FindAsync(id);
        if (product == null) return NotFound();

        product.Quantidade = quantidade;
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
