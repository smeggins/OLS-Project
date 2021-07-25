using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class TestSave
{
    public static void testXml(Shelf shelf)
    {
        Save.saveShelfToDocumentXML(shelf, "testFiles/xmlTest/audio.xml", "testFiles/xmlTest/video.xml", "testFiles/xmlTest/videoGame.xml", "testFiles/xmlTest/liturature.xml");
    }
}
