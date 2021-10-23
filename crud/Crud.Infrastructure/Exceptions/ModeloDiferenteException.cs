using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Infrastructure.Exceptions
{
    public class ModeloDiferenteException : Exception
    {
        public ModeloDiferenteException(string message) : base(message)
        {
        }
    }
}
