using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_Transportadora.Context;
using Projeto_Transportadora.Models;
using Projeto_Transportadora.ViewModel;

namespace Projeto_Transportadora.Services
{
    public class INotaFiscalServices
    {
        private readonly TransportadoraContext _context;

        public INotaFiscalServices(TransportadoraContext context)
        {
            _context = context;
        }

        public async Task<NotaFiscal> CreateAsync(NotaFiscal notaFiscal)
        {
            if(notaFiscal == null)
                throw new ArgumentNullException(nameof(notaFiscal));

            _context.NotasFiscais.Add(notaFiscal);
            await _context.SaveChangesAsync();
            return notaFiscal;
        }



        public async Task<NotaFiscal> ObterNotaFiscalPorId(int id)
        {
            return await _context.NotasFiscais.FindAsync(id);
        }

        public async Task<List<Caminhao>> ListarTodosCaminhoes()
        {
            return await _context.Caminhoes.ToListAsync();
        }
    }
}