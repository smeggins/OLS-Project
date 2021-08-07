using System;
using System.IO;
using System.Collections.Generic;

public static class CreateAdd
{

    //create object and add it to file
    public static void createLit(string title, string creator)
    {

        string filename = "litfile.txt";

        string[] newinfo = { title, creator };
        //List<string> info = new List<string>();


        using (StreamWriter s = File.AppendText(filename))
        {

            
            foreach (string word in newinfo)
            {
                s.Write(word + ",");
            }

        }
    }

    public static void createVid(string title, string creator)
    {

        string filename = "vidfile.txt";

        string[] newinfo = { title, creator };
        //List<string> info = new List<string>();


        using (StreamWriter s = File.AppendText(filename))
        {

            /*s.Write(newinfo.GetValue(0));
            s.Write(newinfo.GetValue(1)); */
            foreach (string word in newinfo)
            {
                s.Write(word + ",");
            }

        }
    }

    public static void createaudio(string title, string creator)
    {

        string filename = "audiofile.txt";

        string[] newinfo = { title, creator };
        //List<string> info = new List<string>();


        using (StreamWriter s = File.AppendText(filename))
        {

            /*s.Write(newinfo.GetValue(0));
            s.Write(newinfo.GetValue(1)); */
            foreach (string word in newinfo)
            {
                s.Write(word + ",");
            }

        }
    }

    public static void createVidGame(string title, string creator)
    {

        string filename = "vidgamefile.txt";

        string[] newinfo = { title, creator };
        //List<string> info = new List<string>();


        using (StreamWriter s = File.AppendText(filename))
        {

            /*s.Write(newinfo.GetValue(0));
            s.Write(newinfo.GetValue(1)); */
            foreach (string word in newinfo)
            {
                s.Write(word + ",");
            }

        }
    }

    //read the file



    public static void readFiles(string litfile, string audiofile, string videogamefile, string videofile)
    {
        string line;
        string litfilename = litfile + ".txt";
        string videogamefilename = videogamefile + ".txt";
        string videofilename = videofile + ".txt";
        string audiofilename = audiofile + ".txt";


        using (StreamReader s = new StreamReader(litfilename))
        {

            while ((line = s.ReadLine()) != null)
            {

                string[] words = line.Split(",");

                foreach (string word in words)
                {
                    Console.WriteLine(word);
                }
            }

        }


        using (StreamReader s = new StreamReader(videogamefilename))
        {

            while ((line = s.ReadLine()) != null)
            {

                string[] words = line.Split(",");

                foreach (string word in words)
                {
                    Console.WriteLine(word);
                }
            }

        }


        using (StreamReader s = new StreamReader(audiofilename))
        {

            while ((line = s.ReadLine()) != null)
            {

                string[] words = line.Split(",");

                foreach (string word in words)
                {
                    Console.WriteLine(word);
                }
            }

        }


        using (StreamReader s = new StreamReader(videofilename))
        {

            while ((line = s.ReadLine()) != null)
            {

                string[] words = line.Split(",");

                foreach (string word in words)
                {
                    Console.WriteLine(word);
                }
            }

        }

    }

   
}

