using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestShelf
{
    public static Shelf createTestShelf()
    {
        Shelf theShelf = new Shelf();

        //CREATE A GENERIC PERSON
        Person newPerson = new Person("Jim", "Jam");
        Person newPerson2 = new Person("Dr", "Jones");

        //CREATE A BOOK
        Liturature theHobbit = new Liturature("The Hobbit", LituratureMedium.Book);
        theHobbit.authors.Add(newPerson);
        theHobbit.authors.Add(newPerson2);
        theHobbit.genre.Add(LituratureGenre.Fantasy);
        theHobbit.genre.Add(LituratureGenre.ActionAdventure);
        theHobbit.genre.Add(LituratureGenre.Anthology);
        theHobbit.genre.Add(LituratureGenre.Action);
        theHobbit.countryOfOrigin = "canada";
        theHobbit.pages = 242;

        Liturature theSecret = new Liturature("The Secret", LituratureMedium.Book);
        theSecret.authors.Add(newPerson);
        theSecret.genre.Add(LituratureGenre.Fantasy);
        theSecret.countryOfOrigin = "canada";
        theSecret.pages = 242;

        //CREATE VIDEOGAME
        List<VideoGameMedium> mediumList = new List<VideoGameMedium>();
        mediumList.Add(VideoGameMedium.PC);
        mediumList.Add(VideoGameMedium.XboxOne);

        VideoGame seaOfThieves = new VideoGame("Sea Of Thieves", mediumList);
        seaOfThieves.publishers.Add(newPerson);
        seaOfThieves.developers.Add("Rare");
        seaOfThieves.genre.Add(VideoGameGenre.Horror);

        VideoGame doom = new VideoGame("Doom", mediumList);
        doom.publishers.Add(newPerson);
        doom.developers.Add("Rare");

        //CREATE VIDEO
        List<VideoMedium> mediumListB = new List<VideoMedium>();
        mediumListB.Add(VideoMedium.Blueray);
        mediumListB.Add(VideoMedium.DVD);

        Video alien = new Video("Alien", mediumListB);
        alien.country = "America";
        alien.directors.Add(newPerson);

        Video theAdamsFamily = new Video("The Adams Family", mediumListB);
        theAdamsFamily.country = "America";
        theAdamsFamily.directors.Add(newPerson);

        //CREATE AUDIO
        List<AudioMedium> mediumListC = new List<AudioMedium>();
        mediumListC.Add(AudioMedium.CD);
        mediumListC.Add(AudioMedium.Digital);

        Audio NAVUZIMETRO = new Audio("NAVUZIMETRO#PT2", mediumListC);
        NAVUZIMETRO.artists.Add(newPerson);
        NAVUZIMETRO.artists.Add(newPerson);
        NAVUZIMETRO.featuredArtists.Add(newPerson);
        NAVUZIMETRO.producers.Add(newPerson);
        NAVUZIMETRO.producers.Add(newPerson);
        NAVUZIMETRO.genre.Add(AudioGenre.HipHop);

        Audio finnegansWake = new Audio("Finnegans Wake", mediumListC);
        finnegansWake.artists.Add(newPerson2);
        finnegansWake.artists.Add(newPerson2);
        finnegansWake.featuredArtists.Add(newPerson2);
        finnegansWake.producers.Add(newPerson2);
        finnegansWake.producers.Add(newPerson2);
        finnegansWake.genre.Add(AudioGenre.HipHop);

        theShelf.add(Format.Video, alien);
        theShelf.add(Format.Video, theAdamsFamily);

        theShelf.add(Format.Audio, NAVUZIMETRO);
        theShelf.add(Format.Audio, finnegansWake);

        theShelf.add(Format.VideoGame, seaOfThieves);
        theShelf.add(Format.VideoGame, doom);

        theShelf.add(Format.Liturature, theHobbit);
        theShelf.add(Format.Liturature, theSecret);


        return theShelf;
    }

    public static void test() 
    {
        Shelf libraryShelf = createTestShelf();
        Console.WriteLine("Begin Testin Shelf:\n");
        Person newPerson = new Person("horkin", "harkin");

        //Test adding via list
        Liturature theSwordOfTruth = new Liturature("The Sword Of Truth", LituratureMedium.Book);
        theSwordOfTruth.authors.Add(newPerson);
        theSwordOfTruth.genre.Add(LituratureGenre.Fantasy);
        theSwordOfTruth.countryOfOrigin = "canada";
        theSwordOfTruth.pages = 242;

        Liturature brawk = new Liturature("Brawk", LituratureMedium.Book);
        brawk.authors.Add(newPerson);
        brawk.genre.Add(LituratureGenre.Fantasy);
        brawk.countryOfOrigin = "canada";
        brawk.pages = 242;

        List<Entity> testList = new List<Entity>();
        testList.Add(brawk);
        testList.Add(theSwordOfTruth);

        //Adding via list
        libraryShelf.add(Format.Liturature, testList);

        //Add Inventory
        int bookIndex = libraryShelf.search(Format.Liturature, Shelf.searchParam.title, "The Sword Of Truth");
        Console.WriteLine("number of sword of truth books before add inventory: " + libraryShelf.LibraryShelf[Format.Liturature][bookIndex].copiesTotal);
        libraryShelf.addInventory(Format.Liturature, "The Sword Of Truth", 2);
        Console.WriteLine("number of sword of truth books after add inventory: " + libraryShelf.LibraryShelf[Format.Liturature][bookIndex].copiesTotal);

        //remove Inventory
        libraryShelf.removeInventory(Format.Liturature, "The Sword Of Truth", 1);
        Console.WriteLine("number of sword of truth books after remove inventory: " + libraryShelf.LibraryShelf[Format.Liturature][bookIndex].copiesTotal);
        Console.WriteLine("\n\n");

        //Search
        bookIndex = libraryShelf.search(Format.Liturature, Shelf.searchParam.title, "The Sword Of Truth");
        Console.WriteLine("title search: The index of the sword of truth book is: " + bookIndex);
        string libraryCode = libraryShelf.LibraryShelf[Format.Liturature][bookIndex].libraryCode;
        Console.WriteLine("library Code search: The index of the sword of truth book is: " + libraryShelf.search(Format.Liturature, Shelf.searchParam.libraryCode, libraryCode));
        Console.WriteLine("searching for a book that doesn't exist: " + libraryShelf.search(Format.Liturature, Shelf.searchParam.title, "JIM JAM"));
        Console.WriteLine("\n\n");

        //Read
        Console.WriteLine("reading the book info from shelf:\n");
        libraryShelf.read(Format.Liturature, "The Sword Of Truth");
        

        Console.WriteLine("\nFinished Testing Shelf");
    }

}
