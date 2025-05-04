using System.ComponentModel.DataAnnotations;

namespace TANE.Application.Dtos
{
    public class DagReorderDto
    {
        [Required] public List<int> DagIds { get; set; }
        [Required] public byte[] OriginalRowVersion { get; set; }
    }
}