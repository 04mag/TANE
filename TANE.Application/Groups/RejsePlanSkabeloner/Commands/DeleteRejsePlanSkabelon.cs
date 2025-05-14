using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.RejseplanSkabeloner.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;

namespace TANE.Application.Groups.RejseplanSkabeloner.Commands
{
    public class DeleteRejseplanSkabelon : IDeleteRejseplanSkabelon
    {
        private readonly IRejseplanSkabelonRepository _rejseplanSkabelonRepository;

        public DeleteRejseplanSkabelon(IRejseplanSkabelonRepository rejseplanSkabelonRepository)
        {
            _rejseplanSkabelonRepository = rejseplanSkabelonRepository;
        }

        public async Task<bool> DeleteRejseplanSkabelonAsync(int id, string jwtToken)
        {
            return await _rejseplanSkabelonRepository.DeleteRejseplanSkabelonAsync(id, jwtToken);
        }
    }
}
