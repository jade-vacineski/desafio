using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioItau.src.Domain.ContasGraficas.entities;

namespace DesafioItau.src.Domain.ContasGraficas.repositories
{
    public interface IContaGraficaRepository
    {
        Task AddAsync(ContaGrafica contaGrafica);
        Task<ContaGrafica> GetByIdAsync(int id);
    }
}