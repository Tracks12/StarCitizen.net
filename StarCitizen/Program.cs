using StarCitizen;
using StarCitizen.common;
using StarCitizen.models;
using System.IO;

Console.WriteLine("Welcome to StarCitizen :)");

string universePath = $"{Directory.GetParent(path: Environment.CurrentDirectory).Parent.Parent.FullName}\\Universe";

// Exercice 1
if(false)
{
    Console.WriteLine("[Exercice 1] - Started");
    Universe universe = Exercice1.LoadUniverse(universePath);
    Console.WriteLine("[Exercice 1] - Ended");
}

// Exercice 2
if(false)
{
    Console.WriteLine("[Exercice 2] - Started");
    Universe universe = await Exercice2.LoadUniverseAsync(universePath);
    Console.WriteLine("[Exercice 2] - Ended");
}

// Exercice 3
if(false)
{
    Console.WriteLine("[Exercice 3] - Started");
    Universe universe = await Exercice3.LoadUniverseAsync(universePath);
    Console.WriteLine("[Exercice 3] - Ended");
}

// Exercice 4
if(true)
{
    Console.WriteLine("[Exercice 4] - Started");
    Exercice4.Start(universePath);
    Console.WriteLine("[Exercice 4] - Ended");
}