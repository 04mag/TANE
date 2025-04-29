using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.Ture.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Ture.Commands
{
    public class CreateTur : ICreateTur
    {
        private readonly ITurRepository _turRepository;

        public CreateTur(ITurRepository turRepository)
        {
            _turRepository = turRepository;
        }

        public async Task<Tur> CreateTurAsync(Tur tur, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
