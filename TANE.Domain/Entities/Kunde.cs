using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Domain.Entities
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Fornavn { get; set; } = string.Empty;
        public string Efternavn { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string TlfNummer { get; set; } = string.Empty;

        public Kunde()
        {
            
        }

        public Kunde(string fornavn, string efternavn, string email, string tlfNummer)
        {
            this.Fornavn = fornavn;
            this.Efternavn = efternavn;
            this.Email = email;
            this.TlfNummer = tlfNummer;
        }
    }
}
