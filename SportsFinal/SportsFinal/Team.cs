using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public class Team : ITeam
    {

        //public List<IPlayer> Players {  get; set; }
        public List<IPlayer> Team1 { get; set; }
        public List<IPlayer> Team2 { get; set; }
        public string TeamName { get; set; }
        public int maxTeams { get; set; }

        public Team() 
        {
            Team1 = new List<IPlayer>(); 
            Team2 = new List<IPlayer>();

        }

        public void teamInfo(string name, int max)
        {
            TeamName = name;
            maxTeams = max;
        }

        public IPlayer AddPlayersToTeam(Player p)
        {
            this.Team1.Add(p);
            this.Team2.Add(p);

            return p;
        }

        public void RemovePlayers(IPlayer player)
        {
            if (Team1.Contains(player))
            {
                Team1.Remove(player);

            }
            else if (Team2.Contains(player))
            {
                Team2.Remove(player);
            }
            
        }




    }
}
