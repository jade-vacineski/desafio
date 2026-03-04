using DesafioItau.src.Domain.ContasGraficas.entities;
using DesafioItau.src.Domain.ContasGraficas.repositories;
using DesafioItau.src.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DesafioItau.src.infra.Persistence.repositories
{
    public class ContaGraficaRepository : IContaGraficaRepository
    {
        private readonly AppDbContext _context;

        public ContaGraficaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ContaGrafica contaGrafica)
        {
            await _context.Set<ContaGrafica>().AddAsync(contaGrafica);
            await _context.SaveChangesAsync();
        }

        public async Task<ContaGrafica> GetByIdAsync(int id)
        {
            return await _context.Set<ContaGrafica>()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
