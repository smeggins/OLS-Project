using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public static class TestBackup
{
    /// <summary>
    /// Creates a test shelf, writes the contents to a csv file, then reads and saves the info on that file.
    /// Does this again after deleting an item
    /// finally it compares the results of both reads to make sure they are not identical
    /// </summary>
    /// <returns>true or false depending on whether the items are the same or not</returns>
    public static bool deleteTest()
    {
        bool succeeds = false;
        List<string[]> beforeDelete = new List<string[]>();
        List<string[]> afterDelete = new List<string[]>();

        Shelf shelf = TestShelf.createTestShelf();

        Save.saveShelfToDocumentCSV(shelf, "testFiles/deleteTest/Audio", "testFiles/deleteTest/Video", "testFiles/deleteTest/VideoGame", "testFiles/deleteTest/Liturature");

        beforeDelete = Test.readToList("testFiles/deleteTest/Audio.csv", "testFiles/deleteTest/Video.csv", "testFiles/deleteTest/VideoGame.csv", "testFiles/deleteTest/Liturature.csv");

        shelf.delete(Format.Liturature, Shelf.searchParam.title, "The Hobbit");
        Save.saveShelfToDocumentCSV(shelf, "testFiles/deleteTest/Audio", "testFiles/deleteTest/Video", "testFiles/deleteTest/VideoGame", "testFiles/deleteTest/Liturature");

        afterDelete = Test.readToList("testFiles/deleteTest/Audio.csv", "testFiles/deleteTest/Video.csv", "testFiles/deleteTest/VideoGame.csv", "testFiles/deleteTest/Liturature.csv");

        for (int i = 0; i < beforeDelete.Count; i++)
        {
            if (beforeDelete[i].Length != afterDelete[i].Length)
            {
                if (beforeDelete[i].Contains("title, The Hobbit") && !afterDelete[i].Contains("title, The Hobbit"))
                {
                    succeeds = true;
                    break;
                }
            }
        }

        return succeeds;
    }
}
