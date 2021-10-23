using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Infrastructure.Exceptions
{
    public class AnoFabricacaoInvalidoException : Exception
    {
        public AnoFabricacaoInvalidoException(string message) : base(message)
        {
        }
    }
}
