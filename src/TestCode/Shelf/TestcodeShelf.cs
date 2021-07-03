using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestcodeShelf
{
    public static Shelf createTestShelf()
    {
        Shelf theShelf = new Shelf();

        //CREATE A BOOK
        Liturature theHobbit = new Liturature("The Hobbit", LituratureMedium.Book);
        theHobbit.authors.Add("JRR. Tolken");
        theHobbit.genre.Add(VideoAndLituratureGenre.Fantasy);
        theHobbit.countryOfOrigin = "canada";
        theHobbit.pages = 242;

        Liturature theSecret = new Liturature("The Secret", LituratureMedium.Book);
        theSecret.authors.Add("JRR. Tolken");
        theSecret.genre.Add(VideoAndLituratureGenre.Fantasy);
        theSecret.countryOfOrigin = "canada";
        theSecret.pages = 242;

        //CREATE VIDEOGAME
        List<VideoGameMedium> mediumList = new List<VideoGameMedium>();
        mediumList.Add(VideoGameMedium.PC);
        mediumList.Add(VideoGameMedium.XboxOne);

        VideoGame seaOfThieves = new VideoGame("Sea Of Thieves", mediumList);
        seaOfThieves.publishers.Add("Microsoft");
        seaOfThieves.developers.Add("Rare");

        VideoGame doom = new VideoGame("Doom", mediumList);
        doom.publishers.Add("Microsoft");
        doom.developers.Add("Rare");

        //CREATE VIDEO
        List<VideoMedium> mediumListB = new List<VideoMedium>();
        mediumListB.Add(VideoMedium.Blueray);
        mediumListB.Add(VideoMedium.DVD);

        Video alien = new Video("Alien", mediumListB);
        alien.country = "America";
        alien.director = "Ridley Scott";

        Video theAdamsFamily = new Video("The Adams Family", mediumListB);
        theAdamsFamily.country = "America";
        theAdamsFamily.director = "Ridley Scott";

        //CREATE AUDIO
        List<AudioMedium> mediumListC = new List<AudioMedium>();
        mediumListC.Add(AudioMedium.CD);
        mediumListC.Add(AudioMedium.Digital);

        Audio NAVUZIMETRO = new Audio("NAVUZIMETRO#PT2", mediumListC);
        NAVUZIMETRO.artists.Add("Nav");
        NAVUZIMETRO.artists.Add("Metro Boomin");
        NAVUZIMETRO.featuredArtists.Add("Lil Uzi Vert");
        NAVUZIMETRO.producers.Add("Nav");
        NAVUZIMETRO.producers.Add("Metro Boomin");
        NAVUZIMETRO.genre.Add(AudioGenre.HipHop);

        Audio finnegansWake = new Audio("Finnegans Wake", mediumListC);
        finnegansWake.artists.Add("Nav");
        finnegansWake.artists.Add("Metro Boomin");
        finnegansWake.featuredArtists.Add("Lil Uzi Vert");
        finnegansWake.producers.Add("Nav");
        finnegansWake.producers.Add("Metro Boomin");
        finnegansWake.genre.Add(AudioGenre.HipHop);

        theShelf.add(entityTypes.Video, alien);
        theShelf.add(entityTypes.Video, theAdamsFamily);

        theShelf.add(entityTypes.Audio, NAVUZIMETRO);
        theShelf.add(entityTypes.Audio, finnegansWake);

        theShelf.add(entityTypes.VideoGame, seaOfThieves);
        theShelf.add(entityTypes.VideoGame, doom);

        theShelf.add(entityTypes.Liturature, theHobbit);
        theShelf.add(entityTypes.Liturature, theSecret);


        return theShelf;

        //theShelf.search(entityTypes.Liturature, Shelf.searchParam, )
    }

    public static void test() 
    {
        Shelf libraryShelf = createTestShelf();
        Console.WriteLine("Begin Test:\n");

        //Test adding via list
        Liturature theSwordOfTruth = new Liturature("The Sword Of Truth", LituratureMedium.Book);
        theSwordOfTruth.authors.Add("JRR. Tolken");
        theSwordOfTruth.genre.Add(VideoAndLituratureGenre.Fantasy);
        theSwordOfTruth.countryOfOrigin = "canada";
        theSwordOfTruth.pages = 242;

        Liturature brawk = new Liturature("Brawk", LituratureMedium.Book);
        brawk.authors.Add("JRR. Tolken");
        brawk.genre.Add(VideoAndLituratureGenre.Fantasy);
        brawk.countryOfOrigin = "canada";
        brawk.pages = 242;

        List<Entity> testList = new List<Entity>();
        testList.Add(brawk);
        testList.Add(theSwordOfTruth);

        //Adding via list
        libraryShelf.add(entityTypes.Liturature, testList);

        
        
        //Add Inventory
        

        //int bookIndex = libraryShelf.search(entityTypes.Liturature, Shelf.searchParam.title, "The Sword Of Truth");
        //Console.WriteLine("number of sword of truth books before add inventory: " + libraryShelf.LibraryShelf[entityTypes.Liturature][bookIndex].copiesTotal);
        libraryShelf.addInventory(entityTypes.Liturature, "The Sword Of Truth", 2);
        //Console.WriteLine("number of sword of truth books after add inventory: " + libraryShelf.LibraryShelf[entityTypes.Liturature][bookIndex].copiesTotal);

        //remove Inventory
        libraryShelf.removeInventory(entityTypes.Liturature, "The Sword Of Truth", 1);
        //Console.WriteLine("number of sword of truth books after remove inventory: " + libraryShelf.LibraryShelf[entityTypes.Liturature][bookIndex].copiesTotal);
        Console.WriteLine("\n\n");


        //Search
        libraryShelf.search(entityTypes.Liturature, Shelf.searchParam.title, "The Sword Of Truth");
        //Console.WriteLine("title search: The index of the sword of truth book is: " + bookIndex);
        //string libraryCode = libraryShelf.LibraryShelf[entityTypes.Liturature][bookIndex].libraryCode;
        //Console.WriteLine("library Code search: The index of the sword of truth book is: " + libraryShelf.search(entityTypes.Liturature, Shelf.searchParam.libraryCode, libraryCode));
        //Console.WriteLine("searching for a book that doesn't exist: " + libraryShelf.search(entityTypes.Liturature, Shelf.searchParam.title, "JIM JAM"));
        Console.WriteLine("\n\n");
        

        //Read
        //Console.WriteLine("reading the book info from shelf:\n");
        libraryShelf.read(entityTypes.Liturature, "The Sword Of Truth");
        

        Console.WriteLine("\nFinished Testing");



        libraryShelf.updateItem(entityTypes.Liturature, "Brawk", "new Brawk");



    }

}
