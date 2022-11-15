using Newtonsoft.Json;
using StarCitizen.models;

namespace StarCitizen
{
    public class Exercice2
    {
        public static Task<Universe> LoadUniverseAsync(string path)
        {
            Console.WriteLine("Loading universe ...");

            string[] systemsPath = Directory.GetDirectories(path);

            List<Task<List<Planet>>> planetTasks = new();
            foreach (string systemPath in systemsPath)
            {
                planetTasks.Add(GetPlanetAsync(systemPath));
            }

            Task.WhenAll(planetTasks);

            List<SolarSystem> solarSystems = new();
            foreach (Task<List<Planet>> planetTask in planetTasks)
            {
                solarSystems.Add(new("", planetTask.Result));
            }

            Universe universe = new("Calypso", solarSystems);

            Console.WriteLine("Universe fully loaded");

            return Task.FromResult(universe);
        }

        public static Task<List<Planet>> GetPlanetAsync(string path)
        {
            string[] planetsPath = Directory.GetFiles(path, "*.json");

            List<Task<Planet>> planetsTasks = new();
            foreach (string planetPath in planetsPath)
            {
                planetsTasks.Add(GetPlanetFileAsync(planetPath));
            }

            Task.WhenAll(planetsTasks);

            List<Planet> planets = new();
            foreach (Task<Planet> planetTask in planetsTasks)
            {
                planets.Add(planetTask.Result);
            }

            return Task.FromResult(planets);
        }

        public static Task<Planet> GetPlanetFileAsync(string path)
        {
            string file = File.ReadAllText(path);
            Planet planet = JsonConvert.DeserializeObject<Planet>(file);

            return Task.FromResult(planet);
        }
    }
}
