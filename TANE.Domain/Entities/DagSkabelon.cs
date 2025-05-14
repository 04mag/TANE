
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
        public int Sekvens { get; set; }
        public string Titel { get; set; } = string.Empty;
        public string Beskrivelse { get; set; } = string.Empty;
        public string Aktiviteter { get; set; } = string.Empty;
        public string Måltider { get; set; } = string.Empty;
        public string Overnatning { get; set; } = string.Empty;
    }
}
