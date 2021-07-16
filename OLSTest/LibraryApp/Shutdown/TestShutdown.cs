using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class TestShutdown
{
    public static void testCloseApp()
    {
        Shelf libraryShelf = TestShelf.createTestShelf();
        Shutdown.CloseApp(libraryShelf, "audio.txt", "Video.txt", "videoGame.txt", "liturature.txt");
    }
}
