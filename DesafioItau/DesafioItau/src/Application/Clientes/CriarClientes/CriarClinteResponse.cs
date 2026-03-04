namespace DesafioItau.src.Application.Clientes.CriarClientes
{
    public record CriarClienteResponse
    {
        public long ClienteId { get; init; }
        public string Nome { get; init; }
        public string Cpf { get; init; }
        public string Email { get; init; }
        public decimal ValorMensal { get; init; }
        public bool Ativo { get; init; }
        public DateTime DataAdesao { get; init; }
        public ContaGraficaResponse ContaGrafica { get; init; }
    }


}
