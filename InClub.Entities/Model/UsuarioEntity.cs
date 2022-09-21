using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace InClub.Entities
{
    [DataContract]
    public class UsuarioEntity : BaseEntity
    {

        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public int IdUsuario { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public string Usuario { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public string Password { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true)]
        public int Estado  { get; set; }
    }
}
