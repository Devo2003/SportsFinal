using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal.Models
{
    public class TeamsModel : INotifyPropertyChanged, ITeam
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

        public SportsModel SportsModel
        {
            get { return sportsModel; }
            set
            {
                if (sportsModel != value)
                {
                    sportsModel = value;
                    OnPropertyChanged(nameof(SportsModel));
                }
            }
        }

        public ObservableCollection<PlayerModel> PlayerModels
        {
            get { return playerModels; }
            set
            {
                if (playerModels != value)
                {
                    playerModels = value;
                    OnPropertyChanged(nameof(PlayerModels));
                }
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
