using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



public static class Startup
{
    public static async void StartApp(Shelf shelf, string audioFileName, string videoFileName, string videoGameFileName, string lituratureFileName)
    {

        List<Liturature> literatureItems = new List<Liturature>();

        using (StreamReader s = new StreamReader(lituratureFileName))
        {
            //List<Liturature> literatureItems = new List<Liturature>();



            string line;
            LituratureMedium medium = LituratureMedium.Book;
            string title;


            while ((line = s.ReadLine()) != null)
            {

                string[] words = line.Split(',');

                foreach (string i in words)
                {
                    if (words.Length >= 2)
                    {
                        title = words[1];

                        if (words[3] == "Book")
                        {
                            medium = LituratureMedium.Book;
                        }
                        if (words[3] == "Magazine")
                        {
                            medium = LituratureMedium.Magazine;
                        }


                        Liturature lit = new Liturature(title, medium);

                        literatureItems.Add(lit);
                        //medium = LituratureMedium.
                    }
                }


                //string[] words = line.Split(':', '=');

                //LituratureMedium medium;

                /*if(words[2] == "Book")
                {
                    medium = LituratureMedium.Book;
                } */



                //literatureItems.Add(new Liturature(words[18], ));


                //shelfItemsFromText.Add(literatureItems);

                //shelf.add(literatureItems);

            }

            Console.WriteLine(literatureItems);
        }

        List<Audio> audioItems = new List<Audio>();

        using (StreamReader s = new StreamReader(audioFileName))
        {
            //List<Audio> audioItems = new List<Audio>();

            string line;
            AudioMedium medium = AudioMedium.CD;
            string title;

            while ((line = s.ReadLine()) != null)
            {
                string[] words = line.Split(',');

                foreach (string i in words)
                {
                    if (words.Length >= 2)
                    {
                        title = words[1];


                        if (words[3] == "CD")
                        {
                            medium = AudioMedium.CD;
                        }
                        if (words[3] == "Digital")
                        {
                            medium = AudioMedium.Digital;
                        }
                        if (words[3] == "Record")
                        {
                            medium = AudioMedium.Record;
                        }

                        List<AudioMedium> audioMedium = new List<AudioMedium>();
                        audioMedium.Add(medium);

                        Audio audio = new Audio(title, audioMedium);


                        audioItems.Add(audio);

                        Console.WriteLine(audio.title);
                    }
                }
            }
            Console.WriteLine(audioItems.Count());
        }


        List<VideoGame> videoGameItems = new List<VideoGame>();

        using (StreamReader s = new StreamReader(videoGameFileName))
        {
            //List<VideoGame> videoGameItems = new List<VideoGame>();

            string line;
            VideoGameMedium medium = VideoGameMedium.PC;
            string title;

            while ((line = s.ReadLine()) != null)
            {
                string[] words = line.Split(',');

                foreach (string i in words)
                {
                    if (words.Length >= 2)
                    {
                        title = words[1];


                        if (words[3] == "XboxOne")
                        {
                            medium = VideoGameMedium.XboxOne;
                        }
                        if (words[3] == "PS5")
                        {
                            medium = VideoGameMedium.PS5;
                        }
                        if (words[3] == "Switch")
                        {
                            medium = VideoGameMedium.Switch;
                        }

                        List<VideoGameMedium> videogameMedium = new List<VideoGameMedium>();
                        videogameMedium.Add(medium);

                        VideoGame videoGame = new VideoGame(title, videogameMedium);


                        videoGameItems.Add(videoGame);

                        //Console.WriteLine(videoGameItems);


                    }
                }
            }
            Console.WriteLine(videoGameItems);
        }


        List<Video> videoItems = new List<Video>();

        using (StreamReader s = new StreamReader(videoFileName))
        {
            //List<Video> videoItems = new List<Video>();

            string line;
            VideoMedium medium = VideoMedium.Blueray;
            string title;

            while ((line = s.ReadLine()) != null)
            {
                string[] words = line.Split(',');

                foreach (string i in words)
                {
                    if (words.Length >= 2)
                    {
                        title = words[1];


                        if (words[3] == "DVD")
                        {
                            medium = VideoMedium.DVD;
                        }
                        List<VideoMedium> videoMedium = new List<VideoMedium>();
                        videoMedium.Add(medium);

                        Video video = new Video(title, videoMedium);


                        videoItems.Add(video);

                        Console.WriteLine(videoItems);


                    }
                }
            }
            Console.WriteLine(videoItems);
        }

    }
}
