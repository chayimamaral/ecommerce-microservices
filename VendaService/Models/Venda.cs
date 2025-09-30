namespace VendaService.Models;

public class Venda
{
    public int Id { get; set; }
    public int Codigo { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
