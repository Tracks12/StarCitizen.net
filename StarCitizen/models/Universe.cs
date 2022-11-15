using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCitizen.models
{
    public class Universe
    {
        public string name { get; set; }
        public List<SolarSystem> systems { get; set; }

        public Universe(string name, List<SolarSystem> systems)
        {
            this.name = name;
            this.systems = systems;
        }
    }
}
