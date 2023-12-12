using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal.Models
{
    public class PlayerModel : INotifyPropertyChanged
    {
        private string _name;
        private int _playerNumber;

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

        public int PlayerNumber
        {
            get { return _playerNumber; }
            set
            {
                if (_playerNumber != value)
                {
                    _playerNumber = value;
                    OnPropertyChanged(nameof(PlayerNumber));
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
