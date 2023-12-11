using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public class SportsRepo : ISportsRepo
    {
        public List<Sports> sports { get; set; }

        public SportsRepo()
        {
            sports = new List<Sports>();
        }

        public void AddSport(string name, string description)
        {
            this.sports.Add(new Sports { Name = name, Description = description });
        }

        public void RemoveSport(string name)
        {
            this.sports.RemoveAll(sport => sport.Name == name);
        }

        public List<Sports> GetSports()
        {
            return sports;
        }



    }
}
