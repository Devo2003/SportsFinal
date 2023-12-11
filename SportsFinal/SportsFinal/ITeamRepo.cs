using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public interface ITeamRepo
    {
        public List<Team> teams { get; set; }

        public void AddTeam(string name, Sports s);

        public void RemoveTeam(string name);

        public void AddPlayersToTeam(string teamName, Player p);

        public void RemovePlayersToTeam(string teamName, Player p);

        public List<Team> GetTeams();


    }
}
