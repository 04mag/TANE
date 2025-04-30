using System.ComponentModel.DataAnnotations;

namespace TANE.Rejseplan.Application.Dtos
{
    public class DagReorderDto
    {
        [Required] public List<int> DagIds { get; set; }
        [Required] public byte[] OriginalRowVersion { get; set; }
    }
}