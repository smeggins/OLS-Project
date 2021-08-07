using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

public static class WriteXML
{


    public static void createvideogameXMLfile(string title, string studio)
    {

        string filepath = "createvideogamexml.xml";

        List<string> info = new List<string>();
        info.Add(title);
        info.Add(studio);


       

        using (XmlWriter xmlw = XmlWriter.Create(filepath))
        {
            xmlw.WriteStartElement("VideoGames");
            xmlw.WriteElementString("title", title);
            xmlw.WriteEndElement();
            xmlw.Flush();
        }

        /*using (StreamWriter sw = new StreamWriter(new FileStream(filepath, FileMode.Create)))
        {


            foreach (string word in info)
            {


                sw.Write(word);
            }


        } */
    }

    public static void createaudioXMLfile(string title, string artist)
    {

        string filepath = "createaudiocsv.xml";

        List<string> info = new List<string>();
        info.Add(title);
        info.Add(artist);


        using (StreamWriter sw = new StreamWriter(new FileStream(filepath, FileMode.Create)))
        {
            foreach (string word in info)
            {
                sw.Write(word);
            }

            //sw.WriteLine("");
        }
    }
}

