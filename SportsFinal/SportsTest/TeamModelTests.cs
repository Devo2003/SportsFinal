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
    public class TeamModelTests
    {
        [TestMethod]
        public void TeamCreation()
        {
            // Arrange
            var chosenSport = new SportsModel { Name = "Sport name", Description = "sport Description" };

            // Act
            var team = TeamsModel.CreateNewTeam(chosenSport);


            // Assert
            Assert.IsNotNull(team);
            Assert.AreEqual("Team name", team.Name);
            Assert.AreEqual(chosenSport, team.sportsModel);

        }
        [TestMethod]
        public void TeamRemoval()
        {
            // Arrange
            var teams = new ObservableCollection<TeamsModel> { new TeamsModel { Name = "TestTeam", sportsModel = new SportsModel() } };
            var chosenTeams = teams[0];

            // Act
            chosenTeams.RemoveTeam(chosenTeams, teams);

            // Assert
            Assert.AreEqual(0, teams.Count);
            Assert.IsNotNull(chosenTeams);
        }

        [TestMethod]
        [STAThread]
        public void TeamNameEditing()
        {
            // Arrange
            var team = new TeamsModel { Name = "OldName", sportsModel = new SportsModel() };

            // Act
            team.EditTeamName();

            // Assert
            Assert.AreEqual("OldName", team.Name); 
        }
    }
}
