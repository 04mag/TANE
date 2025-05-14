using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Domain.Entities
{
    public class RejsePlanSkabelon
    {
        public int  Id { get; set; }
        public List<TurSkabelon> TurSkabeloner { get; set; }

        public string Titel { get; set; } = string.Empty;
        public string Beskrivelse { get; set; } = string.Empty;

        public double GetPris()
        {
            return TurSkabeloner.Sum(t => t.Pris);
        }

        public int GetAntalDage()
        {
            return TurSkabeloner.Sum(t => t.GetAntalDage());
        }
    }
}
