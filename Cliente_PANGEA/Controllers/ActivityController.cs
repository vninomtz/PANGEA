using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente_PANGEA.Controllers
{
    public class ActivityController
    {

        public static int GetLastActivity()
        {
            int id = 0;
            using (var database = new PangeaConnection())
            {
                id = database.Actividades.ToList().Last().Id;
            }

            return id;
        }
        public static int SaveActivity(Actividades newActivity)
        {
            int result = 0;
            using (var dataBase = new PangeaConnection())
            {
                try
                {
                    dataBase.Actividades.Add(newActivity);
                    result = dataBase.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                }

            }
            return result;

        }
        public static int UpdateActivity(Actividades actividades)
        {
            int result = -1;
            using (var database = new PangeaConnection())
            {
                try
                {
                    var newActivity = database.Actividades.Where(a => a.Id == actividades.Id).SingleOrDefault(); ;
                    if (newActivity != null)
                    {
                        newActivity.Titulo = actividades.Titulo;
                        newActivity.Tipo = actividades.Tipo;
                        newActivity.Descripcion = actividades.Descripcion;
                        newActivity.Costo = actividades.Costo;
                        newActivity.UltimaModificacion = actividades.UltimaModificacion;
                    }
                    result = database.SaveChanges();
                    return result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return result;
        }
        public static List<Horarios> GetActivities(int idEvento)
        {

            using (var dataBase = new PangeaConnection())
            {
                var activityList = dataBase.Horarios.Include("Actividades").Where(a => a.Actividades.IdEvento == idEvento).OrderBy(a => a.FechaInicio).ToList();

                return activityList;
            }


        }
        public static List<Actividades> GetEventActivities(int idEvent)
        {
            int result = -1;
            using (var database = new PangeaConnection())
            {
                try
                {
                    var listActivities = database.Actividades.Where(a => a.IdEvento == idEvent).ToList();
                    return listActivities;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return null;
        }
        public static Actividades GetActivityForUpdate(int idActivity)
        {
            try
            {
                using (var database = new PangeaConnection())
                {
                    var activity = database.Actividades.Where(a => a.Id == idActivity).SingleOrDefault();
                    return activity;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public static int DeleteActivity(int idActivity)
        {
            int result = -1;
            using (var database = new PangeaConnection())
            {
                try
                {
                    var activity = database.Actividades.Include("Horarios").Where(a => a.Id == idActivity).FirstOrDefault();
                    database.Actividades.Remove(activity);
                    result = database.SaveChanges();
                    return result;
                }
                catch (Exception e)
                {

                }
            }
            return result;

        }
        public static List<Actividades> GetAllActivities(int idEvent)
        {
            using (var dataBase = new PangeaConnection())
            {
                var activityList = dataBase.Actividades.Where(a => a.IdEvento == idEvent).ToList();

                return activityList;
            }
        }

        public static int ValidateNotRegisterActivityAssistant(int idActivity, int idAssistant)
        {
            int result = -1;
            using (var database = new PangeaConnection())
            {
                try
                {
                    result = database.IncripcionActividades.Where(i => i.idActividad == idActivity && i.idAsistente == idAssistant).Count();
                    return result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return result;
        }

        public static int RegisterActivityAssistant(int isAssistant, int idActivity)
        {
            int result = -1;
            using (var database = new PangeaConnection())
            {
                IncripcionActividades incripcionActividades = new IncripcionActividades
                {
                    idActividad = idActivity,
                    idAsistente = isAssistant,
                    pago = true,
                    asistencia = false,
                    fecha_inscripcion = DateTime.Now
                };
                try
                {
                    database.IncripcionActividades.Add(incripcionActividades);
                    var activity = database.Actividades.Where(a => a.Id == idActivity).FirstOrDefault();
                    activity.Cupo -= 1;
                    return result = database.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return result;
        }

        public static List<Horarios> GetEventActivitiesSpaceAvaible(int idEvent)
        {
            using (var database = new PangeaConnection())
            {
                try
                {
                    var activityList = database.Horarios.Include("Actividades").Where(a => a.Actividades.IdEvento == idEvent && a.Actividades.Cupo > 0).ToList();
                    return activityList;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return null;
        }

        public static List<Actividades> GetActivitiesWithNullArticle(int idEvent)
        {
            using (var database = new PangeaConnection())
            {
                try
                {
                    var listActivities = database.Actividades.Where(a => a.IdEvento == idEvent && a.IdArticulo == null).ToList();
                    return listActivities;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            return null;
        }

    }
}
