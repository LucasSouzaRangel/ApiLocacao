using ApiLocacao.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiLocacao.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Cliente { get; set; } = null!;
        public DbSet<Filme> Filme { get; set; } = null!;
        public DbSet<Locacao> Locacao { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");
                entity.HasIndex(e => e.CPF, "idx_CPF");
                entity.HasIndex(e => e.Nome, "idx_NOME");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CPF)
                    .HasMaxLength(11)
                    .HasColumnName("CPF");

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");
                entity.Property(e => e.Nome).HasMaxLength(200);
            });

            modelBuilder.Entity<Filme>(entity =>
            {
                entity.ToTable("filme");
                entity.HasIndex(e => e.Lancamento, "idx_Lancamento");
                entity.HasIndex(e => e.Titulo, "idx_Titulo");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Titulo).HasMaxLength(100);
            });

            modelBuilder.Entity<Locacao>(entity =>
            {
                entity.ToTable("locacao");
                entity.HasIndex(e => e.IdCliente, "FK_Cliente_idx_idx");
                entity.HasIndex(e => e.IdFilme, "FK_Filme_idx_idx");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.DataDevolucao).HasColumnType("datetime");
                entity.Property(e => e.DataLocacao).HasColumnType("datetime");
                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
                entity.Property(e => e.IdFilme).HasColumnName("Id_Filme");                
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
