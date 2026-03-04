namespace DesafioItau.src.Domain.Distribuicoes
{
    public class Distribuicao
    {
        public long Id { get; private set; }
        public long OrdemCompraId { get; private set; }
        public long CustodiaFilhoteId { get; private set; }
        public string Ticker { get; private set; } = string.Empty;
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public DateTime DataDistribuicao { get; private set; }

        private Distribuicao() { }

        private Distribuicao(
            long ordemCompraId,
            long custodiaFilhoteId,
            string ticker,
            int quantidade,
            decimal precoUnitario,
            DateTime dataDistribuicao)
        {
            OrdemCompraId = ordemCompraId;
            CustodiaFilhoteId = custodiaFilhoteId;
            Ticker = ticker;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            DataDistribuicao = dataDistribuicao;
        }

        public static Distribuicao Criar(
            long ordemCompraId,
            long custodiaFilhoteId,
            string ticker,
            int quantidade,
            decimal precoUnitario,
            DateTime dataDistribuicao)
        {
            return new Distribuicao(
                ordemCompraId,
                custodiaFilhoteId,
                ticker,
                quantidade,
                precoUnitario,
                dataDistribuicao);
        }
    }
}
