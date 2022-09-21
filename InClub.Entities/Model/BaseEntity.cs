using System;
using System.Collections.Generic;
using System.Text;

namespace InClub.Entities
{
    public abstract class BaseEntity
    {
        public DateTime DateReg { get; set; }
        public DateTime DateMod { get; set; }
        public int UsrReg { get; set; }
        public int UsrMod { get; set; }
    }
}
