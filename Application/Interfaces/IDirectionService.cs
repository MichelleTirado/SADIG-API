using SADIG_API.Domain.Entities;

namespace SADIG_API.Application.Interfaces
{
    public interface IDirectionService
    {
        Task<IEnumerable<Direction>> GetAllDirections(bool available);
    }
}
