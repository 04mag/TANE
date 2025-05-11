using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    internal class DagSkabelonRepository : IDagSkabelonRepository
    {
        public List<DagSkabelon> DagSkabeloner { get; set; } = new List<DagSkabelon>();
        public DagSkabelonRepository()
        {
            DagSkabeloner.Add(
            new DagSkabelon
            {
                Id = 1,
                Titel = "Dag Skabelon 1",
                Beskrivelse = "Beskrivelse 1",
                Måltider = "Måltider 1",
                Aktiviteter = "Aktiviteter 1",
                
            }
        );

            DagSkabeloner.Add(
                new DagSkabelon
                {
                    Id = 2,
                    Titel = "Dag Skabelon 2",
                    Beskrivelse = "Beskrivelse 2",
                    Måltider = "Måltider 2",
                    Aktiviteter = "Aktiviteter 2",
                }
            );

            DagSkabeloner.Add(
                new DagSkabelon
                {
                    Id = 3,
                    Titel = "Dag Skabelon 3",
                    Beskrivelse = "Beskrivelse 3",
                    Måltider = "Måltider 3",
                    Aktiviteter = "Aktiviteter 3",
                }
            );

            DagSkabeloner.Add(
                new DagSkabelon
                {
                    Id = 4,
                    Titel = "Dag Skabelon 4",
                    Beskrivelse = "Beskrivelse 4",
                    Måltider = "Måltider 4",
                    Aktiviteter = "Aktiviteter 4",
                }
            );

            DagSkabeloner.Add(
                new DagSkabelon
                {
                    Id = 5,
                    Titel = "Dag Skabelon 5",
                    Beskrivelse = "Beskrivelse 5",
                    Måltider = "Måltider 5",
                    Aktiviteter = "Aktiviteter 5",
                }
            );

            DagSkabeloner.Add(
                new DagSkabelon
                {
                    Id = 6,
                    Titel = "Dag Skabelon 6",
                    Beskrivelse = "Beskrivelse 6",
                    Måltider = "Måltider 6",
                    Aktiviteter = "Aktiviteter 6",
                }
            );

            DagSkabeloner.Add(
                new DagSkabelon
                {
                    Id = 7,
                    Titel = "Dag Skabelon 7",
                    Beskrivelse = "Beskrivelse 7",
                    Måltider = "Måltider 7",
                    Aktiviteter = "Aktiviteter 7",
                }
            );
        }

        public Task<DagSkabelon> CreateDagSkabelonAsync(DagSkabelon dagSkabelon, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDagSkabelonAsync(int id, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<DagSkabelon>> ReadAllDagSkabelonerAsync(string jwtToken)
        {
            return Task.FromResult(DagSkabeloner);
        }

        public Task<DagSkabelon> ReadDagSkabelonByIdAsync(int id, string jwtToken)
        {
            var result = DagSkabeloner.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                throw new Exception("DagSkabelon not found");
            }

            return Task.FromResult(result);
        }

        public Task<DagSkabelon> UpdateDagSkabelonAsync(DagSkabelon dagSkabelon, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
