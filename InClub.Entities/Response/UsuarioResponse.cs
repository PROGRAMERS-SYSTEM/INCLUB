using System;
using System.Collections.Generic;
using System.Text;

namespace InClub.Entities
{

    public class UsuarioResponse : ItemResponse<bool>
    {
    }

    public class UsuarioItemResponse : ItemResponse<UsuarioEntity>
    { }

    public class UsuarioLstItemResponse : LstItemResponse<UsuarioEntity>
    { }
}
