using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Cart 
{
    public List<Entity> items;
    public int quantity { get; set; }
    public Entity products;

    public Cart()
    {
        items = new List<Entity>();
        quantity = items.Count();

        //products = entityTypes();

    }

    public string addItem(Entity item)
    {
        items.Add(item);

        return (item + "has been added");
    }

    public string removeItem(Entity item)
    {
        items.Remove(item);

        return (item + "has been deleted");
    }


    public void printCart()
    {

        //string itemList = string.Join(", ", items.ToArray());
        foreach (var item in this.items)
        {
            Console.WriteLine("The items in the cart are {0}", item.title);
        }

            
    }

}
