using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCitizen
{
    public class Exercice4
    {
        public static void Start(string path)
        {
            Stopwatch watcher = new();

            // Sync
            watcher.Start();
            Exercice1.LoadUniverse(path);
            watcher.Stop();
            Console.WriteLine($"\rTime: {watcher.ElapsedMilliseconds} ms");

            watcher.Start();
            Exercice2.LoadUniverseAsync(path);
            watcher.Stop();
            Console.WriteLine($"\rTime: {watcher.ElapsedMilliseconds} ms");
        }
    }
}
