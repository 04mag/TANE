using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Application.Dtos.TurDagRejseplan
{
    public enum RejseplanStatusDto
    {
        RejseplanOprettet,
        TilbudSendt,
        AfventerOpfølgning,
        OpfølgningSvaret,
        TilbudAccepteret,
        RejseBooket,
        Annulleret,
        Udskudt
    }
}
