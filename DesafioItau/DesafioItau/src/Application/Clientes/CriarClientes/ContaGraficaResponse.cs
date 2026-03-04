using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioItau.src.Application.Clientes.CriarClientes
{
    public record ContaGraficaResponse
    {
        public long Id { get; init; }
        public string NumeroConta { get; init; }
        public string Tipo { get; init; }
        public DateTime DataCriacao { get; init; }
    }
}