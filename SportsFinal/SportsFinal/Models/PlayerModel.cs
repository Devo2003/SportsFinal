using SportsFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal.Models
{
    public class PlayerModel : PropertyChangeFunctions, IPlayer
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

        public static PlayerModel CreatePlayer()
        {
            return new PlayerModel { Name = "Player name", PlayerNum = 11 };
        }

        public void RemovePlayer(ObservableCollection<PlayerModel> players, ref PlayerModel chosenPlayer)
        {
            if (chosenPlayer != null)
            {
                players.Remove(chosenPlayer);
                chosenPlayer = null;

            }
        }

        // Edit Player Name
        public void EditPlayerName()
        {

            InputDialog dialog = new InputDialog("Edit Player Name", "Enter a new name:", Name);
            dialog.ShowDialog();

            // Update the player name if the result is not null
            if (dialog.Result != null)
            {
                Name = dialog.Result;
            }


        }
    }
}
