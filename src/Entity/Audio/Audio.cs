using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum AudioGenre
{
    Blues,
    Country,
    Electronic,
    HipHop,
    Jazz,
    Pop,
    Rock,
    Rap,
    Folk,
    Opera,
    Metal,
    Instrumental
}
enum AudioMedium
{
    CD,
    Record
}
class Audio : Entity
{
    public Audio(string a_libraryCode) : base(a_libraryCode) { }

    

}
