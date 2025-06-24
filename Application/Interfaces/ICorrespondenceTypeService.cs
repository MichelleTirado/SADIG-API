using SADIG_API.Domain.Entities;

namespace SADIG_API.Application.Interfaces
{
    public interface ICorrespondenceTypeService
    {
        Task<IEnumerable<CorrespondenceTypeViewModel>> GetCorrespondenceTypes(bool available);
        Task<bool> AddCorrespondenceType(string correspondenceType, string description, bool available);
    }
}
