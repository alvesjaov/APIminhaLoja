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
        _context.PedidoProdutos.Add(pedidoProduto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPedidoProduto), new { pedidoId = pedidoProduto.PedidoId, produtoId = pedidoProduto.ProdutoId }, pedidoProduto);
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
