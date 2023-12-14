using SportsFinal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportsFinal.ViewModels
{
    public class BaseViewModel : PropertyChangeFunctions
    {
        private ObservableCollection<SportsModel> sports;
        private ObservableCollection<TeamsModel> teams;
        private ObservableCollection<PlayerModel> players;
        private SportsModel chosenSport;
        private TeamsModel chosenTeams;
        private PlayerModel chosenPlayers;

        
        //Commands to bind in the XAML 
        public ICommand AddSportCommand { get; }
        public ICommand AddTeamCommand { get; }
        public ICommand RemoveSportCommand { get; }
        public ICommand RemoveTeamCommand { get; }
        public ICommand AddPlayerCommand { get; }
        public ICommand RemovePlayerCommand { get; }

        public ICommand EditSportNameCommand { get; }
        public ICommand EditTeamNameCommand { get; }
        public ICommand EditPlayerNameCommand { get; }

        public BaseViewModel()
        {
            sports = new ObservableCollection<SportsModel>();
            teams = new ObservableCollection<TeamsModel>();
            players = new ObservableCollection<PlayerModel>();

            EditSportNameCommand = new RelayCommand(InputSportsName, EnableButtonAfterAdd);
            EditTeamNameCommand = new RelayCommand(InputTeamsName, CanEditTeamName);
            EditPlayerNameCommand = new RelayCommand(InputPlayersName, CanEditPlayerName);

            AddSportCommand = new RelayCommand(AddSport);
            RemoveSportCommand = new RelayCommand(RemoveSport, EnableButtonAfterAdd);

            AddTeamCommand = new RelayCommand(AddTeam, EnableButtonAfterAdd);
            RemoveTeamCommand = new RelayCommand(RemoveTeam, CanRemoveTeam);

            AddPlayerCommand = new RelayCommand(AddPlayerToTeam, CanAddPlayerToTeam);
            RemovePlayerCommand = new RelayCommand(RemovePlayerFromTeam, CanRemovePlayerFromTeam);
        }

        public ObservableCollection<SportsModel> Sports
        {
            get { return sports; }
            set
            {
                if (sports != value)
                {
                    sports = value;
                    OnPropertyChanged(nameof(Sports));
                }
            }
        }

        public SportsModel ChosenSport
        {
            get { return chosenSport; }
            set
            {
                if (chosenSport != value)
                {
                    chosenSport = value;
                    OnPropertyChanged(nameof(ChosenSport));
                    OnPropertyChanged(nameof(EnableButtonAfterAdd));
                }
            }
        }

        public ObservableCollection<TeamsModel> Teams
        {
            get { return teams; }
            set
            {
                if (teams != value)
                {
                    teams = value;
                    OnPropertyChanged(nameof(Teams));
                    OnPropertyChanged(nameof(CanRemoveTeam));
                }
            }
        }

        public TeamsModel ChosenTeams
        {
            get { return chosenTeams; }
            set
            {
                if (chosenTeams != value)
                {
                    chosenTeams = value;
                    OnPropertyChanged(nameof(ChosenTeams));
                    OnPropertyChanged(nameof(CanRemoveTeam));
                }
            }
        }

        public ObservableCollection<PlayerModel> Players
        {
            get { return players; }
            set
            {
                if (players != value)
                {
                    players = value;
                    OnPropertyChanged(nameof(Players));
                    OnPropertyChanged(nameof(CanRemovePlayerFromTeam));
                }
            }
        }

        public PlayerModel ChosenPlayer
        {
            get { return chosenPlayers; }
            set
            {
                if (chosenPlayers != value)
                {
                    chosenPlayers = value;
                    OnPropertyChanged(nameof(ChosenPlayer));
                    OnPropertyChanged(nameof(CanRemovePlayerFromTeam));
                }
            }
        }
        //calls the method within the SportsModel class
        public void InputSportsName()
        {
            if (ChosenSport != null)
            {
                this.chosenSport.EditSportName();
            }
        }

        public void InputTeamsName()
        {
            if (ChosenSport != null)
            {
                this.chosenTeams.EditTeamName();
            }
        }

        public void InputPlayersName()
        {
            if (ChosenTeams != null && ChosenPlayer != null)
            {
                this.ChosenPlayer.EditPlayerName();
            }

        }

        private void AddSport()
        {
            Sports.Add(new SportsModel { Name = "Sport Name", Description = "Sport Description" });
        }

        private void RemoveSport()
        {
            if (ChosenSport != null)
            {
                Sports.Remove(ChosenSport);
                ChosenSport = null;
            }
        }

        private void AddTeam()
        {
            if (ChosenSport != null)
            {
                Teams.Add(new TeamsModel { Name = "Team Name", SportsModel = ChosenSport });
            }

        }

        private void RemoveTeam()
        {
            if (ChosenTeams != null)
            {
                Teams.Remove(ChosenTeams);
                ChosenTeams = null;
            }
        }

        

        private void AddPlayerToTeam()
        {
            if (ChosenTeams != null)
            {
                Players.Add(new PlayerModel { Name = "Player name", PlayerNum    = 1 });
            }
        }

        private void RemovePlayerFromTeam()
        {
            if (ChosenTeams != null && ChosenPlayer != null)
            {
                Players.Remove(ChosenPlayer);
                ChosenPlayer = null;
            }
        }

        private bool EnableButtonAfterAdd()
        {

            return ChosenSport != null;
        }
       

        private bool CanRemoveTeam()
        {
            return ChosenTeams != null;
        }

        private bool CanAddPlayerToTeam()
        {
            return ChosenTeams != null;
        }

        private bool CanRemovePlayerFromTeam()
        {
            return ChosenTeams != null && ChosenPlayer != null;
        }

        private bool CanEditTeamName()
        {
            return ChosenTeams != null;
        }

        private bool CanEditPlayerName()
        {
            return ChosenTeams != null && ChosenPlayer != null;
        }
    }
}
