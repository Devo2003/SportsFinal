

using SportsFinal;

namespace SportsTest
{
    [TestClass]
    public class SportsRepoTest
    {
        [TestMethod]
        public void AddingSportToList()
        {

            // Arrange
            SportsRepo sp = new SportsRepo();

            // Act
            sp.AddSport("Futbol", "A two team sport played with a spherical ball.");

            // Assert
            Assert.IsNotNull(sp.GetSports());
            Assert.AreEqual(1, sp.GetSports().Count);
            Assert.AreEqual("Futbol", sp.GetSports().First().Name);

        }

        [TestMethod]
        public void RemoveSportFromList()
        {
            // Arrange
            SportsRepo sp = new SportsRepo();
            sp.AddSport("Futbol", "A two team sport played with a spherical ball.");

            // Act
            sp.RemoveSport("Futbol");

            // Assert
            Assert.IsNotNull(sp.GetSports());
            Assert.AreEqual(0, sp.GetSports().Count);
        }

    }
}