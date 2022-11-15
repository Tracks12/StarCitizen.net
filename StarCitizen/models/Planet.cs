using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCitizen.models
{
    public delegate void EventHandler();

    public class Planet
    {
        public int size { get; set; }
        public int usability { get; set; }
        public int orbit { get; set; }
        public string name { get; set; }

        public event EventHandler Update;

        public Planet(int size, int usability, int orbit, string name)
        {
            this.size = size;
            this.usability = usability;
            this.orbit = orbit;
            this.name = name;
        }

        public virtual void OnUpdate()
        {
            Update?.Invoke();
        }
    }
}
