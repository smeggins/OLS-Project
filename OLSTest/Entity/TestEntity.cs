using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestEntity
{
    public static bool TestReturnProperties ()
    {
        Shelf libraryShelf = TestShelf.createTestShelf();

        Liturature book = (Liturature)libraryShelf.LibraryShelf[Format.Liturature][0];
        List<List<string>> litProperties = book.returnProperties(book);

        if (litProperties.Count != typeof(Liturature).GetProperties().Count())
        {
            return false;
        }

        Video video = (Video)libraryShelf.LibraryShelf[Format.Video][0];
        List<List<string>> vidProperties = video.returnProperties(video);

        if (vidProperties.Count != typeof(Liturature).GetProperties().Count())
        {
            return false;
        }

        VideoGame videoGame = (VideoGame)libraryShelf.LibraryShelf[Format.VideoGame][0];
        List<List<string>> videoGameProperties = videoGame.returnProperties(videoGame);

        if (videoGameProperties.Count != typeof(VideoGame).GetProperties().Count())
        {
            return false;
        }

        Audio audio = (Audio)libraryShelf.LibraryShelf[Format.Audio][0];
        List<List<string>> audioProperties = audio.returnProperties(audio);

        if (audioProperties.Count != typeof(Audio).GetProperties().Count())
        {
            return false;
        }

        return true;
    }
}