using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cliente_PANGEA.Controllers
{
    public class TrackController
    {
       public static List<Tracks> GetTracks(int idEvento)
        {
           var tracksList = new List<Tracks>();
            using (var dataBase = new PangeaConnection())
            {
                try
                {
                    tracksList = dataBase.Tracks.Where(track => track.IdEvento == idEvento).ToList<Tracks>();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Tracks track = new Tracks();
                    tracksList.Add(track);
                }
            }

            return tracksList;
        }

        public static int AddTrack(Tracks infoTrack)
        {
            int result = -1;
            Tracks newTrack = new Tracks
            {
                Nombre = infoTrack.Nombre,
                Descripcion = infoTrack.Descripcion
            };

            using(var dataBase = new PangeaConnection())
            {
                try
                {
                   dataBase.Tracks.Add(newTrack);
                   result = dataBase.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    result = -1;
                }
            }

            return result;
        }

        public static int DeleteTrack(int idTrack)
        {
            int result = -1;

            using(var dataBase = new PangeaConnection())
            {
                try
                {
                    var track = dataBase.Tracks.Where(tracks => tracks.Id == idTrack).FirstOrDefault();
                    dataBase.Tracks.Remove(track);
                    result = dataBase.SaveChanges();
                }
                catch (Exception ex )
                {
                    Console.WriteLine(ex.Message);
                 
                }

            }
            return result;
        }
    }
}
