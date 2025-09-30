using EstoqueService.Data;
using EstoqueService.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueService.Services
{
    public class EstoqueService
    {
        private readonly EstoqueDbContext _context;

        public EstoqueService(EstoqueDbContext context)
        {
            _context = context;
        }

        //Adicionar produto ao estoque
        public async Task<Produto> AddProduct(Produto produto)
        {
            _context.Produtos.Add(produto);            
            await _context.SaveChangesAsync();
            return produto;

         }

        //Obter todos os produtos do estoque
        public async Task<List<Produto>> GetAllProducts() =>
            await _context.Produtos.ToListAsync();
            
        //Obter produto por ID
        public async Task<Produto> GetProductById(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                throw new KeyNotFoundException("Produto não encontrado");
            }
            return produto;
        }

        //Atualizar produto no estoque
        public async Task<Produto> UpdateProduct(int id, Produto produto)
        {
            var existingProduct = await _context.Produtos.FindAsync(id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException("Produto não encontrado");   
            }
            existingProduct.Nome = produto.Nome;
            existingProduct.Quantidade = produto.Quantidade;
            existingProduct.Preco = produto.Preco;
            await _context.SaveChangesAsync();
            return existingProduct;
        }
    }    
}
