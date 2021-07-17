using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class TestStartup
{
    public static void testopenApp()
    {
        Shelf libraryShelf = TestShelf.createTestShelf();
        Startup.StartApp(libraryShelf, "newaudio.txt", "newvideo.txt", "newvideogames.txt", "newlit.txt");
    }
}