using System;
using System.Collections.Generic;
using System.Text;

namespace InClub.Entities
{
    
    public class ProductoResponse : ItemResponse<bool>
    {
    }

    public class ProductoItemResponse : ItemResponse<ProductoEntity>
    { }

    public class ProductoLstItemResponse : LstItemResponse<ProductoEntity>
    { }
}
