using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<Pedido> CriarVenda(Pedido pedido)
        {
            if (pedido.quantidade <= 0)
            {
                throw new ArgumentNullException(nameof(pedido));
            }

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        //obter todos os pedidos de venda
        public async Task<List<Pedido>> ObterTodosPedidos() =>
            await _context.Pedidos.ToListAsync();

        //obter pedido por ID
        public async Task<Pedido> ObterPedidoPorId(int id) =>
            await _context.Pedidos.FindAsync(id);

        //atualizar pedido de venda
        public async Task<Pedido> AtualizarPedido(int id, Pedido pedido)
        {
            var pedidoExistente = await _context.Pedidos.FindAsync(id);
            if (pedidoExistente == null)
            {
                throw new KeyNotFoundException("Pedido não encontrado");
            }
            pedidoExistente.Produto = pedido.Produto;
            pedidoExistente.Quantidade = pedido.Quantidade;
            pedidoExistente.Preco = pedido.Preco;
            await _context.SaveChangesAsync();
            return pedidoExistente;
        }
    }
}