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
        public ICommand RemoveSportCommand { get; }
        public ICommand EditSportNameCommand { get; }

        public ICommand AddTeamCommand { get; }
        public ICommand RemoveTeamCommand { get; }
        public ICommand EditTeamNameCommand { get; }

        public ICommand AddPlayerCommand { get; }
        public ICommand RemovePlayerCommand { get; }
        public ICommand EditPlayerNameCommand { get; }

        public BaseViewModel()
        {
            sports = new ObservableCollection<SportsModel>();
            teams = new ObservableCollection<TeamsModel>();
            players = new ObservableCollection<PlayerModel>();

            AddSportCommand = new RelayCommand(AddSport);
            RemoveSportCommand = new RelayCommand(RemoveSport, EnableButtonAfterAdd);
            EditSportNameCommand = new RelayCommand(InputSportsName, EnableButtonAfterAdd);

            AddTeamCommand = new RelayCommand(ShouldAddTeam, EnableButtonAfterAdd);
            RemoveTeamCommand = new RelayCommand(ShouldRemoveTeam, CanRemoveTeam);
            EditTeamNameCommand = new RelayCommand(InputTeamsName, CanEditTeamName);

            AddPlayerCommand = new RelayCommand(AddPlayerToTeam, CanAddPlayerToTeam);
            RemovePlayerCommand = new RelayCommand(RemovePlayerFromTeam, CanRemovePlayerFromTeam);
            EditPlayerNameCommand = new RelayCommand(InputPlayersName, CanEditPlayerName);
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
        //calls the method within the SportsModel class to check if its able to activate the edit button
        public void InputSportsName()
        {
            if (ChosenSport != null)
            {
                this.chosenSport.EditSportName();
            }
        }
        //calls the method within the TeamsModel class to check if its able to activate the edit button
        public void InputTeamsName()
        {
            if (ChosenSport != null)
            {
                this.chosenTeams.EditTeamName();
            }
        }
        //calls the method within the PlayerssModel class to check if its able to activate the edit button
        public void InputPlayersName()
        {
            if (ChosenTeams != null && ChosenPlayer != null)
            {
                this.ChosenPlayer.EditPlayerName();
            }

        }

        private void AddSport()
        {
            Sports.Add(SportsModel.CreateNewSport());
        }

        private void RemoveSport()
        {
            ChosenSport.RemoveSport(Sports, ref chosenSport);
        }

        private void ShouldAddTeam()
        {
            if (ChosenSport != null)
            {
                Teams.Add(TeamsModel.CreateNewTeam(chosenSport));
            }
        }

        private void ShouldRemoveTeam()
        {
            chosenTeams.RemoveTeam(chosenTeams, teams);
        }

        private void AddPlayerToTeam()
        {
            if (ChosenTeams != null)
            {
                Players.Add(PlayerModel.CreatePlayer());
            }
        }

        private void RemovePlayerFromTeam()
        {
           chosenPlayers.RemovePlayer(Players, ref chosenPlayers);
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
