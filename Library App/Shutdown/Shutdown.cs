using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public static class Shutdown
{
    /// <summary>
    /// Writes bytes to stream
    /// </summary>
    /// <param name="s">The stream being written to your document</param>
    /// <param name="Values">a list of string values. Get these values using the GetValuesF method on any libraryShelf format list</param>
    public static void writeBytes(Stream s, List<string> Values)
    {
        foreach (string item in Values)
        {
            s.Write(Encoding.ASCII.GetBytes(item));
            s.Write(Encoding.ASCII.GetBytes("\n"));
        }
        s.Write(Encoding.ASCII.GetBytes("\n//\n\n"));
    }

    public static void writeCSV(StreamWriter s, List<List<string>> Values)
    {
        foreach (List<string> itemProperties in Values)
        {
            // write first value to list without the preceeding comma
            s.Write(itemProperties[0]);
            for (int i = 1; i < itemProperties.Count - 1; i++)
            {
                s.Write(", " + itemProperties[i]);
            }
            s.Write(", " + itemProperties[itemProperties.Count - 1] + "\n");
        }
        s.WriteLine("///, ///, ///");
    }

    /// <summary>
    /// saves your shelf to a local document
    /// </summary>
    /// <param name="shelf">the shelf object for the app</param>
    /// <param name="audioFileName">the document name you'll save your shelf to</param>
    /// <param name="videoFileName">the document name you'll save your shelf to</param>
    /// <param name="videoGameFileName">the document name you'll save your shelf to</param>
    /// <param name="lituratureFileName">the document name you'll save your shelf to</param>
    public static void saveShelfToDocument(Shelf shelf, string audioFileName, string videoFileName, string videoGameFileName, string lituratureFileName)
    {
        using (Stream s = new FileStream(audioFileName, FileMode.Create))
        {
            foreach (Audio audioItem in shelf.downCastAudio())
            {
                writeBytes(s, audioItem.GetValuesF());
            }
        }

        using (Stream s = new FileStream(videoFileName, FileMode.Create))
        {
            foreach (Video videoItem in shelf.downCastVideo())
            {
                writeBytes(s, videoItem.GetValuesF());
            }
        }

        using (Stream s = new FileStream(videoGameFileName, FileMode.Create))
        {
            foreach (VideoGame videoGameItem in shelf.downCastVideoGame())
            {
                writeBytes(s, videoGameItem.GetValuesF());
            }
        }

        using (Stream s = new FileStream(lituratureFileName, FileMode.Create))
        {
            foreach (Liturature lituratureItem in shelf.downCastLiturature())
            {
                writeBytes(s, lituratureItem.GetValuesF());
            }
        }
    }

    public static void saveShelfToDocumentCSV(Shelf shelf, string audioFileName, string videoFileName, string videoGameFileName, string lituratureFileName)
    {
        using (StreamWriter s = new StreamWriter(audioFileName, false))
        {
            foreach (Audio audioItem in shelf.downCastAudio())
            {
                writeCSV(s, audioItem.GetValues());
            }
        }

        using (StreamWriter s = new StreamWriter(videoFileName, false))
        {
            foreach (Video videoItem in shelf.downCastVideo())
            {
                writeCSV(s, videoItem.GetValues());
            }
        }

        using (StreamWriter s = new StreamWriter(videoGameFileName, false))
        {
            foreach (VideoGame videoGameItem in shelf.downCastVideoGame())
            {
                writeCSV(s, videoGameItem.GetValues());
            }
        }

        using (StreamWriter s = new StreamWriter(lituratureFileName, false))
        {
            foreach (Liturature lituratureItem in shelf.downCastLiturature())
            {
                writeCSV(s, lituratureItem.GetValues());
            }
        }
    }

    /// <summary>
    /// calls all necessary methods to close the app.
    /// </summary>
    /// <param name="shelf">the shelf object for the app</param>
    /// <param name="audioFileName">the document name you'll save your shelf to</param>
    /// <param name="videoFileName">the document name you'll save your shelf to</param>
    /// <param name="videoGameFileName">the document name you'll save your shelf to</param>
    /// <param name="lituratureFileName">the document name you'll save your shelf to</param>
    public static void CloseApp(Shelf shelf, string audioFileName, string videoFileName, string videoGameFileName, string lituratureFileName)
    {
        saveShelfToDocument(shelf, "saves/" + audioFileName + ".txt", videoFileName, "saves/" + videoGameFileName, "saves/" + lituratureFileName);
        saveShelfToDocumentCSV(shelf, "savesCSV/" + audioFileName + ".csv", "savesCSV/" + videoFileName + ".csv", "savesCSV/" + videoGameFileName + ".csv", "savesCSV/" + lituratureFileName + ".csv");
    }
}
