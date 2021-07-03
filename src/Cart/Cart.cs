using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLS.src;

namespace OLS.src.Cart
{
    class Cart 
    {
        public List<string> items;
        public int quantity { get; set; }
        public Entity products;
        public string userCart { get; set; }


        public Cart(string usersCart)
        {
            userCart = usersCart;
            items = new List<string>();
            quantity = items.Count();

            //products = entityTypes();

        }

        public string addItem(string item)
        {
            items.Add(item);

            return (item + "has been added");
        }

        public string removeItem(string item)
        {
            items.Remove(item);

            return (item + "has been deleted");
        }


        public void printCart()
        {

            string itemList = string.Join(", ", items.ToArray());

            Console.WriteLine("The items in the cart are {0}", itemList);
        }

    }
}
