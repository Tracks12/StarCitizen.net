using Newtonsoft.Json;
using StarCitizen.common;
using StarCitizen.models;
using System;

namespace StarCitizen
{
    public class Exercice3
    {
        public static Task<Universe> LoadUniverseAsync(string path)
        {
            Console.WriteLine("Loading universe ...");
            ProgressViewer progress = new(0, Directory.GetFiles(path, "*.json", SearchOption.AllDirectories).Length);

            string[] systemsPath = Directory.GetDirectories(path);

            List<Task<List<Planet>>> planetTasks = new();
            foreach (string systemPath in systemsPath)
            {
                planetTasks.Add(GetPlanetAsync(systemPath, progress));
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

        public static Task<List<Planet>> GetPlanetAsync(string path, ProgressViewer progressViewer)
        {
            string[] planetsPath = Directory.GetFiles(path, "*.json");

            List<Task<Planet>> planetsTasks = new();
            foreach (string planetPath in planetsPath)
            {
                planetsTasks.Add(GetPlanetFileAsync(planetPath, progressViewer));
            }

            Task.WhenAll(planetsTasks);

            List<Planet> planets = new();
            foreach (Task<Planet> planetTask in planetsTasks)
            {
                planets.Add(planetTask.Result);
            }

            return Task.FromResult(planets);
        }

        public static Task<Planet> GetPlanetFileAsync(string path, ProgressViewer progressViewer)
        {
            string file = File.ReadAllText(path);
            Planet planet = JsonConvert.DeserializeObject<Planet>(file);

            planet.Update += progressViewer.OnUpdate;
            planet.OnUpdate();

            return Task.FromResult(planet);
        }
    }
}
