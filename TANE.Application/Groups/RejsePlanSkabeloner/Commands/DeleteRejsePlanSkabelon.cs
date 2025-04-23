using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.RejsePlanSkabeloner.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;

namespace TANE.Application.Groups.RejsePlanSkabeloner.Commands
{
    public class DeleteRejsePlanSkabelon : IDeleteRejsePlanSkabelon
    {
        private readonly IRejsePlanSkabelonRepository _rejsePlanSkabelonRepository;

        public DeleteRejsePlanSkabelon(IRejsePlanSkabelonRepository rejsePlanSkabelonRepository)
        {
            _rejsePlanSkabelonRepository = rejsePlanSkabelonRepository;
        }

        public async Task<bool> DeleteRejsePlanSkabelonAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
