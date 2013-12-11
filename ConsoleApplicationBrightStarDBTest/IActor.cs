using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightstarDB.EntityFramework;

namespace ConsoleApplicationBrightStarDBTest
{
    [Entity]
    interface IActor
    {
        string Name { get; set; }
        DateTime DateOfBirth { get; set; }
        ICollection<IFilm> Films { get; }
    }
}
