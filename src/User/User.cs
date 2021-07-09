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
        //TODO make static
        public int UserNumber = 0;
        private Cart cart;

        public User(string fullName)
        {
            FullName = fullName;
            UserNumber += 1;
            cart = new Cart();
        }

        public void printInfo()
        {
            Console.WriteLine("The users name is {0} and their number is {1}", FullName, UserNumber);
        }
    }
}
