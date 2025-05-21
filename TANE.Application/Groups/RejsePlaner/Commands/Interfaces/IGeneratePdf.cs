using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.RejsePlaner.Commands.Interfaces
{
    public interface IGeneratePdf
    {
        Task<HttpResponseMessage> GeneratePdfFromRejseplanAsync(Rejseplan rejseplan, string jwtToken);
    }
}
