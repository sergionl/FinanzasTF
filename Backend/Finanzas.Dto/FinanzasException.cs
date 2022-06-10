using System;
using System.Collections.Generic;
using System.Text;

namespace Finanzas.Dto
{
    public class FinanzasException : System.SystemException
    {
        public string value { get; set; }
        public FinanzasException() { }

        public FinanzasException(string message)
        : base(message) { }

        public FinanzasException(string message, Exception inner)
        : base(message, inner) { }
        public FinanzasException(string message, string value)
        : this(message)
        {
            this.value = value;
        }
    }
}
