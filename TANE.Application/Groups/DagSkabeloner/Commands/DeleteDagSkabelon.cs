using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.DagSkabeloner.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;

namespace TANE.Application.Groups.DagSkabeloner.Commands
{
    public class DeleteDagSkabelon : IDeleteDagSkabelon
    {
        private readonly IDagSkabelonRepository _dagSkabelonRepository;

        public DeleteDagSkabelon(IDagSkabelonRepository dagSkabelonRepository)
        {
            _dagSkabelonRepository = dagSkabelonRepository;
        }

        public async Task<bool> DeleteDagSkabelonAsync(int id, string jwtToken)
        {
            return await _dagSkabelonRepository.DeleteDagSkabelonAsync(id, jwtToken);
        }
    }
}
