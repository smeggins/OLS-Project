using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TestConsumer
{
    public static bool test()
    {
        Shelf shelf = TestShelf.createTestShelf();
        Person person = new Person("Consumer Chadwick");
        Consumer consumer = new Consumer(person, Position.Developer);

        consumer.readEntity(shelf, Format.Video, "Alien");
        int index = consumer.search(shelf, Format.Video, Shelf.searchParam.title, "Alien");

        if (index != -1)
        {
            return true;
        }
        else
        {
            return false;
        }
        

    }
}
