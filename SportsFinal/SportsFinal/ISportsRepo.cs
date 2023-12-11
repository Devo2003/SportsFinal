using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public  interface ISportsRepo
    {

        public List<Sports> sports { get; set; }

        public void AddSport(string name, string description);

        public void RemoveSport(string name);

        public List<Sports> GetSports();

    }
}
