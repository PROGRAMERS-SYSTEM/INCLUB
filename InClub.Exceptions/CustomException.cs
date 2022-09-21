using System;
using System.Collections.Generic;
using System.Text;

namespace InClub.Exceptions
{
    public class CustomException : ApplicationException
    {
        public virtual string CustomMessage { get; }

    }
}
