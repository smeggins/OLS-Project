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
    /// <param name="Values">a list of string values. Get these values using the GetValues method on any libraryShelf format list</param>
    public static void writeBytes(Stream s, List<String> Values)
    {
        foreach (String item in Values)
        {
            s.Write(Encoding.ASCII.GetBytes(item));
            s.Write(Encoding.ASCII.GetBytes("\n"));
        }
        s.Write(Encoding.ASCII.GetBytes("\n//\n\n"));
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
                writeBytes(s, audioItem.GetValues());
            }
        }

        using (Stream s = new FileStream(videoFileName, FileMode.Create))
        {
            foreach (Video videoItem in shelf.downCastVideo())
            {
                writeBytes(s, videoItem.GetValues());
            }
        }

        using (Stream s = new FileStream(videoGameFileName, FileMode.Create))
        {
            foreach (VideoGame videoGameItem in shelf.downCastVideoGame())
            {
                writeBytes(s, videoGameItem.GetValues());
            }
        }

        using (Stream s = new FileStream(lituratureFileName, FileMode.Create))
        {
            foreach (Liturature lituratureItem in shelf.downCastLiturature())
            {
                writeBytes(s, lituratureItem.GetValues());
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
        saveShelfToDocument(shelf, audioFileName, videoFileName, videoGameFileName, lituratureFileName);
    }
}
