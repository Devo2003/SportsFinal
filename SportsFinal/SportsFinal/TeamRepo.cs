using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public class TeamRepo : ITeamRepo
    {
        public List<Team> teams { get; set; }

        public TeamRepo()
        {
            teams = new List<Team>();
        }
        public void AddTeam(string name, Sports s)
        {
            teams.Add(new Team { TeamName = name, sport = s });
        }

        public void RemoveTeam(string name)
        {
            teams.RemoveAll(Team => Team.TeamName == name);
        }

        public void AddPlayersToTeam(string teamName, Player p)
        {
            var team = teams.Find(t => t.TeamName == teamName);
            if (team != null)
            {
                team.players.Add(p);
            }
        }

        public void RemovePlayersToTeam(string teamName, Player p)
        {
            var team = teams.Find(t => t.TeamName == teamName);
            if (team != null)
            {
                team.players.Remove(p);
            }
        }

        public List<Team> GetTeams()
        {
            return teams;
        }

    }
}
