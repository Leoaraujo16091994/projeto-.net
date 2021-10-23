using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Infrastructure.Exceptions
{
    public class AnoModeloInvalidoException : Exception
    {
        public AnoModeloInvalidoException(string message) : base(message)
        {
        }
    }
}
