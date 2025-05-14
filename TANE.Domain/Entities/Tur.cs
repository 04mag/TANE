using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Domain.Entities
{
    public class Tur
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string? Beskrivelse { get; set; }
        public double Pris { get; set; }
        public DateTime TurStartTidspunkt { get; set; }
        public DateTime TurSlutTidspunkt { get; set; }
        public int Sekvens { get; set; }
        public ICollection<Dag>? Dage { get; set; }
        // Navigation property
        public Rejseplan? Rejseplan { get; set; }
        public int? RejseplanId { get; set; } // FK til Rejseplan
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
