using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Servidor_PANGEA.Models.Context
{
    public class EventoContext : DbContext
    {
        public EventoContext(DbContextOptions<EventoContext> options) : base(options)
        {

        }
        public virtual DbSet<Evento> EventoSet { get; set; }
    }
}
