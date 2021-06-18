using System;

namespace OLS
{
    class Program
    {
        static void Main(string[] args)
        {
            Liturature theHobbit = new Liturature("Brawk");
            theHobbit.authors.Add("JRR. Tolken");
            theHobbit.genre.Add(VideoAndLituratureGenre.Fantasy);
            theHobbit.med
            theHobbit.countryOfOrigin = "canada";
            theHobbit.pages = 242;
            theHobbit.print(theHobbit);
        }
    }
}
