namespace DesafioItau.src.Domain.exceptions
{
    public class ClienteCpfDuplicadoException : CpfException
    {
        public string Codigo => "CLIENTE_CPF_DUPLICADO";

        public ClienteCpfDuplicadoException()
            : base("CPF ja cadastrado no sistema.")
        {
        }
    }
}
