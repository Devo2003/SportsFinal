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

        event PropertyChangedEventHandler PropertyChanged;

        
        void EditPlayerName();
        void RemovePlayer(ObservableCollection<PlayerModel> players, ref PlayerModel chosenPlayer);
        
    }
}
