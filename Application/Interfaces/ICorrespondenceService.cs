using SADIG_API.Application.DTOs;

namespace SADIG_API.Application.Interfaces
{
    public interface ICorrespondenceService
    {
        Task<bool> AddCorrespondence(CorrespondenceDto correspondence);
    }
}
