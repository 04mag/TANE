namespace TANE.Application.Dtos
{
    public class RejseplanReadDto
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public int KundeId { get; set; }
        public int AntalVoksne { get; set; }
        public int AntalBørn { get; set; }
        public string Lufthavn { get; set; }
        public double FlyPris { get; set; }
        public int AntalDage { get; set; }
        public DateTime AfrejseTidspunkt { get; set; }
        public List<TurReadDto> Ture { get; set; } = new();

        public bool TilbudSendt { get; set; } = false;
        public bool Opfølgning { get; set; } = false;
        public string OpfølgningNote { get; set; }
        public bool TilbudAccepteret { get; set; } = false;
        public bool RejseBooket { get; set; } = false;
        public bool Annulleret { get; set; } = false;
        public Status TilbudsStatus { get; set; } = Status.RejseplanOprettet;
        public enum Status
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
        public byte[] RowVersion { get; set; }  // **Til optimistic concurrency**
    }
}
