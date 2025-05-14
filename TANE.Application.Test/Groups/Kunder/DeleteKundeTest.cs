using Moq;
using TANE.Application.Groups.Kunder.Commands;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;


namespace TANE.Application.Test.Groups.Kunder
{
    public class DeleteKundeTest
    {
        private static string jwtToken = "test-token";

        [Fact]
        public async Task DeleteKunde_VaildInput()
        {
            // Arrange
            var kundeRepository = new Mock<IKundeRepository>();

            // Setup the mock to return a Kunde object when DeleteKundeAsync is called
            kundeRepository.Setup(repo => repo.DeleteKundeAsync(It.IsAny<int>(), jwtToken))
                .ReturnsAsync((int id) => true);

            DeleteKunde deleteKundeCommand = new DeleteKunde(kundeRepository.Object);
            
            // Act
            var result = await deleteKundeCommand.DeleteKundeAsync(1, jwtToken);

            // Assert
            Assert.True(result);

        }   

        [Fact]
        public async Task DeleteKunde_InVaildInput_ThrowArgumentException()
        {
            // Arrange
            var kundeRepository = new Mock<IKundeRepository>();

            kundeRepository.Setup(repo => repo.DeleteKundeAsync(It.IsAny<int>(), jwtToken))
                .ReturnsAsync(() => false);

            // Setup the mock to return a Kunde object when DeleteKundeAsync is called
            DeleteKunde deleteKundeCommand = new DeleteKunde(kundeRepository.Object);

            // Act
            Func<Task> act = async () => await deleteKundeCommand.DeleteKundeAsync(1, jwtToken);

            // Assert
            var exception = await Assert.ThrowsAsync<Exception>(act);
            Assert.Equal("der skete en fejl ved sletning af kunden", exception.Message);
        }
    }
    
}
    