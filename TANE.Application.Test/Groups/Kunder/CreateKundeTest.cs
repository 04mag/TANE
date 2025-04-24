using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
