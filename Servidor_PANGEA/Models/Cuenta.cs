using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor_PANGEA.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
        public string Token { get; set; }
        public Nullable<DateTime> UltimoAcceso { get; set; }
        

    }
}
