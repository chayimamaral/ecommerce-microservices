using Microsoft.EntityFrameworkCore;
using VendaService.Models;

namespace VendaService.Data;

public class VendaDbContext : DbContext
{
  public VendaDbContext(DbContextOptions<VendaDbContext> options) : base(options)
  {
  }

  public DbSet<Venda> Vendas { get; set; }
}
