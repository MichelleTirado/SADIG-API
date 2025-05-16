namespace SADIG_API.Domain.Entities
{
    public class Area
    {
        public int PKArea {  get; set; }
        public string AreaName { get; set; }
        public string Code { get; set; }
        public int FKDirection { get; set; }
        public string Acronym { get; set; }
        public bool Available { get; set; }

    }
}
