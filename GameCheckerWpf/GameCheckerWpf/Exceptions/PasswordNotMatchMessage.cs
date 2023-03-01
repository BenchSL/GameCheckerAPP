using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.Exceptions
{
    public class PasswordNotMatchMessage : Exception
    {
        public PasswordNotMatchMessage()
        {
        }

        public PasswordNotMatchMessage(string message)
            : base(message)
        {
        }

        public PasswordNotMatchMessage(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
