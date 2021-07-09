using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class TestSearch
{
    public static void testGenreSearch(Shelf shelf)
    {
        // found item results

        Console.WriteLine("Searching Liturature for Fantasy");

        IEnumerable<Liturature> lituratureResults = Search.searchByGenre(shelf, LituratureGenre.Fantasy);
        foreach (var item in lituratureResults)
        {
            Console.WriteLine("found Items: ");
            Console.WriteLine(item.title);
        }

        Console.WriteLine("Searching VideoGame for Horror");

        IEnumerable<VideoGame> videoGameResults = Search.searchByGenre(shelf, VideoGameGenre.Horror);
        foreach (var item in videoGameResults)
        {
            Console.WriteLine("found Items: ");
            Console.WriteLine(item.title);
        }

        Console.WriteLine("Searching Video for Fantasy");

        IEnumerable<Video> videoResults = Search.searchByGenre(shelf, VideoGenre.Fantasy);
        foreach (var item in videoResults)
        {
            Console.WriteLine("found Items: ");
            Console.WriteLine(item.title);
        }

        Console.WriteLine("Searching Audio for Rap");

        IEnumerable<Audio> audioResults = Search.searchByGenre(shelf, AudioGenre.Rap);
        foreach (var item in audioResults)
        {
            Console.WriteLine("found Items: ");
            Console.WriteLine(item.title);
        }
    }

    public static void testcreatorNameSearch(Shelf shelf)
    {
        SearchRecepticles.instantiateSearchDictionaries(shelf);
        List<Entity> videoResults = Search.searchByCreator(SearchRecepticles.video, "Jim Jam");

        Console.WriteLine("Found items: ");

        foreach (var item in videoResults)
        {
            Console.WriteLine(item.title);
        }

        List<Entity> videoGameResults = Search.searchByCreator(SearchRecepticles.videoGame, "Rare");

        Console.WriteLine("Found items: ");

        foreach (var item in videoGameResults)
        {
            Console.WriteLine(item.title);
        }
    }
}
