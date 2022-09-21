using System;
using System.Collections.Generic;
using System.Text;

namespace InClub.Entities
{
   
    public enum UsuarioFilterItemType : byte
    {
        Undefined,
        ById

    }

    public enum UsuarioFilterLstItemType : byte
    {
        Undefined,
        ByPagination,
        ByIdDocumento

    }
}
