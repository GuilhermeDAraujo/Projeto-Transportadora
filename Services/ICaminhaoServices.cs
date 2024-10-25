using Microsoft.EntityFrameworkCore;
using Projeto_Transportadora.Context;
using Projeto_Transportadora.Models;

namespace Projeto_Transportadora.Services
{
    public class ICaminhaoServices
    {
        private readonly TransportadoraContext _context;

        public ICaminhaoServices(TransportadoraContext context)
        {
            _context = context;
        }

        public async Task<Caminhao> CreateAsync(Caminhao caminhao)
        {
            await _context.AddAsync(caminhao);
            await _context.SaveChangesAsync();
            return caminhao;
        }

        public async Task<Caminhao> UpdateAsync(Caminhao caminhao)
        {
            _context.Update(caminhao);
            await _context.SaveChangesAsync();
            return caminhao;
        }

        public async Task<Caminhao> DeleteAsync(Caminhao caminhao)
        {
            if (await _context.Caminhoes.AnyAsync(c => c.id == caminhao.id))
            {
                _context.Remove(caminhao);
                await _context.SaveChangesAsync();
            }
            return caminhao;
        }

        public async Task<List<Caminhao>> ListarTodosCaminhoesAsync()
        {
            return await _context.Caminhoes.OrderBy(c => c.Placa).ToListAsync();
        }

        public async Task<Caminhao> BuscarCaminhao(int id)
        {
            return await _context.Caminhoes.FindAsync(id);
        }

        public async Task<bool> CaminhaoJaCadastrado(string placa)
        {
            return await _context.Caminhoes.AnyAsync(p => p.Placa == placa);
        }
    }
}