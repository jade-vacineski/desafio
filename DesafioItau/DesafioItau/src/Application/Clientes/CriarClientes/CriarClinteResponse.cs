using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioItau.src.Domain.ContasGraficas.entities;

namespace DesafioItau.src.Application.Clientes.CriarClientes
{
    public record CriarClienteResponse
    {
        public string Nome { get; init; }
        public string Cpf { get; init; }
        public string Email { get; init; }
        public decimal ValorMensal { get; init; }
        public Boolean Ativo { get; init; }
        public DateTime DataAdesao { get; init; }
        public ContaGrafica ContaGrafica { get; init; }

    }
}