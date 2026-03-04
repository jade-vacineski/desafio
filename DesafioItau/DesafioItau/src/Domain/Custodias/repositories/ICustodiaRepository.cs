using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioItau.src.Domain.Custodias.Entities;

namespace DesafioItau.src.Domain.Custodias.repositories
{
    public interface ICustodiaRepository
    {
        Task AddAsync(Custodia custodia);
        Task<Custodia> GetByContaGraficaIdAsync(int contaGraficaId);
    }
}