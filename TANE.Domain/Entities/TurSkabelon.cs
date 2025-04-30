using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Domain.Entities
{
    public class TurSkabelon
    {
        public int Id { get; set; }
        public List<DagSkabelon> DagSkabeloner { get; set; } = new List<DagSkabelon>();
        public int Sekvens { get; set; }
        public string Titel { get; set; } = string.Empty;
        public string Beskrivelse { get; set; } = string.Empty;

        public double GetPris()
        {
            return DagSkabeloner.Sum(d => d.Pris);
        }

        public int GetAntalDage()
        {
            return DagSkabeloner.Count;
        }
    }
}
