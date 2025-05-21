using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.RejsePlaner.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.RejsePlaner.Commands
{
    internal class GeneratePdf : IGeneratePdf
    {
        private readonly IRejseplanRepository rejseplanRepository;

        public GeneratePdf(IRejseplanRepository rejseplanRepository)
        {
            this.rejseplanRepository = rejseplanRepository;
        }

        public async Task<HttpResponseMessage> GeneratePdfFromRejseplanAsync(Rejseplan rejseplan, string jwtToken)
        {
            return await rejseplanRepository.GetRejseplanPdf(rejseplan, jwtToken);
        }
    }
}
