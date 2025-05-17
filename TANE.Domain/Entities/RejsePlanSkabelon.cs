using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Domain.Entities
{
    public class RejseplanSkabelon
    {
        public int  Id { get; set; }
        public string Titel { get; set; } = string.Empty;
        public string Beskrivelse { get; set; } = string.Empty;
        // Relation til ture
        public List<RejseplanTurSkabelon> RejseplanTurSkabelon { get; set; } = new List<RejseplanTurSkabelon>();
        public byte[]? RowVersion { get; set; } = null;
    }
}
