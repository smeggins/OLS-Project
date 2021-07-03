using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLS.src.Cart;
using OLS.src.User;

namespace OLS
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Liturature theHobbit = new Liturature("The Hobbit", LituratureMedium.Book);
            theHobbit.authors.Add("JRR. Tolken");
            theHobbit.genre.Add(VideoAndLituratureGenre.Fantasy);
            theHobbit.countryOfOrigin = "canada";
            theHobbit.pages = 242;
            theHobbit.print();

            Console.WriteLine("\n\n");

            List<VideoGameMedium> mediumList = new List<VideoGameMedium>();
            mediumList.Add(VideoGameMedium.PC);
            mediumList.Add(VideoGameMedium.XboxOne);

            VideoGame seaOfThieves = new VideoGame("Sea Of Thieves", mediumList);
            seaOfThieves.publishers.Add("Microsoft");
            seaOfThieves.developers.Add("Rare");
            seaOfThieves.print();

            List<string> meh = seaOfThieves.publishers;
            meh.Add("jim bob");

            //seaOfThieves.update(a_publishers:meh);

            Console.WriteLine("\n\n");

            /// <summery>
            /// 
            /// 
            /// 
            /// </summery>

            List<VideoMedium> mediumListB = new List<VideoMedium>();
            mediumListB.Add(VideoMedium.Blueray);
            mediumListB.Add(VideoMedium.DVD);

            Video Alien = new Video("Alien", mediumListB);
            Alien.country = "America";
            Alien.director = "Ridley Scott";
            Alien.print();

            Console.WriteLine("\n\n");

            List<AudioMedium> mediumListC = new List<AudioMedium>();
            mediumListC.Add(AudioMedium.CD);
            mediumListC.Add(AudioMedium.Digital);

            Audio NAVUZIMETRO = new Audio("NAVUZIMETRO#PT2", mediumListC);
            NAVUZIMETRO.artists.Add("Nav");
            NAVUZIMETRO.artists.Add("Metro Boomin");
            NAVUZIMETRO.featuredArtists.Add("Lil Uzi Vert");
            NAVUZIMETRO.producers.Add("Nav");
            NAVUZIMETRO.producers.Add("Metro Boomin");
            NAVUZIMETRO.genre.Add(AudioGenre.HipHop);
            NAVUZIMETRO.print();

            User Abbe = new User("Abbe Azale");
            Abbe.printInfo();


            Cart guysCart = new Cart("Abbe's Cart");

            guysCart.addItem("Alien");
            guysCart.addItem("Sea Of Thieves");

            guysCart.printCart();


            guysCart.removeItem("Alien");
            Console.WriteLine("after deleting....");
            guysCart.printCart(); */

            TestcodeShelf.test();

            
        }
    }
}
