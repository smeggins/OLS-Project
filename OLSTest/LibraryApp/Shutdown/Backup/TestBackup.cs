using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public static class TestBackup
{
 

    public static bool deleteTest(Shelf preDeleteShelf, Shelf postDeleteShelf)
    {
        bool succeeds = true;

        Shelf shelf = TestShelf.createTestShelf();

        Save.saveShelfToDocumentCSV(shelf, "testFiles/Audio.csv", "testFiles/Video.csv", "testFiles/VideoGame.csv", "testFiles/Liturature.csv");

        //Read Method

        shelf.delete(Format.Liturature, Shelf.searchParam.title, "The Hobbit");
        Save.saveShelfToDocumentCSV(shelf, "testFiles/Audio.csv", "testFiles/Video.csv", "testFiles/VideoGame.csv", "testFiles/Liturature.csv");

        //Read Method

        //Compare

        return false;
    }
}
