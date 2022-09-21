using System;
using System.Collections.Generic;
using System.Text;

namespace InClub.Entities
{

    public enum ProductoFilterItemType : byte
    {
        Undefined,
        ById

    }

    public enum ProductoFilterLstItemType : byte
    {
        Undefined,
        ByPagination,
        ByIdDocumento

    }
}
