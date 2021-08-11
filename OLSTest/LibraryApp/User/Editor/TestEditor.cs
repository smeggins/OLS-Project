using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TestEditor
{
    public static bool test()
    {
        //Console.WriteLine("Editor Test");
        Shelf shelf = TestShelf.createTestShelf();
        Person person = new Person("Phillip Chadwick");
        Editor editor = new Editor(person, Position.Developer);
        
        bool itemAdded = false;
        bool itemsAdded = false;
        bool itemsDeleted = false;
        bool categoryDeleted = false;
        bool increaseAvailible = false;
        bool decreaseAvailible = false;

        Liturature test = new Liturature("test", LituratureMedium.Book);
        test.authors.Add(new Person("dingle dongle"));
        test.genre.Add(LituratureGenre.Fantasy);
        test.countryOfOrigin = "canada";
        test.pages = 242;

        Liturature test2 = new Liturature("test2", LituratureMedium.Book);
        test.authors.Add(new Person("dingle dongle"));
        test.genre.Add(LituratureGenre.Fantasy);
        test.countryOfOrigin = "canada";
        test.pages = 242;

        editor.addItemToShelf(shelf, Format.Liturature, test);
        if (shelf.LibraryShelf[Format.Liturature].Any(e => e.title == "test"))
        {
            itemAdded = true;
            //Console.WriteLine("itemAdded: " + itemAdded);
        }

        shelf = TestShelf.createTestShelf();

        editor.addItemsToShelf(shelf, Format.Liturature, new List<Entity> {test, test2});

        if (shelf.LibraryShelf[Format.Liturature].Any(e => e.title == "test") && shelf.LibraryShelf[Format.Liturature].Any(e => e.title == "test2"))
        {
            itemsAdded = true;
            //Console.WriteLine("itemsAdded: " + itemsAdded);
        }

        //NOTE: Update Entity was one of the project parts Abbe was supposed to implement during the group portion of
        // of the project. he never did. Therefore, I added an update method that ties into the code he wrote but
        // the code just causes the app to crash so I can't test whether it works.
        
        //editor.updateShelfItem(shelf, Format.Video, "Alien");

        editor.deleteShelfItem(shelf, Format.Video, Shelf.searchParam.title, "Alien");

        if (!shelf.LibraryShelf[Format.Liturature].Any(e => e.title == "Alien"))
        {
            itemsDeleted = true;
            //Console.WriteLine("itemsDeleted: " + itemsDeleted);
        }

        editor.deleteShelfCategory(shelf, Format.Video, true);

        if (!shelf.LibraryShelf.ContainsKey(Format.Video))
        {
            categoryDeleted = true;
            //Console.WriteLine("categoryDeleted: " + categoryDeleted);
        }

        shelf = TestShelf.createTestShelf();

        editor.increaseAvailible(shelf, Format.Video, "Alien", 2);
        
        if (shelf.LibraryShelf[Format.Video].Find(e => e.title == "Alien").copiesTotal == 3)
        {
            increaseAvailible = true;
            //Console.WriteLine("increaseAvailible: " + increaseAvailible);
        }

        editor.decreaseAvailible(shelf, Format.Video, "Alien", 2);

        if (shelf.LibraryShelf[Format.Video].Find(e => e.title == "Alien").copiesTotal == 1)
        {
            decreaseAvailible = true;
            //Console.WriteLine("decreaseAvailible: " + decreaseAvailible);
        }

        if (itemAdded == true && itemsAdded == true && itemsDeleted == true && categoryDeleted == true && increaseAvailible == true && decreaseAvailible == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
