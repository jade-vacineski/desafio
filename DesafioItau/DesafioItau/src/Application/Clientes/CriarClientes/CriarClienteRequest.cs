namespace DesafioItau.src.Application.Clientes.CriarClientes
{
    public record CriarClienteRequest
    {
        public string Nome { get; init; }
        public string Cpf { get; init; }
        public string Email { get; init; }
        public decimal ValorMensal { get; init; }
    }
}