using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCitizen.models
{
    public class SolarSystem
    {
        public string name { get; set; }
        public List<Planet> planets { get; set; }

        public SolarSystem(string name, List<Planet> planets)
        {
            this.name = name;
            this.planets = planets;
        }
    }
}
