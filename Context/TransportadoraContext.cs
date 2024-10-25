using Microsoft.EntityFrameworkCore;
using Projeto_Transportadora.Models;

namespace Projeto_Transportadora.Context
{
    public class TransportadoraContext : DbContext
    {
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<Caminhao> Caminhoes { get; set; }
        public DbSet<AcaoNotaFiscal> AcoesNotaFiscal { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Fechamento> Fechamentos { get; set; }

        public TransportadoraContext(DbContextOptions<TransportadoraContext> options) :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotaFiscal>()
                .HasOne(nf => nf.Caminhao)
                .WithMany(c => c.NotasFiscais)
                .HasForeignKey(nf => nf.CaminhaoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AcaoNotaFiscal>()
                .HasOne(an => an.NotaFiscal)
                .WithMany(nf => nf.Acoes)
                .HasForeignKey(an => an.NotaFiscalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Estoque>()
                .HasOne(e => e.NotaFiscal)
                .WithMany()
                .HasForeignKey(e => e.NotaFiscalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Fechamento>()
                .HasOne(f => f.NotaFiscal)
                .WithMany()
                .HasForeignKey(f => f.NotaFiscalId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}