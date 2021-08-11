using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// NOTE: Consumer has no methods because the read methods are all defined in the User abstract class
// Consumer inherits from
public class Consumer : User
{
    public Consumer(Person a_user, Position a_position) : base(a_user, a_position) { }

    protected override void instantiateRole()
    {
        role = Role.Consumer;
    }
}
