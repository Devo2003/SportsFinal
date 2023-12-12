using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal.Models
{
    public class TeamsModel : INotifyPropertyChanged
    {
        private string _name;
        private SportsModel _sportsModel;
        private ObservableCollection<PlayerModel> _playerModels;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public SportsModel SportsModel
        {
            get { return _sportsModel; }
            set
            {
                if (_sportsModel != value)
                {
                    _sportsModel = value;
                    OnPropertyChanged(nameof(SportsModel));
                }
            }
        }

        public ObservableCollection<PlayerModel> PlayerModels
        {
            get { return _playerModels; }
            set
            {
                if (_playerModels != value)
                {
                    _playerModels = value;
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
