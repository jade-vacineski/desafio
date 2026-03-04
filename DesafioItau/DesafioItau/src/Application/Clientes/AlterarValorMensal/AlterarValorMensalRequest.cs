namespace DesafioItau.src.Application.Clientes.AlterarValorMensal
{
    public record AlterarValorMensalRequest
    {
        public decimal NovoValorMensal { get; init; }
    }
}
