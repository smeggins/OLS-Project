using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Admin : Editor
{
    public Admin(Person a_user, Position a_position) : base(a_user, a_position) { }

    protected override void instantiateRole()
    {
        role = Role.Admin;
    }

    public int? userIndex(string fullName)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].user.fullName == fullName)
            {
                return i;
            }
        }

        return null;
    }

    public bool userExists(string fullName)
    {
        return userIndex(fullName) != null;
    }

    public void addUser(Person a_user, Position a_position, Role role)
    {
        if (role == Role.Consumer)
        {
            new Consumer(a_user, a_position);
        }
        else if(role == Role.Editor)
        {
            new Editor(a_user, a_position);
        }
        else if (role == Role.Admin)
        {
            new Admin(a_user, a_position);
        }
    }

    public void changeRole(string fullName, Role newRole)
    {
        int? user = userIndex(fullName);

        if (user != null)
        {
            int i = (int)user;
            Person tempP = users[i].user;
            Position tempPos = users[i].position;
            users.RemoveAt(i);
            if (newRole == Role.Consumer)
            {
                new Consumer(tempP, tempPos);
            }
            else if (newRole == Role.Editor)
            {
                new Editor(tempP, tempPos);
            }
            else if (newRole == Role.Admin)
            {
                new Admin(tempP, tempPos);
            }
        }
    }

    public void updatePosition(string fullName, Position newPos)
    {
        int? index = userIndex(fullName);

        if (index != null)
        {
            users[(int)index].position = newPos;
        }
    }

    public void deleteUser(string fullName)
    {
        int? index = userIndex(fullName);

        if (index != null)
        {
            users.Remove(users[(int)index]);
        }
    }
}