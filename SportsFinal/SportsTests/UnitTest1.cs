using SportsFinal;

namespace SportsTests
{
    [TestClass]
    public class UnitTest1
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
    }
}