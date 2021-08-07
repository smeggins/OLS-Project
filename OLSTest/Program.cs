using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLSTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Shelf libraryShelf = TestShelf.createTestShelf();

            //Console.WriteLine("TestLoad.testreadXmlToVideo(): " + TestLoad.testreadXmlToVideo());
            //Console.WriteLine("TestLoad.testreadXmlToLiturature(): " + TestLoad.testreadXmlToLiturature());
            //Console.WriteLine("TestUpdate.testUpdateXml(): " + TestUpdate.testUpdateXml());

            // I didn't write an automatic save test because i felt that testLoad tests both save and load well enough... and I didn't want to :)
            Console.WriteLine("TestLoad.testJson(): " + TestLoad.testJson());
            Console.WriteLine("TestUpdate.testUpdateJson(): " + TestUpdate.testUpdateJson());

        }
    }
}
