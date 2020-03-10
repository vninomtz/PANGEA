using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor_PANGEA.Models
{
    public class Comite
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }

        public virtual Personal LiderComite { get; set; }
        public virtual ICollection<Personal> MiembrosComite { get; set; }

    }
}
