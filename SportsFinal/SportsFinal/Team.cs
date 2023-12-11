using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public class Team : ITeam
    {

        public string TeamName { get; set; }
        public List<Team> teams { get; set; }
        public List<Player> players { get; set; }
        public int maxTeams { get; set; }
        public Sports sport { get; set; }
        public Team()
        {
            players = new List<Player>();
        }




    }
}
