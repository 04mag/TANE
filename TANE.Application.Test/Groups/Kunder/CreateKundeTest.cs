using Moq;
using TANE.Application.Groups.Kunder.Commands;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Test.Groups.Kunder
{
    public class CreateKundeTest
    {
        [Fact]
        public async Task CreateKunde_ValidInput()
        {
            // Arrange
            //Create mock of IKundeRepository
            var kundeRepository = new Mock<IKundeRepository>();

            // Setup the mock to return a Kunde object when CreateKundeAsync is called
            kundeRepository.Setup(repo => repo.CreateKundeAsync(It.IsAny<Kunde>()))
                .ReturnsAsync((Kunde kunde) => kunde);

            CreateKunde createKundeCommand = new CreateKunde(kundeRepository.Object);

            var kunde = new Kunde("TestFornavn", "TestEfternavn", "TestEmail@mail.dk", "TestTlfNummer");

            // Act
            var result = await createKundeCommand.CreateKundeAsync(kunde);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(kunde.Fornavn, result.Fornavn);
            Assert.Equal(kunde.Email, result.Email);
        }

        [Fact]
        public async Task CreateKunde_InvalidEmail()
        {
            // Arrange
            var kundeRepository = new Mock<IKundeRepository>();

            // Setup the mock to return null when CreateKundeAsync is called
            CreateKunde createKundeCommand = new CreateKunde(kundeRepository.Object);

            // Invalid email (missing @)
            var KundeInvaildEmail = new Kunde("TestFornavn", "TestEfternavn", "invalidemail.dk", "TestTlfNummer");

            // Act
            Func<Task> act = async () => await createKundeCommand.CreateKundeAsync(KundeInvaildEmail);

            // Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(act);
            Assert.Equal("Email er ikke valid", exception.Message);

        }




    }
}
