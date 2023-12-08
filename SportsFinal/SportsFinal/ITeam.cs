using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public interface ITeam
    {
       // public List<IPlayer> Players { get; }

        public string TeamName { get; set; }
        public int maxTeams { get; set; }
    }
}
