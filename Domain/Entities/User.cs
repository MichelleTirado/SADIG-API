using System.ComponentModel.DataAnnotations;

namespace SADIG_API.Domain.Entities
{
    public class User
    {
      [Key]
      public int PKUser { get; set; }
      public string? FirstName { get; set; }
      public string? LastName { get; set; }
      public string? SecondLastName { get; set; }
      public int? Code { get; set; }
      public string? RFC {  get; set; }
      public string? CURP {  get; set; }
      public string? Gender { get; set; }
      public string? Email { get; set; }
      public string? PhoneNumber { get; set; }
      public string? Extension { get; set; }
      public string? ProfileImage { get; set; }
      public string? EntryDate { get; set; }
      public int? FKUserCreator {  get; set; }
      public DateTime? LastUpdated {  get; set; }
      public int? FKUserUpdater { get; set; }
      public bool? Available {  get; set; }
    }
}
