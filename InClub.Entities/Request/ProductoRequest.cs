using System;
using System.Collections.Generic;
using System.Text;

namespace InClub.Entities
{
   
    public class ProductoRequest : OperationRequest<ProductoEntity>
    {
    }

    public class ProductoItemRequest : FilterItemRequest<ProductoFilter, ProductoFilterItemType>
    {
    }

    public class ProductoLstItemRequest : FilterLstItemRequest<ProductoFilter, ProductoFilterLstItemType>
    {
    }
}
