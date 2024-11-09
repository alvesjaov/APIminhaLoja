using Microsoft.AspNetCore.Mvc;
using minhaLoja.Data; 
using Microsoft.EntityFrameworkCore;
using minhaLoja.Models; 

namespace minhaLoja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _context.Pedidos.Include(p => p.Cliente)
                                         .Include(p => p.PedidoProdutos)
                                         .ThenInclude(pp => pp.Produto)
                                         .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedidos.Include(p => p.Cliente)
                                               .Include(p => p.PedidoProdutos)
                                               .ThenInclude(pp => pp.Produto)
                                               .FirstOrDefaultAsync(p => p.IdPedido == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(PedidoDto pedidoDto)
        {
            var cliente = await _context.Clientes.FindAsync(pedidoDto.ClienteId);
            if (cliente == null)
            {
                return BadRequest("Cliente não encontrado.");
            }

            var pedido = new Pedido
            {
                ClienteId = pedidoDto.ClienteId,
                Cliente = cliente,
                Status = pedidoDto.Status,
                PedidoProdutos = pedidoDto.PedidoProdutos.Select(pp => new PedidoProduto
                {
                    ProdutoId = pp.ProdutoId,
                    Quantidade = pp.Quantidade
                }).ToList()
            };

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPedido), new { id = pedido.IdPedido }, pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, PedidoDto pedidoDto)
        {
            if (id != pedidoDto.ClienteId)
            {
                return BadRequest();
            }

            var pedido = await _context.Pedidos.Include(p => p.PedidoProdutos)
                                               .FirstOrDefaultAsync(p => p.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            pedido.Status = pedidoDto.Status;
            pedido.PedidoProdutos = pedidoDto.PedidoProdutos.Select(pp => new PedidoProduto
            {
                PedidoId = id,
                ProdutoId = pp.ProdutoId,
                Quantidade = pp.Quantidade
            }).ToList();

            _context.Entry(pedido).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    public class PedidoDto
    {
        public int ClienteId { get; set; }
        public string Status { get; set; } = string.Empty;
        public ICollection<PedidoProdutoDto> PedidoProdutos { get; set; } = new List<PedidoProdutoDto>();
    }

    public class PedidoProdutoDto
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
