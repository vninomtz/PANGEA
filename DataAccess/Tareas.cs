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
    
    public partial class Tareas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public bool Finalizada { get; set; }
        public string Responsable { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaFinalizacion { get; set; }
        public int IdActividad { get; set; }
    
        public virtual Actividades Actividades { get; set; }
    }
}
