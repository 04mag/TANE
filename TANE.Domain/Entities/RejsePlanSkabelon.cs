using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Domain.Entities
{
    public class RejseplanSkabelon
    {
        public int  Id { get; set; }
        public List<TurSkabelon> Ture { get; set; }

        public string Titel { get; set; } = string.Empty;
        public string Beskrivelse { get; set; } = string.Empty;

        public double GetPris()
        {
            return Ture.Sum(t => t.Pris);
        }

        public int GetAntalDage()
        {
            return Ture.Sum(t => t.GetAntalDage());
        }
    }
}
