using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public class SportsRepo : ISportsRepo
    {
        public string Name { get; set; }

        public List<ISports> sports;

        public SportsRepo(string name)
        {
            sports = new List<ISports>();

            Name = name;
        }
        public void AddSport(ISports s)
        {
            this.sports.Add(s);
        }

        public void RemoveSport(ISports s)
        {
            if (sports.Contains(s))
            {
                sports.Remove(s);
            }
        }

        public string Description()
        {
            return string.Empty;
        }

        
        
    }
}
