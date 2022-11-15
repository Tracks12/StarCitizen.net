using Newtonsoft.Json;
using StarCitizen.models;

namespace StarCitizen
{
    public class Exercice1
    {
        public static Universe LoadUniverse(string path)
        {
            Console.WriteLine("Loading universe ...");

            List<string> systemsPath = GetSystemPath(path);
            List<SolarSystem> solarSystems = new();

            foreach (string systemPath in systemsPath)
            {
                List<string> planetsPath = GetPlanetFiles(systemPath);
                List<Planet> planets = new();

                foreach (string planetPath in planetsPath)
                {
                    string file = File.ReadAllText(planetPath);
                    planets.Add(JsonConvert.DeserializeObject<Planet>(file));
                }

                solarSystems.Add(new($"{systemPath.Split("\\").Last()}", planets));
            }

            Console.WriteLine("Universe fully loaded");

            return new("Calypso", solarSystems);
        }

        public static List<string> GetSystemPath(string path)
        {
            List<string> result = new();

            string[] directories = Directory.GetDirectories(path);

            foreach (string item in directories)
                result.Add(item);

            return result;
        }

        public static List<string> GetPlanetFiles(string path)
        {
            List<string> result = new();

            string[] directories = Directory.GetFiles(path, "*.json");

            foreach (string item in directories)
                result.Add(item);

            return result;
        }
    }
}
