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

            Console.WriteLine( TestSearch.testcreatorNameSearch(libraryShelf));

            //TODO
            // Use filestream to write and read the list of items in your application
            // this means generate your library stock from  a file and write any update those files with any 
            // new entities added or updated inside of each format type

            // create an application class in a new project called library app
        }
    }
}
