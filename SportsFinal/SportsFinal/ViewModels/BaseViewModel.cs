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
        private SportsModel _chosenSport;
        private TeamsModel _chosenTeams;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand AddSportCommand { get; }
        public ICommand AddTeamCommand { get; }
        public ICommand RemoveSportCommand { get; }
        public ICommand RemoveTeamCommand { get; }

        public BaseViewModel()
        {
            _sports = new ObservableCollection<SportsModel>();
            _teams = new ObservableCollection<TeamsModel>();

            AddSportCommand = new RelayCommand(AddSport);
            RemoveSportCommand = new RelayCommand(RemoveSport, CanRemoveSport);

            AddTeamCommand = new RelayCommand(AddTeam, CanAddTeam);
            RemoveTeamCommand = new RelayCommand(RemoveTeam, CanRemoveTeam);
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

        private bool CanAddTeam()
        {
            return ChosenSport != null;
        }

        private bool CanRemoveTeam()
        {
            return ChosenTeams != null;
        }

    }
}
