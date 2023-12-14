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
        //Help from: Mack, Grace
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
            //Would I be able to move these commands to their own class, or should they be handle in this class? 
            //Im new to commands, and wanted to try them out after you used them in your own wpf project
            AddSportCommand = new RelayCommand(AddSport);
            RemoveSportCommand = new RelayCommand(RemoveSport, EnableButtonAfterAdd);
            EditSportNameCommand = new RelayCommand(InputSportsName, EnableButtonAfterAdd);

            AddTeamCommand = new RelayCommand(ShouldAddTeam, EnableButtonAfterAdd);
            RemoveTeamCommand = new RelayCommand(ShouldRemoveTeam, EnableButtons);
            EditTeamNameCommand = new RelayCommand(InputTeamsName, EnableButtons);

            AddPlayerCommand = new RelayCommand(AddPlayerToTeam, EnableButtons);
            RemovePlayerCommand = new RelayCommand(RemovePlayerFromTeam, EnbalePlayerButtons);
            EditPlayerNameCommand = new RelayCommand(InputPlayersName, EnbalePlayerButtons);
        }
        //These are needed for their commands, but can they again be moved to their own perspective class?
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
                    OnPropertyChanged(nameof(EnableButtons));
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
                    OnPropertyChanged(nameof(EnableButtons));
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
                    OnPropertyChanged(nameof(EnbalePlayerButtons));
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
                    OnPropertyChanged(nameof(EnbalePlayerButtons));
                }
            }
        }
        //calls the method within the SportsModel class to check if its able to activate the edit button and be able to input new name
        public void InputSportsName()
        {
            if (ChosenSport != null)
            {
                this.chosenSport.EditSportName();
            }
        }
        //calls the method within the TeamsModel class to check if its able to activate the edit button and be able to edit new name
        public void InputTeamsName()
        {
            if (ChosenSport != null)
            {
                this.chosenTeams.EditTeamName();
            }
        }
        //calls the method within the TeamsModel class to check if its able to activate the edit button and be able to edit new name
        public void InputPlayersName()
        {
            if (ChosenTeams != null && ChosenPlayer != null)
            {
                this.ChosenPlayer.EditPlayerName();
            }
        }
        //These methods call methods from playerModels, sportsModel, teamsModel and this class are used for their own commands
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
        //These methods are checking if its able to enbale button to be pressed if user clicks on a player,sport,or team.
        private bool EnableButtonAfterAdd()
        {
            return ChosenSport != null;
        }
        private bool EnableButtons()
        {
            return ChosenTeams != null;
        }
        public bool EnbalePlayerButtons()
        {
            return ChosenTeams != null && ChosenPlayer != null;
        }
    }
}
