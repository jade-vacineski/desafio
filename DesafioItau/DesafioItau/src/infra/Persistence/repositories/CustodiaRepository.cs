using DesafioItau.src.Domain.Custodias.Entities;
using DesafioItau.src.Domain.Custodias.repositories;
using DesafioItau.src.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DesafioItau.src.infra.Persistence.repositories
{
    public class CustodiaRepository : ICustodiaRepository
    {
        private readonly AppDbContext _context;

        public CustodiaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Custodia custodia)
        {
            await _context.Set<Custodia>().AddAsync(custodia);
            await _context.SaveChangesAsync();
        }

        public async Task<Custodia> GetByContaGraficaIdAsync(int contaGraficaId)
        {
            return await _context.Set<Custodia>()
                .FirstOrDefaultAsync(c => c.ContaGraficaId == contaGraficaId);
        }
    }
}
