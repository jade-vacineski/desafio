using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioItau.src.Domain.Clientes.Entities;

namespace DesafioItau.src.Domain.Clientes.repositories
{
    public interface IClienteRepository
    {
        Task AddAsync(Cliente cliente);
        Task<bool> ExisteCpfAsync(string cpf);
    }
}