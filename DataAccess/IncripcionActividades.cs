//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
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
    }
}
