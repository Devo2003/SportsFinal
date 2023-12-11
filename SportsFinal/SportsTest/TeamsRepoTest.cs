using SportsFinal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTest
{
    [TestClass]
    public  class TeamsRepoTest
    {

        [TestMethod]
        public void AddingTeam()
        {

            // Arrange
            TeamRepo tp = new TeamRepo();
            SportsRepo sp = new SportsRepo();
            sp.AddSport("Futbol", "A two team sport played with a spherical ball.");

            // Act
            tp.AddTeam("Team1", sp.GetSports().First());

            // Assert
            Assert.AreEqual(1, tp.GetTeams().Count);
            Assert.AreEqual("Team1", tp.GetTeams().First().TeamName);
        }

        [TestMethod]
        public void RemovingTeam()
        {
            // Arrange
            TeamRepo tp = new TeamRepo();
            SportsRepo sp = new SportsRepo();
            sp.AddSport("Futbol", "A two team sport played with a spherical ball.");
            tp.AddTeam("Team1", sp.GetSports().First());

            // Act
            tp.RemoveTeam("Team1");

            // Assert
            Assert.AreEqual(0, tp.GetTeams().Count);
        }

        [TestMethod]
        public void AddingPlayersFromTeam()
        {
            // Arrange
            TeamRepo tp = new TeamRepo();
            SportsRepo sp = new SportsRepo();
            sp.AddSport("Futbol", "A two team sport played with a spherical ball.");
            tp.AddTeam("Team1", sp.GetSports().First());
            Player player = new Player { Name = "Player1", PlayerNum = 5 };

            // Act
            tp.AddPlayersToTeam("Team1", player);

            // Assert
            var team = tp.GetTeams().First();
            Assert.AreEqual(1, team.players.Count);
            Assert.AreEqual("Player1", team.players.First().Name);
        }

        [TestMethod]
        public void RemovingPlayersFromTeam()
        {
            // Arrange
            TeamRepo tp = new TeamRepo();
            SportsRepo sp = new SportsRepo();
            sp.AddSport("Futbol", "A two team sport played with a spherical ball.");
            tp.AddTeam("Team1", sp.GetSports().First());
            Player player = new Player { Name = "Player1", PlayerNum = 2 };
            tp.AddPlayersToTeam("Team1", player);

            // Act
            tp.RemovePlayersToTeam("Team1", player);

            // Assert
            var team = tp.GetTeams().First();
            Assert.AreEqual(0, team.players.Count);
        }
    }
}
