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
    public class SportModelTests
    {
        [TestMethod]
        public void SportCreation()
        {
            // Arrange
            // Act
            var sport = SportsModel.CreateNewSport();

            // Assert
            Assert.IsNotNull(sport);
            Assert.AreEqual("Sport name", sport.Name);
            Assert.AreEqual("Describe sport", sport.Description);

        }
        [TestMethod]
        public void SportRemoval()
        {
            // Arrange
            var sports = new ObservableCollection<SportsModel> { new SportsModel { Name = "TestSport", Description = "TestDescription" } };
            var chosenSport = sports[0];

            // Act
            chosenSport.RemoveSport(sports, ref chosenSport);

            // Assert
            Assert.AreEqual(0, sports.Count);
            Assert.IsNull(chosenSport);
        }

        [TestMethod]
        [STAThread]
        public void SportNameEditing()
        {
            // Arrange
            var sport = new SportsModel { Name = "OldName", Description = "OldDescription" };

            // Act
            sport.EditSportName();

            // Assert
            Assert.AreEqual("OldName", sport.Name); 
        }
    }
}
