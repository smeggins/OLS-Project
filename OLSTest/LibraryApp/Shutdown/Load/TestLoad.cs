using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class TestLoad
{
    public static List<List<string>> entitiesToStrings(List<Entity> entities)
    {
        List<List<string>> strings = new List<List<string>>();

        foreach (var item in entities)
        {
            Video videoCast = item as Video;
            Liturature lituratureCast = item as Liturature;


            if (videoCast != null)
            {
                strings.AddRange(videoCast.GetValues());
            }
            else if (lituratureCast != null)
            {
                strings.AddRange(lituratureCast.GetValues());
            }
        }

        return strings;
    }

    public static bool testreadXmlToVideo()
    {
        bool succeeds = true;
        List<List<string>> before;
        List<List<string>> after;

        Shelf shelf = TestShelf.createTestShelf();
        Save.saveShelfToDocumentXML(shelf, "testFiles/testreadXmlToVideo/audio", "testFiles/testreadXmlToVideo/video", "testFiles/testreadXmlToVideo/videoGame", "testFiles/testreadXmlToVideo/liturature");

        before = entitiesToStrings(shelf.LibraryShelf[Format.Video]);

        if (before.Count > 0)
        {
            shelf = null;
            shelf = Load.loadXml("testFiles/testreadXmlToVideo/audio", "testFiles/testreadXmlToVideo/video", "testFiles/testreadXmlToVideo/videoGame", "testFiles/testreadXmlToVideo/liturature");

            after = entitiesToStrings(shelf.LibraryShelf[Format.Video]);

            succeeds = Test.compareListsofLists<string>(before, after);
        }
        else
        {
            succeeds = false;
        }

        return succeeds;
    }

    public static bool testreadXmlToLiturature()
    {
        bool succeeds = true;
        List<List<string>> before;
        List<List<string>> after;

        Shelf shelf = TestShelf.createTestShelf();
        Save.saveShelfToDocumentXML(shelf, "testFiles/testreadXmlToLiturature/audio", "testFiles/testreadXmlToLiturature/video", "testFiles/testreadXmlToLiturature/videoGame", "testFiles/testreadXmlToLiturature/liturature");

        before = entitiesToStrings(shelf.LibraryShelf[Format.Liturature]);

        if (before.Count > 0)
        {
            shelf = null;
            shelf = Load.loadXml("testFiles/testreadXmlToLiturature/audio", "testFiles/testreadXmlToLiturature/video", "testFiles/testreadXmlToLiturature/videoGame", "testFiles/testreadXmlToLiturature/liturature");

            after = entitiesToStrings(shelf.LibraryShelf[Format.Liturature]);

            succeeds = Test.compareListsofLists<string>(before, after);
        }
        else
        {
            succeeds = false;
        }

        return succeeds;
    }

    public static Shelf testXml()
    {
        return Load.loadXml("testFiles/xmlTest/audio", "testFiles/xmlTest/video", "testFiles/xmlTest/videoGame", "testFiles/xmlTest/liturature");
    }
}
