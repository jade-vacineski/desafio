using System;
using DesafioItau.src.Domain.Clientes.Entities;
using DesafioItau.src.Domain.ContasGraficas.entities;

namespace DesafioItau.src.Domain.Custodias.Entities
{
    public class Custodia
    {
        public int Id { get; set; }
        public long ContaGraficaId { get; private set; }
        public ContaGrafica ContaGrafica { get; private set; }
        public string Ticker { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal PrecoMedio { get; private set; }
        public DateTime DataAtualizacao { get; private set; }

        private Custodia() { }

        public Custodia(ContaGrafica contaGrafica, string ticker)
        {
            ContaGrafica = contaGrafica;
            ContaGraficaId = contaGrafica.Id;
            Ticker = ticker;
            Quantidade = 0;
            PrecoMedio = 0;
            DataAtualizacao = DateTime.UtcNow;
        }

        public Custodia(Cliente cliente, string ticker)
        {
            Ticker = ticker;
            Quantidade = 0;
            PrecoMedio = 0;
            DataAtualizacao = DateTime.UtcNow;
        }

        public void AtualizarCustodia(decimal quantidade, decimal preco)
        {
            decimal totalInvestido = PrecoMedio * Quantidade + preco * quantidade;
            Quantidade += quantidade;
            PrecoMedio = Quantidade > 0 ? totalInvestido / Quantidade : 0;
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}
