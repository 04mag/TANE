using System.ComponentModel.DataAnnotations;

namespace TANE.Application.Dtos
{
    public class RejseplanCreateDto
    {
        public int KundeId { get; set; }
        public string Titel { get; set; } 
        public string Beskrivelse { get; set; } 
        public int AntalVoksne { get; set; }
        public int AntalBørn { get; set; }
        public string Lufthavn { get; set; }
        public double FlyPris { get; set; }
        public int AntalDage { get; set; }
        public DateTime AfrejseTidspunkt { get; set; }
        public bool TilbudSendt { get; set; } = false;
        public bool Opfølgning { get; set; } = false;
        public string OpfølgningNote { get; set; }
        public bool TilbudAccepteret { get; set; } = false;
        public bool RejseBooket { get; set; } = false;
        public bool Anulleret { get; set; } = false;
    }
}
