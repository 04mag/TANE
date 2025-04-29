using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Domain.Entities
{
    public class DagSkabelon
    {
        public int Id { get; set; }
        public int TurSkabelonId { get; set; }
        public string Titel { get; set; } = string.Empty;
        public string Beskrivelse { get; set; } = string.Empty;
        public List<string> Aktiviteter { get; set; } = new List<string>();
        public List<string> Måltider { get; set; } = new List<string>();
        public string Overnatning { get; set; } = string.Empty;
        public double Pris { get; set; }
    }
}
