namespace SADIG_API.Application.DTOs
{
    public class CorrespondenceDto
    {
       public int InternalNumber {  get; set; }
       public int FKDepartmentOrigin { get; set; }
       public int FKUserOrigin { get; set; }
       public int FKDepartmentDestination { get; set; }
       public int FKUserDestination { get; set; }
       public DateTime DateReceived { get; set; }
       public string Subject { get; set; }
       public int FKShiftType { get; set; }
       public int FKUserCreator { get; set; }
    }
}
