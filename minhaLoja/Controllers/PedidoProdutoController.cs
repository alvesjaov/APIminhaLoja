using Microsoft.AspNetCore.Mvc;
using minhaLoja.Data; 
using Microsoft.EntityFrameworkCore;
using minhaLoja.Models;

namespace minhaLoja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidoProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoProduto>>> GetPedidoProdutos()
        {
            return await _context.PedidoProdutos.Include(pp => pp.Pedido).Include(pp => pp.Produto).ToListAsync();
        }

        [HttpGet("{pedidoId}/{produtoId}")]
        public async Task<ActionResult<PedidoProduto>> GetPedidoProduto(int pedidoId, int produtoId)
        {
            var pedidoProduto = await _context.PedidoProdutos
                                              .Include(pp => pp.Pedido)
                                              .Include(pp => pp.Produto)
                                              .FirstOrDefaultAsync(pp => pp.PedidoId == pedidoId && pp.ProdutoId == produtoId);

            if (pedidoProduto == null)
            {
                return NotFound();
            }

            return pedidoProduto;
        }

        [HttpPost]
        public async Task<ActionResult<PedidoProduto>> PostPedidoProduto(PedidoProduto pedidoProduto)
        {
            var pedido = await _context.Pedidos.FindAsync(pedidoProduto.PedidoId);
            if (pedido == null)
            {
                return BadRequest("Pedido não encontrado.");
            }

            var produto = await _context.Produtos.FindAsync(pedidoProduto.ProdutoId);
            if (produto == null)
            {
                return BadRequest("Produto não encontrado.");
            }

            var existingPedidoProduto = await _context.PedidoProdutos
                .FirstOrDefaultAsync(pp => pp.PedidoId == pedidoProduto.PedidoId && pp.ProdutoId == pedidoProduto.ProdutoId);

            if (existingPedidoProduto != null)
            {
                return BadRequest("A combinação de PedidoId e ProdutoId já existe.");
            }

            pedidoProduto.Pedido = pedido;
            pedidoProduto.Produto = produto;

            _context.PedidoProdutos.Add(pedidoProduto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPedidoProduto), new { pedidoId = pedidoProduto.PedidoId, produtoId = pedidoProduto.ProdutoId }, pedidoProduto);
        }

        [HttpPut("{pedidoId}/{produtoId}")]
        public async Task<IActionResult> PutPedidoProduto(int pedidoId, int produtoId, PedidoProduto pedidoProduto)
        {
            if (pedidoId != pedidoProduto.PedidoId || produtoId != pedidoProduto.ProdutoId)
            {
                return BadRequest();
            }

            var existingPedidoProduto = await _context.PedidoProdutos
                .FirstOrDefaultAsync(pp => pp.PedidoId == pedidoId && pp.ProdutoId == produtoId);

            if (existingPedidoProduto == null)
            {
                return NotFound();
            }

            existingPedidoProduto.Quantidade = pedidoProduto.Quantidade;

            _context.Entry(existingPedidoProduto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{pedidoId}/{produtoId}")]
        public async Task<IActionResult> DeletePedidoProduto(int pedidoId, int produtoId)
        {
            var pedidoProduto = await _context.PedidoProdutos.FindAsync(pedidoId, produtoId);
            if (pedidoProduto == null)
            {
                return NotFound();
            }

            _context.PedidoProdutos.Remove(pedidoProduto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
