﻿ namespace TANE.Application.Dtos.Skabeloner
{
    public class DagSkabelonReadDto
    {
        public int Id { get; set; }
       // public List<int> TurSkabelonIds { get; set; } = new();
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public string Aktiviteter { get; set; }
        public string Måltider { get; set; } 
        public string Overnatning { get; set; }
        public byte[] RowVersion { get; set; }  // **Til optimistic concurrency**
    }  
}
