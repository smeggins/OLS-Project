using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class User
{

    public static HashSet<User> userNumbers = new HashSet<User>();

    public void addHash(User user)
    {

        //int usernum = user.UserNumber;

        userNumbers.Add(user);

        Console.WriteLine(user.firstName + " has been added.");
    }





    public string firstName;
    public string lastName;

    //public static int UserNumber = 0;



    //public string FullName { get; set; }
    //TODO make static
    public static int userCounter = 0;
    public int UserNumber = 0;
    //private Cart cart;

    public User(string FirstName, string LastName)
    {
        firstName = FirstName;
        lastName = LastName;
        userCounter++;
        UserNumber = userCounter;

        //cart = new Cart();
    }

    public void printInfo()
    {
        Console.WriteLine("The users name is {0} and their number is {1}", firstName, UserNumber);
    }
}
