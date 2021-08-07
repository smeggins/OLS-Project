using System;
using System.IO;

public static class ReadXML
{

    public static void readaudioXML()
    {
        string filepath = "createaudiocsv.xml";

        using (StreamReader s = new StreamReader(filepath))
        {

            Console.WriteLine("Audio: ");
            string line;

            string[] words = null;
            //string lines = s.ReadToEnd();

            var lines = File.ReadLines(filepath);

            while ((line = s.ReadLine()) != null)
            {
                words = line.Split(",");


                foreach (string word in words)
                {
                    Console.WriteLine(word);
                }




            }

        }
    }


    public static void readvideogameXML()
    {
        string filepath = "createvideogamecsv.xml";

        using (StreamReader s = new StreamReader(filepath))
        {

            Console.WriteLine("Video Games: ");
            string line;

            string[] words = null;
            //string lines = s.ReadToEnd();

            var lines = File.ReadLines(filepath);

            while ((line = s.ReadLine()) != null)
            {
                words = line.Split(",");


                foreach (string word in words)
                {
                    Console.WriteLine(word);
                }




            }

        }
    }
}

