using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Cliente_PANGEA.Controllers
{
    public class ArticleController
    {
        public static int SaveArticle(Articulos article, int idTrack)
        {
            int result = -1;
            article.idTrack = idTrack;
            using (var database = new PangeaConnection())
            {
                try
                {
                    database.Articulos.Add(article);
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

        public static List<Tracks> GetEventTracks(int idEvent)
        {
            using (var database = new PangeaConnection())
            {
                try
                {
                    var trackList = database.Tracks.Where(t => t.IdEvento == idEvent).ToList();
                    return trackList;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return null;
        }
        public static bool ValidateRegisterArticleInTrack(Articulos article, int idTrack)
        {
            using (var database = new PangeaConnection())
            {
                try
                {
                    var isRegister = database.Articulos.Where(a => a.nombre == article.nombre && a.idTrack == idTrack).FirstOrDefault();
                    if (isRegister == null)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return false;
        }
    }
}
