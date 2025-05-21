using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Domain.Entities
{
    public class Dag
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public string Aktiviteter { get; set; }
        public string Måltider { get; set; }
        public string Overnatning { get; set; }
        public int Sekvens { get; set; } // Rækkefølge af dagen i turen
        public Tur? Tur { get; set; }
        public int? TurId { get; set; } // FK til Tur
        [Timestamp]
        public byte[] RowVersion { get; set; } // Til optimistic concurrency

        public int GetAntalOvernatninger()
        {
            if (string.IsNullOrEmpty(Overnatning))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
