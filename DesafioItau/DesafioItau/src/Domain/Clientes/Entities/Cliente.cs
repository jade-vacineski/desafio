using DesafioItau.src.Domain.exceptions;

namespace DesafioItau.src.Domain.Clientes.Entities{
    public class Cliente
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public decimal ValorMensal { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataAdesao { get; private set; }

        private Cliente() { }

        private Cliente(string nome, string cpf, string email, decimal valorMensal)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            ValorMensal = valorMensal;
            Ativo = true;
            DataAdesao = DateTime.UtcNow;
        }

        public static Cliente Criar(
       string nome,
       string cpf,
       string email,
       decimal valorMensal)
        {
            if (valorMensal <= 0)
                throw new ValorMensalInvalidoException();

            return new Cliente(nome, cpf, email, valorMensal);
        }

        public void Desativar()
        {
            if (!Ativo)
                throw new ClienteJaInativoException();

            Ativo = false;
        }

    }
}