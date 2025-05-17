using System.Text.Json.Serialization;

namespace TANE.Domain.Entities
{
    public class DagTurSkabelon
    {
        public int DagSkabelonId { get; set; }
        public DagSkabelon? DagSkabelon { get; set; }
        public int TurSkabelonId { get; set; }
        [JsonIgnore]
        public TurSkabelon? TurSkabelon { get; set; }
        public int Order { get; set; } //tracks order
        public byte[]? RowVersion { get; set; } = null;
    }
}