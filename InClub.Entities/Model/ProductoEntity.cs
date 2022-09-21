using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace InClub.Entities
{
    [DataContract]
    public class ProductoEntity : BaseEntity
    {

        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public int IdProducto { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public string Descripcion { get; set; }


        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public decimal Precio { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public int Estado { get; set; }
    }
}
