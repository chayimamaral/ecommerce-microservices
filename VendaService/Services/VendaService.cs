using Microsoft.EntityFrameworkCore;
using VendaService.Data;
using VendaService.Models;

namespace VendaService.Services
{
    public class VendaService
    {
        private readonly VendaDbContext _context;

        public VendaService(VendaDbContext context)
        {
            _context = context;
        }   

        //criar pedido de venda
        public async Task<Venda> CriarVenda(Venda venda)
        {
            if (venda.Quantidade <= 0)
            {
                throw new ArgumentNullException(nameof(venda));
            }

            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();
            return venda;
        }

        //obter todos os pedidos de venda
        public async Task<List<Venda>> ObterTodosPedidos() =>
            await _context.Vendas.ToListAsync();

        //obter pedido por ID
        public async Task<Venda> ObterPedidoPorId(int id) =>
            await _context.Vendas.FindAsync(id);

        //atualizar pedido de venda
        public async Task<Venda> AtualizarPedido(int id, Venda venda)
        {
            var vendaExistente = await _context.Vendas.FindAsync(id);
            if (vendaExistente == null)
            {
                throw new KeyNotFoundException("Venda não encontrada");
            }
            vendaExistente.Id = venda.Id;
            vendaExistente.Quantidade = venda.Quantidade;
            vendaExistente.Preco = venda.Preco;
            await _context.SaveChangesAsync();
            return vendaExistente;
        }
    }
}