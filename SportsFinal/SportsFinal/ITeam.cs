using SportsFinal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public interface ITeam
    {
        //public string TeamName { get; set; }
        

        string name { get; set; }
        SportsModel sportsModel { get; set; }
        ObservableCollection<PlayerModel> playerModels { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
        void RemoveTeam(TeamsModel chosenTeams, ObservableCollection<TeamsModel> teams);
        void EditTeamName();
    }
}
