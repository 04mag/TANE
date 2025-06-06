using Moq;
using TANE.Application.RepositoryInterfaces;
using TANE.Application.Groups.Kunder.Commands;
using TANE.Domain.Entities;
using TANE.Application.Groups.Kunder.Queries;

namespace TANE.Application.Test.Groups.Kunder
{
    public class ReadKundeTest
    {
        private static string jwtToken = "test-token";

        [Fact]
        // This test is to check if the method returns a Kunde object when a valid ID is provided
        public async Task GetKundeById_ValidId_ReturnsKunde()
        {
            // Arrange
            var kundeRepository = new Mock<IKundeRepository>();
            var getKundeCommand = new ReadKunde(kundeRepository.Object);

            var kundeId = 1; 
            var expectedKunde = new Kunde("test", "test", "test@example.com", "12345678");

            kundeRepository.Setup(repo => repo.ReadKundeByIdAsync(kundeId, jwtToken))
                .ReturnsAsync(expectedKunde);

            // Act
            var result = await getKundeCommand.GetKundeByIdAsync(kundeId, jwtToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedKunde, result);
        }
       
        [Fact]
        // This test is to check if the method returns a list of customers
        public async Task GetAllKunder_ReturnsListOfKunder()
        {
            // Arrange
            var kundeRepository = new Mock<IKundeRepository>();
            var getKundeCommand = new ReadKunde(kundeRepository.Object);

            var expectedKunder = new List<Kunde>
            {
                new Kunde("test", "tester", "test@example.com", "12345678"),
                new Kunde("tetser", "testts", "testeetre@example.com", "87654321")
            };

            kundeRepository.Setup(repo => repo.ReadAllKunderAsync(jwtToken))
                .ReturnsAsync(expectedKunder);

            // Act
            var result = await getKundeCommand.GetAllKunderAsync(jwtToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}
