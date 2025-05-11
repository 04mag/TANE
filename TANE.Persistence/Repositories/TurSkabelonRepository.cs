using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    internal class TurSkabelonRepository : ITurSkabelonRepository
    {
        public List<TurSkabelon> TurSkabeloner { get; set; } = new List<TurSkabelon>();

        public TurSkabelonRepository()
        {
            TurSkabeloner.Add(
                new TurSkabelon
                {
                    Id = 1,
                    Titel = "Dag Skabelon 1",
                    Beskrivelse = "Beskrivelse 1",
                    Sekvens = 1,
                    DagSkabeloner = new List<DagSkabelon>
                    {
                        new DagSkabelon
                        {
                            Id = 2,
                            Titel = "Dag Skabelon 2",
                            Beskrivelse = "Beskrivelse 2",
                            Måltider = "Måltider 2",
                            Aktiviteter = "Aktiviteter 2",
                        }
                    }
                }
            );

            TurSkabeloner.Add(
                new TurSkabelon
                {
                    Id = 2,
                    Titel = "Dag Skabelon 2",
                    Beskrivelse = "Beskrivelse 2",
                    Sekvens = 2,
                    DagSkabeloner = new List<DagSkabelon>
                    {
                        new DagSkabelon
                        {
                            Id = 1,
                            Titel = "Dag Skabelon 1",
                            Beskrivelse = "Beskrivelse 1",
                            Måltider = "Måltider 1",
                            Aktiviteter = "Aktiviteter 1",
                        }
                    }
                }
            );
        }
        public Task<TurSkabelon> CreateTurSkabelon(TurSkabelon tur, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTur(int id, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<TurSkabelon>> ReadAllTurSkabeloner(string jwtToken)
        {
            return Task.FromResult(TurSkabeloner);
        }

        public Task<TurSkabelon> ReadTurSkabelonById(int id, string jwtToken)
        {
            var result = TurSkabeloner.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                throw new Exception("DagSkabelon not found");
            }

            return Task.FromResult(result);
        }

        public Task<TurSkabelon> UpdateTurSkabelon(TurSkabelon tur, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
