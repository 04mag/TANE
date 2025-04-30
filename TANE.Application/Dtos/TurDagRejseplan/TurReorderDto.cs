using System.ComponentModel.DataAnnotations;

namespace TANE.Rejseplan.Application.Dtos
{
    public class TurReorderDto
    {
        [Required] public List<int> TurIds { get; set; }
        [Required] public byte[] OriginalRowVersion { get; set; }
    }
}