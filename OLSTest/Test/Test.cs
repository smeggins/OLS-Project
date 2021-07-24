using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public static class Test
{
    /// <summary>
    /// accepts 2 lists of the same type and checks to see if they are identical
    /// </summary>
    /// <typeparam name="T">Must be a basic type (string, int, double, char, etc)</typeparam>
    /// <param name="list1"></param>
    /// <param name="list2"></param>
    /// <returns>true if the lists are identical, false if they are not</returns>
    public static bool compareLists<T>(List<T> list1, List<T> list2)
    {
        var hashedList1 = new HashSet<T>(list1);
        var hashedList2 = new HashSet<T>(list2);
        return hashedList1.SetEquals(hashedList2);
    }

    /// <summary>
    /// converts all files at the given locations to an array of strings 
    /// then returns those sting[] in a List
    /// </summary>
    /// <param name="audioFileLocation">Expects a word document: csv, txt, etc... format: folder/filename.filetype</param>
    /// <param name="videoFileLocation">Expects a word document: csv, txt, etc... format: folder/filename.filetype</param>
    /// <param name="videoGameFileLocation">Expects a word document: csv, txt, etc... format: folder/filename.filetype</param>
    /// <param name="lituratureFileLocation">Expects a word document: csv, txt, etc... format: folder/filename.filetype</param>
    /// <returns>the contents of each document broken down into a list List<string[]></returns>
    public static List<string[]> readToList(string audioFileLocation, string videoFileLocation, string videoGameFileLocation, string lituratureFileLocation)
    {
        List<string[]> returnList = new List<string[]>();

        if (File.Exists(audioFileLocation) && File.Exists(videoFileLocation) && File.Exists(videoGameFileLocation) && File.Exists(lituratureFileLocation))
        {
            returnList.Add(File.ReadAllLines(audioFileLocation));
            returnList.Add(File.ReadAllLines(videoFileLocation));
            returnList.Add(File.ReadAllLines(videoGameFileLocation));
            returnList.Add(File.ReadAllLines(lituratureFileLocation));
        }

        return returnList;
    }

}
