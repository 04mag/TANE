using Moq;
using TANE.Application.Groups.Kunder.Commands;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Test.Groups.Kunder
{
    public class UpdateKundeTest
    {
        private static string jwtToken = "test-token";

        [Fact]
        public async Task UpdateKunde_ValidInput()
        {
            // Arrange
            var kundeRepository = new Mock<IKundeRepository>();

            //Update kunde command return the kunde object that is passed in
            kundeRepository.Setup(repo => repo.UpdateKundeAsync(It.IsAny<Kunde>(), jwtToken))
                .ReturnsAsync((Kunde kunde, string token) => kunde);

            var updateKundeCommand = new UpdateKunde(kundeRepository.Object);

            var validKunde = new Kunde("test", "tester", "test@test.com", "22345678");

            validKunde.Id = 1; // Set a valid Id for the kunde

            // Act
            var result = await updateKundeCommand.UpdateKundeAsync(validKunde, jwtToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(validKunde.Id, result.Id);
            Assert.Equal(validKunde.Fornavn, result.Fornavn);
            Assert.Equal(validKunde.Efternavn, result.Efternavn);
            Assert.Equal(validKunde.Email, result.Email);
            Assert.Equal(validKunde.TlfNummer, result.TlfNummer);
        }

        [Fact]
        // This test is to check if the method throws an exception when an invalid email is provided
        public async Task UpdateKunde_InvalidEmail_ThrowsArgumentException()
        {
            //Arrange
            var kundeRepository = new Mock<IKundeRepository>();

            var updateKundeCommand = new UpdateKunde(kundeRepository.Object);

            var invalidKunde = new Kunde("tests", "test", "invalidemail.dk", "12345678");

            //act 
            Func<Task> act = async () => await updateKundeCommand.UpdateKundeAsync(invalidKunde, jwtToken);

            //Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(act);
            Assert.Equal("Email er ikke valid", exception.Message);
        }
    }
}
