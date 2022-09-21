using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace InClub.Entities
{
    [DataContract]
    public class CompraEntity : BaseEntity
    {
        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public int IdCompra { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public string Boleta { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public int Numero { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public int Estado { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public decimal Total { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public IEnumerable<DetalleCompraEntity> DetalleCompra { get; set; }
    }
}
