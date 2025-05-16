using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.DagSkabeloner.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.DagSkabeloner.Commands
{
    public class UpdateDagSkabelon : IUpdateDagSkabelon
    {
        private readonly IDagSkabelonRepository _dagSkabelonRepository;

        public UpdateDagSkabelon(IDagSkabelonRepository dagSkabelonRepository)
        {
            _dagSkabelonRepository = dagSkabelonRepository;
        }

        public async Task<DagSkabelon> UpdateDagSkabelonAsync(DagSkabelon dagSkabelon, string jwtToken)
        {
            return await _dagSkabelonRepository.UpdateDagSkabelonAsync(dagSkabelon.Id, dagSkabelon, jwtToken);
        }
    }
}
