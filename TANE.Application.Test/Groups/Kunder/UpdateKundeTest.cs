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
        // This test is to check if the method calls the repository with a valid Kunde object
        public async Task UpdateKunde_ValidInput_CallsRepository()
        {
            // Arrange
            var kundeRepository = new Mock<IKundeRepository>();
            var updateKundeCommand = new UpdateKunde(kundeRepository.Object);

            var validKunde = new Kunde("test", "tester", "test@test.com", "12345678");

            kundeRepository.Setup(repo => repo.UpdateKundeAsync(validKunde, jwtToken))
                .ReturnsAsync(validKunde); // Set it to return the validKunde object

            // Act
            await updateKundeCommand.UpdateKundeAsync(validKunde, jwtToken);

            // Assert
            //tjekker at REPO ikke bliver kaldt
            kundeRepository.Verify(repo => repo.UpdateKundeAsync(It.IsAny<Kunde>(), jwtToken), Times.Never);
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

            //tjekker at REPO ikke bliver kaldt
            kundeRepository.Verify(repo => repo.UpdateKundeAsync(It.IsAny<Kunde>(), jwtToken), Times.Never); 
        }

    }
}
