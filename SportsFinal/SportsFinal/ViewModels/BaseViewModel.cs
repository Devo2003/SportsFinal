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
    public class BaseViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<SportsModel> _sports;
        private ObservableCollection<TeamsModel> _teams;
        private ObservableCollection<PlayerModel> _players;
        private SportsModel _chosenSport;
        private TeamsModel _chosenTeams;
        private PlayerModel _chosenPlayers;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
            _sports = new ObservableCollection<SportsModel>();
            _teams = new ObservableCollection<TeamsModel>();
            _players = new ObservableCollection<PlayerModel>();

            EditSportNameCommand = new RelayCommand(EditSportName, CanEditSportName);
            EditTeamNameCommand = new RelayCommand(EditTeamName, CanEditTeamName);
            EditPlayerNameCommand = new RelayCommand(EditPlayerName, CanEditPlayerName);

            AddSportCommand = new RelayCommand(AddSport);
            RemoveSportCommand = new RelayCommand(RemoveSport, CanRemoveSport);

            AddTeamCommand = new RelayCommand(AddTeam, CanAddTeam);
            RemoveTeamCommand = new RelayCommand(RemoveTeam, CanRemoveTeam);

            AddPlayerCommand = new RelayCommand(AddPlayerToTeam, CanAddPlayerToTeam);
            RemovePlayerCommand = new RelayCommand(RemovePlayerFromTeam, CanRemovePlayerFromTeam);
        }

        public ObservableCollection<SportsModel> Sports
        {
            get { return _sports; }
            set
            {
                if (_sports != value)
                {
                    _sports = value;
                    OnPropertyChanged(nameof(Sports));
                }
            }
        }

        public SportsModel ChosenSport
        {
            get { return _chosenSport; }
            set
            {
                if (_chosenSport != value)
                {
                    _chosenSport = value;
                    OnPropertyChanged(nameof(ChosenSport));
                    OnPropertyChanged(nameof(CanRemoveSport));
                }
            }
        }

        public ObservableCollection<TeamsModel> Teams
        {
            get { return _teams; }
            set
            {
                if (_teams != value)
                {
                    _teams = value;
                    OnPropertyChanged(nameof(Teams));
                    OnPropertyChanged(nameof(CanRemoveTeam));
                }
            }
        }

        public TeamsModel ChosenTeams
        {
            get { return _chosenTeams; }
            set
            {
                if (_chosenTeams != value)
                {
                    _chosenTeams = value;
                    OnPropertyChanged(nameof(ChosenTeams));
                    OnPropertyChanged(nameof(CanRemoveTeam));
                }
            }
        }

        public ObservableCollection<PlayerModel> Players
        {
            get { return _players; }
            set
            {
                if (_players != value)
                {
                    _players = value;
                    OnPropertyChanged(nameof(Players));
                    OnPropertyChanged(nameof(CanRemovePlayerFromTeam));
                }
            }
        }

        public PlayerModel ChosenPlayer
        {
            get { return _chosenPlayers; }
            set
            {
                if (_chosenPlayers != value)
                {
                    _chosenPlayers = value;
                    OnPropertyChanged(nameof(ChosenPlayer));
                    OnPropertyChanged(nameof(CanRemovePlayerFromTeam));
                }
            }
        }

        // Edit Sport Name
        private void EditSportName()
        {
            if (ChosenSport != null)
            {
                InputDialog dialog = new InputDialog("Edit Sport Name", "Enter a new name:", ChosenSport.Name);
                dialog.ShowDialog();

                // Update the sport name if the result is not null
                if (dialog.Result != null)
                {
                    ChosenSport.Name = dialog.Result;
                }
            }
        }

        // Edit Team Name
        private void EditTeamName()
        {
            if (ChosenTeams != null)
            {
                InputDialog dialog = new InputDialog("Edit Team Name", "Enter a new name:", ChosenTeams.Name);
                dialog.ShowDialog();

                // Update the team name if the result is not null
                if (dialog.Result != null)
                {
                    ChosenTeams.Name = dialog.Result;
                }
            }
        }

        // Edit Player Name
        private void EditPlayerName()
        {
            if (ChosenTeams != null && ChosenPlayer != null)
            {
                InputDialog dialog = new InputDialog("Edit Player Name", "Enter a new name:", ChosenPlayer.Name);
                dialog.ShowDialog();

                // Update the player name if the result is not null
                if (dialog.Result != null)
                {
                    ChosenPlayer.Name = dialog.Result;
                }
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

        private bool CanRemoveSport()
        {
            return ChosenSport != null;
        }

        private void AddPlayerToTeam()
        {
            if (ChosenTeams != null)
            {
                Players.Add(new PlayerModel { Name = "Player name", PlayerNumber = 1 });
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

        private bool CanAddTeam()
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

        private bool CanEditSportName()
        {
            return ChosenSport != null;
        }

        private bool CanEditTeamName()
        {
            return ChosenTeams != null;
        }

        private bool CanEditPlayerName()
        {
            return ChosenTeams != null && ChosenPlayer != null;
        }

        private string ShowEditDialog(string title, string label, string currentName)
        {
            InputDialog dialog = new InputDialog(title, label, currentName);
            if (dialog.ShowDialog() == true)
            {
                return dialog.Result;
            }
            return null;
        }
    }
}
