using Microsoft.Data.SqlClient;
using SADIG_API.Application.Interfaces;
using SADIG_API.Domain.Entities;

namespace SADIG_API.Infrastructure.Services
{
    public class AreaService : IAreaService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public AreaService(IConfiguration config)
        {
            _configuration = config;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Area>> GetAllAreas(bool available)
        {
            var areas = new List<Area>();

            using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllAreas", connection);

            cmd.Parameters.AddWithValue("@Available", available);
            await connection.OpenAsync();

            using var reader = await cmd.ExecuteReaderAsync();

            while(await reader.ReadAsync())
            {
                areas.Add(new Area
                {
                    PKArea      = reader.GetInt32(0),
                    AreaName    = reader.GetString(1),
                    Code        = reader.GetString(2),
                    FKDirection = reader.GetInt32(3),
                    Acronym     = reader.GetString(4),
                    Available   = reader.GetBoolean(5),
                });
            }

            return areas;
            
        }
    }
}
