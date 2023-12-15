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
        

        public string name { get; set; }
        public SportsModel sportsModel { get; set; }
        public ObservableCollection<PlayerModel> playerModels { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        // protected virtual void OnPropertyChanged(string propertyName) { }
        public void RemoveTeam(TeamsModel chosenTeams, ObservableCollection<TeamsModel> teams);
        public void EditTeamName();
    }
}
