using Microsoft.AspNetCore.Mvc;
using SalesService.Data;
using SalesService.Models;
using Common.Messaging;

namespace VendaService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendaController : ControllerBase
{
    private readonly SalesDbContext _context;
    private readonly RabbitMQPublisher _publisher;

    public VendaControllerController(SalesDbContext context, RabbitMQPublisher publisher)
    {
        _context = context;
        _publisher = publisher;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(Order order)
    {
        // Aqui você pode adicionar verificação via API do estoque ou via DB compartilhado
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        // Notifica o estoque sobre a redução
        _publisher.Publish("stock-update", order);

        return CreatedAtAction(nameof(CreateOrder), new { id = order.Id }, order);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders() =>
        Ok(await _context.Orders.ToListAsync());
}
