using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DesafioItau.src.Domain.Clientes.Entities;
using DesafioItau.src.Domain.Clientes.repositories;
using DesafioItau.src.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace DesafioItau.src.infra.Persistence.repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Set<Cliente>().AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteCpfAsync(string cpf)
        {
            return await _context.Set<Cliente>()
                .AnyAsync(c => c.Cpf == cpf);
        }
    }
}