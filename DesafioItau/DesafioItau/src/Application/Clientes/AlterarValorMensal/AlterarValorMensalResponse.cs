using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioItau.src.Application.Clientes.AlterarValorMensal
{
    public record AlterarValorMensalResponse
    {
        public long ClienteId { get; init; }
        public decimal ValorMensalAnterior { get; init; }
        public decimal ValorMensalNovo { get; init; }
        public DateTime DataAlteracao { get; init; }
        public string Mensagem { get; init; }
    }
}