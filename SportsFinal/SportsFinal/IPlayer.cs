using SportsFinal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public interface IPlayer
    {
        string Name { get; }
        int PlayerNum { get; }

        string name { get; set; }
        int playerNum { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged(string propertyName)

        //public static PlayerModel CreatePlayer();
        public void EditPlayerName();
        public void RemovePlayer(ObservableCollection<PlayerModel> players, ref PlayerModel chosenPlayer);
    }
}
