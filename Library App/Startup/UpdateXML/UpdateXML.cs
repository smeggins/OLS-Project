using System;
using System.Collections.Generic;
using System.IO;

public static class UpdateXML
{
    public static void updateAuidoXML(string title, string artist)
    {
        string filepath = "createaudiocsv.xml";
        List<string> info = new List<string>();
        info.Add(title);
        info.Add(artist);


        using (StreamWriter s = new StreamWriter(new FileStream(filepath, FileMode.Append)))
        {


            //s.WriteLine("");
            s.WriteLine("");
            s.Write(title + ",");
            s.Write(artist);

            //s.Write(artist);

        }
    }

    public static void updateVideoGameXML(string title, string studio)
    {
        string filepath = "createvideogamecsv.xml";
        List<string> info = new List<string>();
        info.Add(title);
        info.Add(studio);


        using (StreamWriter s = new StreamWriter(new FileStream(filepath, FileMode.Append)))
        {



            s.WriteLine("");
            s.Write(title + ",");
            s.Write(studio);



        }
    }
}

