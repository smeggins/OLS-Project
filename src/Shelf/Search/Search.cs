using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Search
{
    //Abbe
    static Dictionary<string, Entity> Lit;
    static Dictionary<string, Entity> audio;
    static IEnumerable<int> userNumbers; // need to initialize with a list or array of all user numbers

    //Phil
    static Dictionary<string, Entity> videogames;
    static Dictionary<string, Entity> video;

    //Phil
    public static List<Entity> searchByCreator(string creatorName)
    {
        //linq
        return new List<Entity>();
    }

    //Abbe
    public static List<Entity> searchByUser()
    {
        //hashable
        return new List<Entity>();
    }
}

