using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.Exceptions
{
    public class UserFoundMessage : Exception
    {
        public UserFoundMessage()
        {
        }

        public UserFoundMessage(string message)
            : base(message)
        {
        }

        public UserFoundMessage(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
