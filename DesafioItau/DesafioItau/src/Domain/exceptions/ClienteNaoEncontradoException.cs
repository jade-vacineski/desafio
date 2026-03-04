using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioItau.src.Domain.exceptions
{
    public class ClienteNaoEncontradoException : DomainException
    {
         public ClienteNaoEncontradoException(string message) : base(message) { }
    }
}
