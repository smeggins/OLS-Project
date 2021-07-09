using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TestCodePerson
{
    Person testPerson;
    public TestCodePerson()
    {
        testPerson = new Person("Jim", "Jam");
    }

    public void test(Entity item, Format format)
    {
        testPerson.addProject(item, format);
    }
}
