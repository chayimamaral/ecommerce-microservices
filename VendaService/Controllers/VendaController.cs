using Microsoft.AspNetCore.Mvc;
using Common.Messaging;
using VendaService.Data;
using VendaService.Models;
using Microsoft.EntityFrameworkCore;

namespace VendaService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendaController : ControllerBase
{
    private readonly VendaDbContext _context;
    private readonly RabbitMQPublisher _publisher;

    public VendaController(VendaDbContext context, RabbitMQPublisher publisher)
    {
        _context = context;
        _publisher = publisher;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(Venda venda)
    {
        // Aqui você pode adicionar verificação via API do estoque ou via DB compartilhado
        _context.Vendas.Add(venda);
        await _context.SaveChangesAsync();

        // Notifica o estoque sobre a redução
        _publisher.Publish("stock-update", System.Text.Json.JsonSerializer.Serialize(venda));

        return CreatedAtAction(nameof(CreateOrder), new { id = venda.Id }, venda);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders() =>
        Ok(await _context.Vendas.ToListAsync());
}
