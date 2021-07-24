using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class User 
{

    public HashSet<int> userNumbers = new HashSet<int>();

    public string addHash()
    {
        userNumbers.Add(UserNumber);

        return UserNumber + " has been added";
    }



    public string firstName;
    public string lastName;
    //TODO make static
    public static int UserNumber = 0;
    //private Cart cart;

    public User(string FirstName, string LastName)
    {
        firstName = FirstName;
        lastName = LastName;
        UserNumber = UserNumber + 1;
        //cart = new Cart();
    }

    public void printInfo()
    {
        Console.WriteLine("The users name is {0} and their number is {1}", firstName, UserNumber);
    }

}


