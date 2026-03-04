using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioItau.src.Application.Clientes.SaidaClientes
{
    public record SaidaClienteResponse
    {
        public long ClienteId { get; init; }
        public string Nome { get; init; }
        public bool Ativo { get; init; }
        public DateTime DataSaida { get; init; }
        public string Mensagem { get; init; }
    }
}