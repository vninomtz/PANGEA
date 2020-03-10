using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor_PANGEA.Models
{
    public class Personal
    {
        public int Id { get; set; }
        public bool Asignado { get; set; }
        public string Cargo { get; set; }

        public virtual Cuenta Cuenta { get; set; }
        public virtual Evento Evento { get; set; }
    }
}
