using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor_PANGEA.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Lugar { get; set; }
        public int CodigoEvento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Gratuito { get; set; }
        public float Costo { get; set; }
        public bool Cancelado { get; set; }
        
        public virtual Cuenta LiderEvento { get; set; }

    }
}
