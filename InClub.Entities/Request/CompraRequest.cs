using System;
using System.Collections.Generic;
using System.Text;

namespace InClub.Entities
{


    public class CompraRequest : OperationRequest<CompraEntity>
    {
    }

    public class CompraItemRequest : FilterItemRequest<CompraFilter, CompraFilterItemType>
    {
    }

    public class CompraLstItemRequest : FilterLstItemRequest<CompraFilter, CompraFilterLstItemType>
    {
    }
}
