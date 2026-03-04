using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioItau.src.Domain.exceptions
{
    public class ValorMensalInvalidoException : DomainException
    {
        public ValorMensalInvalidoException()
            : base("Valor mensal deve ser maior que zero.")
        {
        }
    }

    public class ClienteJaInativoException : DomainException
    {
        public ClienteJaInativoException()
            : base("Cliente já está inativo.")
        {
        }
    }
}