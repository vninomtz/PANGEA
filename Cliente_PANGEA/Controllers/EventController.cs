using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente_PANGEA.Controllers
{
    class EventController
    {
        public static List<Personal> GetPersonalAndEvent(int idaccount)
        {
            List<Personal> personalList;
            using (var dataBase = new PangeaConnection())
            {
                personalList = dataBase.Personal.Include("Eventos").Where(p => p.IdCuenta == idaccount).ToList<Personal>();

                foreach (var p  in personalList)
                {
                    Console.WriteLine(p.Eventos.Nombre);
                }
            }
            return personalList;
        }       

        public static Eventos GetEventById(int id)
        {
            Eventos evento;
            using (var dataBase = new PangeaConnection())
            {
                evento = dataBase.Eventos.Where(e => e.Id == id).FirstOrDefault();
            }

            return evento;
        }

        public static int UpdateEvent(Eventos infoEvento)
        {
            
            int result = -1;
            
            using (var dataBase = new PangeaConnection())
            {
                try
                {
                    var evento = dataBase.Eventos.Where(e => e.Id == infoEvento.Id).FirstOrDefault();
                    evento.Nombre = infoEvento.Nombre;
                    evento.Gratuito = infoEvento.Gratuito;
                    evento.Lugar = infoEvento.Lugar;
                    evento.Costo = infoEvento.Costo;
                    evento.FechaFin = infoEvento.FechaFin.Date;
                    evento.FechaInicio = infoEvento.FechaInicio.Date;
                    evento.Descripcion = infoEvento.Descripcion;
                   
                    
                    result = dataBase.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error en la conexión a la BD" + e);

                }
            }
            return result;
        }
        public static int SaveEvent(Eventos evento)
        {
            int result = -1;
            using (var dataBase = new PangeaConnection())
            {
                try
                {
                    dataBase.Eventos.Add(evento);
                    result = dataBase.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error en la conexión a la BD" + e);

                }
            }
            return result;
        }

        public static List<Eventos> GetEvents()
        {
     
            using (var dataBase = new PangeaConnection())
            {
                var eventList = dataBase.Eventos.ToList<Eventos>();
                return eventList;
            }

            
        }
    }
}
