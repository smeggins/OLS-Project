using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class testPerson
{
    Person person;
    public testPerson()
    {
        person = new Person("Jim", "Jam");
    }

    public void test(Entity item, Format format)
    {
        person.addProject(item, format);
    }
}
