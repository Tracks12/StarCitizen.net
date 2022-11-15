using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StarCitizen.common
{
    public class ProgressViewer
    {
        public float progress { get; set; }
        public float total { get; set; }
        public float show { get; set; }

        public ProgressViewer(int progress, int total)
        {
            this.progress = progress;
            this.total = total;
            this.show = 0;
        }

        public void OnUpdate()
        {
            this.progress++;
            this.show = (this.progress / this.total) * 100;

            string shape = (int)this.show % 2 == 1 ? " ===       " :
                (int)this.show % 5 == 1 ? "    ===    " : "       === ";

            Console.Write($"\r[{shape}] - {this.show}%       ");
        }
    }
}
