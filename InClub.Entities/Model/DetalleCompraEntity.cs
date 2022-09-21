using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
namespace InClub.Entities
{
    [DataContract]
    public class DetalleCompraEntity:BaseEntity
    {
        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public int IdDetalleCompra { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public int IdCompra { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public string Descripcion { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public int Estado { get; set; }

    }
}
