﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

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
    public static void writeCSV(StreamWriter s, List<List<string>> Values)
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
    /// converts shelf entity to xml
    /// </summary>
    /// <param name="Values">values of a shelf entity</param>
    /// <returns>an XElement containing shelf entity values</returns>
    public static XElement writeXML(List<List<string>> Values)
    {
        XElement returnElement = new XElement("entity");

        foreach (var value in Values)
        {
            if (value[0] == "libraryCode" || value[0] == "title" || value[0] == "releaseDate" || value[0] == "copiesTotal" || value[0] == "copiesAvailable")
            {
                if (value.Count > 1)
                {
                    returnElement.Add(new XAttribute(value[0], value[1]));
                }
                else
                {
                    returnElement.Add(new XAttribute(value[0], ""));
                }
            }
            else
            {
                XElement attr = new XElement(value[0]);
                foreach (var item in value.GetRange(1, value.Count - 1))
                {
                    XElement val = new XElement("value", item);
                    attr.Add(val);
                }
                returnElement.Add(attr);
            }
        }

        return returnElement;
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
    /// saves shelf to xml document
    /// </summary>
    /// <param name="shelf">the current working shelf</param>
    /// <param name="audioFileName">the file address without the filetype (ie test/audio)</param>
    /// <param name="videoFileName">the file address without the filetype (ie test/audio)</param>
    /// <param name="videoGameFileName">the file address without the filetype (ie test/audio)</param>
    /// <param name="lituratureFileName">the file address without the filetype (ie test/audio)</param>
    public static void saveShelfToDocumentXML(Shelf shelf, string audioFileName, string videoFileName, string videoGameFileName, string lituratureFileName)
    {
        XDocument audioXML = new XDocument();
        XDocument videoXML = new XDocument();
        XDocument videoGameXML = new XDocument();
        XDocument lituratureXML = new XDocument();

        XElement audioRoot = new XElement("audioEntity");
        XElement videoRoot = new XElement("videoEntity");
        XElement videoGameRoot = new XElement("videoGameEntity");
        XElement lituratureRoot = new XElement("lituratureEntity");

        foreach (Audio audioItem in shelf.downCastAudio())
        {
            audioRoot.Add(writeXML(audioItem.GetValues()));
        }
        audioXML.Add(audioRoot);
        audioXML.Save(audioFileName + ".xml");

        foreach (Video videoItem in shelf.downCastVideo())
        {
            videoRoot.Add(writeXML(videoItem.GetValues()));
        }
        videoXML.Add(videoRoot);
        videoXML.Save(videoFileName + ".xml");

        foreach (VideoGame videoGameItem in shelf.downCastVideoGame())
        {
            videoGameRoot.Add(writeXML(videoGameItem.GetValues()));
        }
        videoGameXML.Add(videoGameRoot);
        videoGameXML.Save(videoGameFileName + ".xml");

        foreach (Liturature lituratureItem in shelf.downCastLiturature())
        {
            lituratureRoot.Add(writeXML(lituratureItem.GetValues()));
        }
        lituratureXML.Add(lituratureRoot);
        lituratureXML.Save(lituratureFileName + ".xml");
    }

    /// <summary>
    /// saves shelf to Json document
    /// </summary>
    /// <param name="shelf">the current working shelf</param>
    /// <param name="audioFileName">the file address without the filetype (ie test/audio)</param>
    /// <param name="videoFileName">the file address without the filetype (ie test/audio)</param>
    /// <param name="videoGameFileName">the file address without the filetype (ie test/audio)</param>
    /// <param name="lituratureFileName">the file address without the filetype (ie test/audio)</param>
    public static void saveShelfToDocumentJson(Shelf shelf, string fileLocation)
    {
        JsonSerializerOptions serializeShelfSettings = new JsonSerializerOptions();
        serializeShelfSettings.Converters.Add(new JsonShelfConverter());
        var json = JsonSerializer.Serialize(shelf.LibraryShelf, serializeShelfSettings);
        File.WriteAllText(fileLocation + ".json", json);
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
            Backup.createBackup(shelf);
        }
    }

    public enum SaveOptions
    {
        Xml,
        Json
    }
    public static void saveAs(Shelf shelf, SaveOptions option, string fileLocationJsonOrXmlAudio, string fileLocationVideo = "", string fileLocationVideogame = "", string fileLocationLiturature = "")
    {
        if (option == SaveOptions.Json)
        {
            saveShelfToDocumentJson(shelf, fileLocationJsonOrXmlAudio);
        }
        else if (option == SaveOptions.Xml)
        {
            saveShelfToDocumentXML(shelf, fileLocationJsonOrXmlAudio, fileLocationVideo, fileLocationVideogame, fileLocationLiturature);
        }
    }
}
