using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioItau.src.Domain.exceptions
{
  public abstract class CpfException : Exception
  {
      public CpfException(string message) : base(message)
      {
      }
  }
}