using SADIG_API.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data;
using SADIG_API.Application.Interfaces;

namespace SADIG_API.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public UserService(IConfiguration config)
        {
            _configuration = config;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<User>> GetAllUsers(bool available)
        {
            var users = new List<User>();

            using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllUsers", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Available", available);

            await connection.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while(await reader.ReadAsync())
            {
                users.Add(new User
                {
                    PKUser          = reader.GetInt32(0),
                    FirstName       = reader.GetString(1),
                    LastName        = reader.GetString(2),
                    SecondLastName  = reader.GetString(3),
                    Code            = reader.GetInt32(4),
                    RFC             = reader.GetString(5),
                    CURP            = reader.GetString(6),
                    Gender          = reader.GetString(7),
                    Email           = reader.GetString(8),
                    PhoneNumber     = reader.GetString(9),
                    Extension       = reader.GetString(10),
                    ProfileImage    = reader.GetString(11),
                    EntryDate       = reader.GetString(12),
                    FKUserCreator   = reader.GetInt32(13),
                    LastUpdated     = reader.GetDateTime(14),
                    FKUserUpdater   = reader.GetInt32(15),
                    Available       = reader.GetBoolean(16),
                });
            }

            return users;
        }

    }
}
