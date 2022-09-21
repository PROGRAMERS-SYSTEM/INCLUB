using System;
using System.Collections.Generic;
using System.Text;

namespace InClub.Entities
{
   
    public class UsuarioRequest : OperationRequest<UsuarioEntity>
    {
    }

    public class UsuarioItemRequest : FilterItemRequest<UsuarioFilter, UsuarioFilterItemType>
    {
    }

    public class UsuarioLstItemRequest : FilterLstItemRequest<UsuarioFilter, UsuarioFilterLstItemType>
    {
    }
}
