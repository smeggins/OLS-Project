using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLSTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Shelf libraryShelf = TestShelf.createTestShelf();

            //TestSearch.testGenreSearch(libraryShelf);

            //SearchRecepticles.instantiateSearchDictionaries(libraryShelf);
            //List<Entity> results = Search.searchByCreator(SearchRecepticles.video, "Jim Jam");

            //foreach (var item in results)
            //{
            //    Console.WriteLine(item.title);
            //}

            TestSearch.testcreatorNameSearch(libraryShelf);
        }
    }
}
