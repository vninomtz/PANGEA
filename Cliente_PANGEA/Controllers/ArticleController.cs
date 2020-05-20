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
        public static int SaveArticleInActivity(Actividades activity, int idArticle)
        {
            int result = -1;
            using (var database = new PangeaConnection())
            {
                try
                {
                    var newActivity = database.Actividades.Where(a => a.Id == activity.Id).FirstOrDefault();
                    newActivity.IdArticulo = idArticle;
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
        public static int UpdateArticleInActivity(Actividades activity)
        {
            int result = -1;
            using (var database = new PangeaConnection())
            {
                try
                {
                    var newArticle = database.Actividades.Where(a => a.Id == activity.Id).FirstOrDefault();
                    newArticle.Articulos.archivo = activity.Articulos.archivo;
                    newArticle.Articulos.ultima_actualizacion = DateTime.Now;
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
        public static int GetLastIdArticle()
        {
            int idArticle = 0;
            using (var database = new PangeaConnection())
            {
                idArticle = database.Articulos.ToList().Last().id;
            }
            return idArticle;

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
        public static List<Actividades> GetArticlesEvent(int idEvent)
        {
            using (var database = new PangeaConnection())
            {
                try
                {
                    var articleList = database.Actividades.Include("Articulos").Where(a=>a.IdEvento == idEvent && a.IdArticulo!=null).ToList();
                    return articleList;

                }catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return null;
        }
        public static List<Actividades> GetArticlesByName(int idEvent, String articleName)
        {
            using (var database = new PangeaConnection())
            {
                try
                {
                    var articleListByName = database.Actividades.Include("Articulos").Where(a=>a.IdEvento == idEvent && a.Articulos.nombre.Contains(articleName)).ToList();
                    return articleListByName;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return null;
        }
        public static List<Tracks> GetTrackById(int idTrack)
        {
            using (var database = new PangeaConnection())
            {
                try
                {
                    var listTracks = database.Tracks.Where(t => t.Id == idTrack).ToList();
                    return listTracks;
                }catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return null;
        }
    }
}
