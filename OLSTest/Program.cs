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

            //TestShutdown.testCloseApp();
            //Console.WriteLine("TestReturnProperties Successful: " + TestEntity.TestReturnProperties());
            Shutdown.saveShelfToDocumentCSV(libraryShelf, "audio", "video", "videogame", "liturature");
        }
    }
}
