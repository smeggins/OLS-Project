using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TestAdmin
{
    public static bool test()
    {
        Shelf shelf = TestShelf.createTestShelf();
        Person person = new Person("Admin Chadwick");
        Admin admin = new Admin(person, Position.Developer);

        
        bool indexRecieved = admin.userIndex("Admin Chadwick") != null;
        //Console.WriteLine("indexRecieved: " + indexRecieved);
        
        bool exists = admin.userExists("Admin Chadwick");
        //Console.WriteLine("exists: " + exists);
        
        Person newPerson = new Person("Jim Jam");
        admin.addUser(newPerson, Position.HR, Role.Consumer);
        bool newExists = admin.userExists("Jim Jam");
        //Console.WriteLine("newExists: " + newExists);
       
        admin.changeRole("Jim Jam", Role.Editor);
        bool roleChanged = User.users[(int)admin.userIndex("Jim Jam")].role == Role.Editor;
        //Console.WriteLine("roleChanged: " + roleChanged);
        
        admin.updatePosition("Admin Chadwick", Position.Manager);
        bool positionChanged = admin.position == Position.Manager;
        //Console.WriteLine("positionChanged: " + positionChanged);

        admin.deleteUser("Admin Chadwick");
        bool deleted = !admin.userExists("Admin Chadwick");
        //Console.WriteLine("deleted: " + deleted);

        if (indexRecieved && exists && newExists && roleChanged && deleted)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
