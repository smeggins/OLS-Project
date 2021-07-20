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
            //Shelf libraryShelf = TestShelf.createTestShelf();

<<<<<<< Updated upstream
            TestShutdown.testCloseApp();
=======
            TestSearch.testGenreSearch(libraryShelf);

            //TestSearch.searchUserNum(1);

            SearchRecepticles.instantiateSearchDictionaries(libraryShelf);
            List<Entity> results = Search.searchByCreator(SearchRecepticles.video, "Jim Jam");

            foreach (var item in results)
            {
                Console.WriteLine(item.title);
            }

            //List<Entity> testList = new List<Entity>();
            //testList.Add(TestShelf);
            
            TestSearch.testcreatorNameSearch(libraryShelf);
            TestShelf.test();
            

            //CREATING A USER
            User user1 = new User("Bob", "Jenkins");
            User user2 = new User("Andrew", "Chen");

            user1.printInfo();
            user2.printInfo();


            //HashSet<User> userNumbersList = new HashSet<User>();
            //userNumbersList.Add(user1);
            //userNumbersList.Add(user2);

            Search.users.Add(user1);
            Search.users.Add(user2);

            Search.searchUserNum(1);

            //Console.WriteLine("hello");

>>>>>>> Stashed changes
        }

    }
}
