using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.Exceptions
{
    public class RegisterSuccessfulMessage : Exception
    {
        public RegisterSuccessfulMessage()
        {
        }

        public RegisterSuccessfulMessage(string message)
            : base(message)
        {
        }

        public RegisterSuccessfulMessage(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
