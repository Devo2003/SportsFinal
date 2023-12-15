using SportsFinal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTest
{
    
    [TestClass]
    public class PlayerModelTests
    {
        //The calling thread must be STA, because many UI components require this.
        [TestMethod]
        public void PlayerCreation()
        {
            // Arrange 

            //Act
            var player = PlayerModel.CreatePlayer();
            // Assert
            Assert.IsNotNull(player);
            Assert.AreEqual("Player name", player.Name);
            Assert.AreEqual(11, player.PlayerNum);

        }
        [TestMethod]
        public void PlayerRemoval()
        {
            // Arrange
            var players = new ObservableCollection<PlayerModel> { new PlayerModel { Name = "TestPlayer", PlayerNum = 1 } };
            var chosenPlayer = players[0];

            // Act
            chosenPlayer.RemovePlayer(players, ref chosenPlayer);

            // Assert
            Assert.AreEqual(0, players.Count);
            Assert.IsNull(chosenPlayer);
        }
        
        [TestMethod]
        [STAThread]
        public void PlayerNameEditing()
        {
            // Arrange
            var player = new PlayerModel { Name = "OldName", PlayerNum = 1 };

            // Act
            player.EditPlayerName();

            // Assert
            Assert.AreEqual("OldName", player.Name); 
        }


    }
}
