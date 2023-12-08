using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public  interface ISportsRepo
    {
        

        public string Name { get; set; }
        public string Description();

        public void AddSport(ISports s);
        public void RemoveSport(ISports s);

    }
}
