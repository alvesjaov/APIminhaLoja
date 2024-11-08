using Microsoft.EntityFrameworkCore;

public class LojaContext : DbContext
{
    public LojaContext(DbContextOptions<LojaContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoProduto> PedidoProdutos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração da chave composta para PedidoProduto
        modelBuilder.Entity<PedidoProduto>()
            .HasKey(pp => new { pp.PedidoId, pp.ProdutoId });

        modelBuilder.Entity<PedidoProduto>()
            .HasOne(pp => pp.Pedido)
            .WithMany(p => p.PedidoProdutos)
            .HasForeignKey(pp => pp.PedidoId);

        modelBuilder.Entity<PedidoProduto>()
            .HasOne(pp => pp.Produto)
            .WithMany(p => p.PedidoProdutos)
            .HasForeignKey(pp => pp.ProdutoId);
    }
}
