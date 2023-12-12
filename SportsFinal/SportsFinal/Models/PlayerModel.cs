using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal.Models
{
    public class PlayerModel : INotifyPropertyChanged, IPlayer
    {
        //The player has a Name and Player Number
        public string name { get; set; }
        public int playerNum { get; set; }

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

        public int PlayerNum
        {
            get { return playerNum; }
            set
            {
                if (playerNum != value)
                {
                    playerNum = value;
                    OnPropertyChanged(nameof(PlayerNum));
                }
            }
        }

        // INotifyPropertyChanged implementation
        //Need this to update the name of the player that gets input
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
