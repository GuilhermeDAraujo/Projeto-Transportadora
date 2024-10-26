using Microsoft.EntityFrameworkCore;
using Projeto_Transportadora.Context;
using Projeto_Transportadora.Models;
using Projeto_Transportadora.ViewModel;

namespace Projeto_Transportadora.Services
{
    public class IEstoqueService
    {
        private readonly TransportadoraContext _context;

        public IEstoqueService(TransportadoraContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(NotaFiscal notaFiscal, DateTime dataEntrada)
        {
            if (notaFiscal == null)
                throw new ArgumentException("Nota Fiscal inválida!");

            var notaFiscalEstoque = new Estoque
            {
                NotaFiscalId = notaFiscal.id,
                DataDaEntrada = dataEntrada
            };

            _context.Estoques.Add(notaFiscalEstoque);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Estoque>> ObterNotasFiscaisDeHojeAsync()
        {
            var hoje = DateTime.Today;
            return await _context.Estoques
                .Include(n => n.NotaFiscal)
                .Where(e => e.DataDaEntrada.Date == hoje)
                .ToListAsync();
        }
    }
}