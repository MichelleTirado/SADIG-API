namespace SADIG_API.Domain.Entities
{
    public class Direction
    {
        public int PKDirection {  get; set; }
        public string DirectionName {  get; set; }
        public string Code { get; set; }
        public bool Available { get; set; }
    }
}
