using System;
using System.Collections.Generic;
using System.Text;

namespace InClub.Exceptions
{

    public class FailInsUsuarioException : CustomException
    {
        public override string CustomMessage
        {
            get
            {
                return "fail insert";
            }
        }
    }
}
