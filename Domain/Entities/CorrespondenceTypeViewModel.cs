using System.ComponentModel.DataAnnotations;

namespace SADIG_API.Domain.Entities
{
    public class CorrespondenceTypeViewModel
    {
        [Key]
        public int PKCorrespondenceType { get; set; }
        public string CorrespondenceType { get; set; }
        public string? Description { get; set; }
        public bool Available { get; set; }
    }
}
