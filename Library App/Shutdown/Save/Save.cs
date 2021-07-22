using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public static class Save
{
    /// <summary>
    /// Writes bytes to stream
    /// </summary>
    /// <param name="s">The stream being written to your document</param>
    /// <param name="Values">a list of string values. Get these values using the GetValuesF method on any libraryShelf format list</param>
    private static void writeBytes(Stream s, List<string> Values)
    {
        foreach (string item in Values)
        {
            s.Write(Encoding.ASCII.GetBytes(item));
            s.Write(Encoding.ASCII.GetBytes("\n"));
        }
        s.Write(Encoding.ASCII.GetBytes("\n//\n\n"));
    }

    /// <summary>
    /// formats the incoming message to conform with CSV formatting
    /// </summary>
    /// <param name="s">the stream writing to your file</param>
    /// <param name="Values">
    /// All values stored on an entity
    /// the first item in each List<string> is the attribute types name, each item that follows (if there are any) is a value of that attribute
    /// EX. ["actors", "johnny depp", "seth rogan"]
    /// "actors" is the attribute name in the entity and "johnny depp"/"seth rogan" are the fullName strings of the Person objects stored in the actors attribute 
    /// </param>
    private static void writeCSV(StreamWriter s, List<List<string>> Values)
    {
        foreach (List<string> itemValue in Values)
        {
            // write first value to list without the preceeding comma
            s.Write(itemValue[0]);
            if (itemValue.Count > 1)
            {
                for (int i = 1; i < itemValue.Count - 1; i++)
                {
                    s.Write(", " + itemValue[i]);
                }
                s.Write(", " + itemValue[itemValue.Count - 1] + "\n");
            }
            else
            {
                s.Write("\n");
            }
        }
        s.WriteLine("///, ///, ///");
    }

    /// <summary>
    /// saves your shelf to a given address with formatted Values as a .txt file
    /// </summary>
    /// <param name="shelf">the shelf object for the app</param>
    /// <param name="audioFileName">the document name you'll save your shelf to</param>
    /// <param name="videoFileName">the document name you'll save your shelf to</param>
    /// <param name="videoGameFileName">the document name you'll save your shelf to</param>
    /// <param name="lituratureFileName">the document name you'll save your shelf to</param>
    public static void saveShelfToDocument(Shelf shelf, string audioFileName, string videoFileName, string videoGameFileName, string lituratureFileName)
    {
        using (Stream s = new FileStream(audioFileName + ".txt", FileMode.Create))
        {
            foreach (Audio audioItem in shelf.downCastAudio())
            {
                writeBytes(s, audioItem.GetValuesF());
            }
        }

        using (Stream s = new FileStream(videoFileName + ".txt", FileMode.Create))
        {
            foreach (Video videoItem in shelf.downCastVideo())
            {
                writeBytes(s, videoItem.GetValuesF());
            }
        }

        using (Stream s = new FileStream(videoGameFileName + ".txt", FileMode.Create))
        {
            foreach (VideoGame videoGameItem in shelf.downCastVideoGame())
            {
                writeBytes(s, videoGameItem.GetValuesF());
            }
        }

        using (Stream s = new FileStream(lituratureFileName + ".txt", FileMode.Create))
        {
            foreach (Liturature lituratureItem in shelf.downCastLiturature())
            {
                writeBytes(s, lituratureItem.GetValuesF());
            }
        }
    }

    /// <summary>
    /// saves your shelf to a given address formatted to be saved as a csv file
    /// </summary>
    /// <param name="shelf">the shelf object for the app</param>
    /// <param name="audioFileName">the document name you'll save your shelf to</param>
    /// <param name="videoFileName">the document name you'll save your shelf to</param>
    /// <param name="videoGameFileName">the document name you'll save your shelf to</param>
    /// <param name="lituratureFileName">the document name you'll save your shelf to</param>
    public static void saveShelfToDocumentCSV(Shelf shelf, string audioFileName, string videoFileName, string videoGameFileName, string lituratureFileName)
    {
        using (StreamWriter s = new StreamWriter(audioFileName + ".csv", false))
        {
            foreach (Audio audioItem in shelf.downCastAudio())
            {
                writeCSV(s, audioItem.GetValues());
            }
        }

        using (StreamWriter s = new StreamWriter(videoFileName + ".csv", false))
        {
            foreach (Video videoItem in shelf.downCastVideo())
            {
                writeCSV(s, videoItem.GetValues());
            }
        }

        using (StreamWriter s = new StreamWriter(videoGameFileName + ".csv", false))
        {
            foreach (VideoGame videoGameItem in shelf.downCastVideoGame())
            {
                writeCSV(s, videoGameItem.GetValues());
            }
        }

        using (StreamWriter s = new StreamWriter(lituratureFileName + ".csv", false))
        {
            foreach (Liturature lituratureItem in shelf.downCastLiturature())
            {
                writeCSV(s, lituratureItem.GetValues());
            }
        }
    }

    /// <summary>
    /// checks to make sure you are not in backup mode, then saves the shelf as a text and csv file, finally it creates a back-up with todays date.
    /// </summary>
    /// <param name="shelf">the current working shelf</param>
    public static void saveShelf(Shelf shelf)
    {
        if (Backup.backupMode == false)
        {
            saveShelfToDocument(shelf, "saves/" + "audio", "saves/" + "video", "saves/" + "videoGame", "saves/" + "liturature");
            saveShelfToDocumentCSV(shelf, "savesCSV/" + "audio", "savesCSV/" + "video", "savesCSV/" + "videoGame", "savesCSV/" + "liturature");
            Backup.createBackup(shelf);
        }
    }
}
