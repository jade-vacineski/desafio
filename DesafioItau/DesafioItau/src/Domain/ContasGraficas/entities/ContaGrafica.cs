using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioItau.src.Domain.ContasGraficas.enums;

namespace DesafioItau.src.Domain.ContasGraficas.entities
{
    public class ContaGrafica
    {
        private object cliente;
        private string v;

        public long Id { get; private set; }
        public long ClienteId { get; private set; }
        public string NumeroConta { get; private set; }
        public TipoConta Tipo { get; private set; }
        public DateTime DataCriacao { get; private set; }

        private ContaGrafica(object cliente) { }

        private ContaGrafica(long clienteId, string numeroConta, TipoConta tipo)
        {
            ClienteId = clienteId;
            NumeroConta = numeroConta;
            Tipo = tipo;
            DataCriacao = DateTime.UtcNow;
        }

        public static ContaGrafica CriarMaster(long clienteId, string numeroConta)
            => new ContaGrafica(clienteId, numeroConta, TipoConta.MASTER);

        public static ContaGrafica CriarFilhote(long clienteId, string numeroConta)
            => new ContaGrafica(clienteId, numeroConta, TipoConta.FILHOTE);
    }
}