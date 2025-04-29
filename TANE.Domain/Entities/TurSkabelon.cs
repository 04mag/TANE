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
        public int RejsePlanSkabelonId { get; set; }
        public string Titel { get; set; } = string.Empty;
        public string Beskrivelse { get; set; } = string.Empty;
        public List<DagSkabelon> DagSkabeloner { get; set; } = new List<DagSkabelon>();

        public double GetPris()
        {
            return DagSkabeloner.Sum(d => d.Pris);
        }
    }
}
