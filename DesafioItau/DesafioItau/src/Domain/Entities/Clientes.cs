namespace DesafioItau.src.Domain.Entities
{
    public class Clientes
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal ValorMensal { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataAdesao { get; set; }
    }
}