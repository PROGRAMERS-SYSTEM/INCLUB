using System;
using System.Collections.Generic;
using System.Text;

namespace InClub.Entities
{
    
    public enum CompraFilterItemType : byte
    {
        Undefined,
        ById

    }

    public enum CompraFilterLstItemType : byte
    {
        Undefined,
        ByPagination,
        ByIdDocumento

    }
}
