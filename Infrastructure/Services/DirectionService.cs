using Microsoft.Data.SqlClient;
using SADIG_API.Application.Interfaces;
using SADIG_API.Domain.Entities;
using System.Data;

namespace SADIG_API.Infrastructure.Services
{
    public class DirectionService : IDirectionService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DirectionService(IConfiguration config) 
        { 
            _configuration = config;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Direction>> GetAllDirections(bool available)
        {
            var directions = new List<Direction>();

            using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllDirections", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Available", available);

            await connection.OpenAsync();
            
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                directions.Add(new Direction
                {
                    PKDirection     = reader.GetInt32(0),
                    DirectionName   = reader.GetString(1),
                    Code            = reader.GetString(2),
                    Available       = reader.GetBoolean(3)
                });
            }

            return directions;
        }
    }
}
