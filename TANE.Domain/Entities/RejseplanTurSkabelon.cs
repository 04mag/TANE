using System.Text.Json.Serialization;

namespace TANE.Domain.Entities
{
    public class RejseplanTurSkabelon
    {
        public int TurSkabelonId { get; set; }
        public TurSkabelon? TurSkabelon { get; set; }
        public int RejseplanSkabelonId { get; set; }
        public int Order { get; set; } //tracks order
    }
}