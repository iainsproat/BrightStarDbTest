using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightstarDB.Client;

namespace ConsoleApplicationBrightStarDBTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "type=embedded;storesdirectory=.\\;storename=Films";

            var ctx = new MyEntityContext(connectionString);

            var bladeRunner = ctx.Films.Create();
            bladeRunner.Name = "BladeRunner";

            var starWars = ctx.Films.Create();
            starWars.Name = "Star Wars";

            var ford = ctx.Actors.Create();
            ford.Name = "Harrison Ford";
            ford.DateOfBirth = new DateTime(1942, 7, 13);
            ford.Films.Add(starWars);
            ford.Films.Add(bladeRunner);

            var hamill = ctx.Actors.Create();
            hamill.Name = "Mark Hamill";
            hamill.DateOfBirth = new DateTime(1951, 9, 25);
            hamill.Films.Add(starWars);

            ctx.SaveChanges();

            ctx = new MyEntityContext(connectionString);
            ford = ctx.Actors.Where(a => a.Name.Equals("Harrison Ford")).FirstOrDefault();
            var dob = ford.DateOfBirth;

            var films = ford.Films;

            var sw = films.Where(f => f.Name.Equals("Star Wars")).FirstOrDefault();

            foreach(var actor in sw.Actors)
            {
                var actorname = actor.Name;
                Console.WriteLine(actorname);
            }

            Console.ReadLine();
        }
    }
}
