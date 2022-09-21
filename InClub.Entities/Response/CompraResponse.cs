using System;
using System.Collections.Generic;
using System.Text;

namespace InClub.Entities
{

    public class CompraResponse : ItemResponse<bool>
    {
    }

    public class CompraItemResponse : ItemResponse<CompraEntity>
    { }

    public class CompraLstItemResponse : LstItemResponse<CompraEntity>
    { }
}
