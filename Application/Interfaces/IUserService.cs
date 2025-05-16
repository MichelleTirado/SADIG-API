using SADIG_API.Domain.Entities;

namespace SADIG_API.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers(bool available);
    }
}
