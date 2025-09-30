using Microsoft.EntityFrameworkCore;
using SalesService.Models;

namespace VendaService.Data;

public class VendaDbContext(DbContextOptions<VendaDbContext> options) : DbContext(options), DbContext
{
  public DbSet<Order> Orders { get; set; }
}
