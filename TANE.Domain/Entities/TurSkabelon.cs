using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TANE.Domain.Entities
{
    public class TurSkabelon
    {
        public int Id { get; set; }
        public string Titel { get; set; } = string.Empty;

        public string Beskrivelse { get; set; } = string.Empty;

        public double Pris { get; set; } = 0;

        public List<DagTurSkabelon> DagTurSkabelon { get; set; } = new List<DagTurSkabelon>();

        public byte[]? RowVersion { get; set; } = null;
    }
}
