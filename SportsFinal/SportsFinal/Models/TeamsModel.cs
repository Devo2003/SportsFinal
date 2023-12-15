using SportsFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal.Models
{
    [Serializable]
    public class TeamsModel : PropertyChangeFunctions, ITeam
    {
        //Teams should have a Team name 
        public string name { get; set; }
        public SportsModel sportsModel { get; set; }
        public ObservableCollection<PlayerModel> playerModels { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public static TeamsModel CreateNewTeam(SportsModel chosenSport)
        {
            return new TeamsModel { Name = "Team name", sportsModel = chosenSport };
        }

        public void RemoveTeam(TeamsModel chosenTeams, ObservableCollection<TeamsModel> teams)
        {
            if (chosenTeams != null)
            {
                teams.Remove(chosenTeams);
               
            }
        }
        public void EditTeamName()
        {
            InputDialog dialog = new InputDialog("Edit Team Name", "Enter a new name:", Name);
            dialog.ShowDialog();

            // Update the team name if the result is not null
            if (dialog.Result != null)
            {
                Name = dialog.Result;
            }
        }
    }
}
