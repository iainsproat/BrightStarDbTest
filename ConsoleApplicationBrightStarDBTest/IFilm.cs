using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightstarDB.EntityFramework;

namespace ConsoleApplicationBrightStarDBTest
{
    [Entity]
    interface IFilm
    {
        string Name { get; set; }
        [InverseProperty("Films")]
        ICollection<IActor> Actors { get; }
    }
}
