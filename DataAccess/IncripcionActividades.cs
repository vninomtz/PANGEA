//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class IncripcionActividades
    {
       
        public int id { get; set; }
        public bool asistencia { get; set; }
        public bool pago { get; set; }
        public System.DateTime fecha_inscripcion { get; set; }
        public int idActividad { get; set; }
        public int idAsistente { get; set; }
    
        public virtual Actividades Actividades { get; set; }
        public virtual Asistentes Asistentes { get; set; }

        public override string ToString()
        {
            return
                Actividades.Tipo + ": " + Actividades.Titulo + "\nCosto: $" + Actividades.Costo + "    Cupo disponible: " + Actividades.Cupo
                +"\nPago de actividad: Pagado" + "\nAsistencia a Actividad: "+ asistencia;
        }
    }
}
