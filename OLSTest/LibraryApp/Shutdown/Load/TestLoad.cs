using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class TestLoad
{
    public static void testXml()
    {
        Shelf libraryShelf = Load.loadXml("testFiles/xmlTest/audio  `", "testFiles/xmlTest/video", "testFiles/xmlTest/videoGame", "testFiles/xmlTest/liturature");
    }
}
