using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class TestUpdate
{
    public static Shelf createUpdateShelf()
    {
        Shelf shelf = new Shelf();
        shelf.LibraryShelf[Format.Video].Add(new Video("StarWars", new List<VideoMedium>() { VideoMedium.DVD }));
        shelf.LibraryShelf[Format.Liturature].Add(new Liturature("Mad", LituratureMedium.Magazine));

        Liturature theHobbit = new Liturature("The Hobbit", LituratureMedium.Book);
        theHobbit.authors.Add(new Person("JRR", "Tolken"));
        theHobbit.genre.Add(LituratureGenre.Fantasy);
        theHobbit.genre.Add(LituratureGenre.ActionAdventure);
        theHobbit.genre.Add(LituratureGenre.Anthology);
        theHobbit.genre.Add(LituratureGenre.Action);
        theHobbit.countryOfOrigin = "canada";
        theHobbit.setIn = "Middle Earth";
        theHobbit.pages = 242;
        shelf.LibraryShelf[Format.Liturature].Add(theHobbit);


        return shelf;
    }

    public static bool testUpdateXml()
    {
        bool succeeds = false;

        Shelf shelf = TestShelf.createXMLTestShelf();
        Save.saveShelfToDocumentXML(createUpdateShelf(), "testFiles/xmlUpdateTest/audio", "testFiles/xmlUpdateTest/video", "testFiles/xmlUpdateTest/videoGame", "testFiles/xmlUpdateTest/liturature");

        shelf = Update.updateXml(shelf, "testFiles/xmlUpdateTest/audio", "testFiles/xmlUpdateTest/video", "testFiles/xmlUpdateTest/videoGame", "testFiles/xmlUpdateTest/liturature");

        if(shelf.LibraryShelf[Format.Video].Any(e => e.title == "StarWars") && shelf.LibraryShelf[Format.Liturature].Any(e => e.title == "Mad") && (shelf.LibraryShelf[Format.Liturature].First(e => e.title == "The Hobbit") as Liturature).setIn == "Middle Earth"  )
        {
            succeeds = true;
        }

        return succeeds;
    }

    public static bool testUpdateJson()
    {
        bool succeeds = false;

        Shelf shelf = TestShelf.createXMLTestShelf();
        Save.saveShelfToDocumentJson(createUpdateShelf(), "testFiles/jsonUpdateTest/shelf");
        shelf = Update.update(shelf, Load.loadJson("testFiles/jsonUpdateTest/shelf"));

        if (shelf.LibraryShelf[Format.Video].Any(e => e.title == "StarWars") && shelf.LibraryShelf[Format.Liturature].Any(e => e.title == "Mad") && (shelf.LibraryShelf[Format.Liturature].First(e => e.title == "The Hobbit") as Liturature).setIn == "Middle Earth")
        {
            succeeds = true;
        }

        return succeeds;
    }
}
