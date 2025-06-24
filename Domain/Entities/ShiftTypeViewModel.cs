using System.ComponentModel.DataAnnotations;

namespace SADIG_API.Domain.Entities
{
    public class ShiftTypeViewModel
    {
        [Key]
        public int PKShiftType { get; set; }
        public string ShiftType { get; set; }
        public string? Description { get; set; }
        public bool Available { get; set; }
    }
}
