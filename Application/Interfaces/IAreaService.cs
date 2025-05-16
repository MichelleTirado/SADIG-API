using SADIG_API.Domain.Entities;

namespace SADIG_API.Application.Interfaces
{
    public interface IAreaService
    {
        Task<IEnumerable<Area>> GetAllAreas(bool available);
    }
}
