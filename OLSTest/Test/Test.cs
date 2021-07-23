using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Test
{
    public static bool compareLists<T>(List<T> list1, List<T> list2)
    {
        var hashedList1 = new HashSet<T>(list1);
        var hashedList2 = new HashSet<T>(list2);
        return hashedList1.SetEquals(hashedList2);
    }

}
