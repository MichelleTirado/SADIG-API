using SADIG_API.Domain.Entities;

namespace SADIG_API.Application.Interfaces
{
    public interface IShiftTypeService
    {
        Task<IEnumerable<ShiftTypeViewModel>> GetShiftTypes(bool available);
    }
}
