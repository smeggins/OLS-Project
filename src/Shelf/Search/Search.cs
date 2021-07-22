using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

public class Search
{
    
    /// <summary>
    /// Accepts a pre-made artist dictionary to search for projects they are working on and returns a list of those entities
    /// </summary>
    /// <param name="searchDic">premade artist Dictionary</param>
    /// <param name="creatorFullName">(video)directors full name, (liturature)Authors full name, (videogame)Developer name, (audio)artists full name</param>
    /// <returns>a list of found entities</returns>
    public static List<Entity> searchByCreator(Dictionary<string, List<Entity>> searchDic, string creatorFullName)
    {
        List<Entity> returnList;
        if (searchDic.ContainsKey(creatorFullName))
        {
            returnList = searchDic[creatorFullName];
        }
        else
        {
            returnList = new List<Entity>();
        }
        return returnList;
    }

    /// <summary>
    /// searches for entities of a type that has a specific genre.
    /// overlaoded for each entity type
    /// </summary>
    /// <param name="shelf">the main dictionary of all items</param>
    /// <param name="genre">the specific genre enum you want to search for</param>
    /// <returns>an IEnumerable of found entities</returns>
    public static IEnumerable<Audio> searchByGenre(Shelf shelf, AudioGenre genre)
    {
        List<Audio> searchList = shelf.LibraryShelf[Format.Audio].Cast<Audio>().ToList();
        IEnumerable<Audio> results = searchList.Where(  v => v.genre.Contains(genre) );

        return results;
    }

    public static IEnumerable<Video> searchByGenre(Shelf shelf, VideoGenre genre)
    {
        List<Video> searchList = shelf.LibraryShelf[Format.Video].Cast<Video>().ToList();
        IEnumerable<Video> results = searchList.Where(v => v.genre.Contains(genre));

        return results;
    }

    public static IEnumerable<VideoGame> searchByGenre(Shelf shelf, VideoGameGenre genre)
    {
        List<VideoGame> searchList = shelf.LibraryShelf[Format.VideoGame].Cast<VideoGame>().ToList();
        IEnumerable<VideoGame> results = searchList.Where(v => v.genre.Contains(genre));

        return results;
    }

    public static IEnumerable<Liturature> searchByGenre(Shelf shelf, LituratureGenre genre)
    {
        List<Liturature> searchList = shelf.LibraryShelf[Format.Liturature].Cast<Liturature>().ToList();
        IEnumerable<Liturature> results = searchList.Where(v => v.genre.Contains(genre));

        return results;
    }

    public static HashSet<User> users = new HashSet<User>();


    public static void searchUserNum(int usernum)
    {
        

        foreach (var user in users)
        {
            if (usernum == User.UserNumber)
            {
                Console.WriteLine(user.firstName);
            }
        }
    }





}