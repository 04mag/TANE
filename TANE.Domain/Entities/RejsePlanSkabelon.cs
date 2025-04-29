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

        public double GetPris()
        {
            return TurSkabeloner.Sum(t => t.GetPris());
        }

        public int GetAntalDage()
        {
            return TurSkabeloner.Sum(t => t.GetAntalDage());
        }
    }
}
