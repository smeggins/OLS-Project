using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLS.src.User
{
    public class User 
    {
        public string FullName { get; set; }
        public int UserNumber { get; set; }

        public User(string fullName, int userNumber)
        {
            FullName = fullName;
            UserNumber = userNumber;
        }


        public void printInfo()
        {
            Console.WriteLine("The users name is {0} and their number is {1}", FullName, UserNumber);
        }
    }
}
